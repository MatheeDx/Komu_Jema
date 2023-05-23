using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DedEngine : MonoBehaviour
{
    float speedRot = 5.41f;
    float speedMove = 2.1f;
    public float agr;
    public float agrSpeed = 100;
    public float maxAgr = 20;
    float dist = 60f;
   [SerializeField] private Image TriggerMoment;
    public GameObject GameOverPanel;
    float trig;
    [SerializeField] int lvl;
    public interface ICommand
    {
        public void Execute();
        public float T { get; set; }
    }

    public class Wait: ICommand
    {
        public Wait(Transform obj, float t)
        {
            timer = t;
            m_Transform = obj;
        }
        public float T
        {
            get { return timer; }
            set
            {
                T = timer;
            }
        }
        public void Execute()
        {
            
        }
        float timer;
        Transform m_Transform;
    }

    //public void _wait(float timer)
    //{
    //    StartCoroutine(WaitInSec(timer));
    //}

    //public IEnumerator WaitInSec(float timer)
    //{
    //    _wait(timer);
    //    yield return wa;
    //}

    public class MoveToInSec : ICommand
    {
        public MoveToInSec(Transform obj, float dir, float t) {
            m_Transform = obj;
            timer = t;
            m_To = dir;
        }

        public float T {
            get { return timer; }
            set
            {
                T = timer;
            }
        }


        public void Execute()
        {
            m_Transform.GetComponent<DedEngine>().MoveTo(m_Transform, m_To, timer);
        }

        float m_To;
        public float timer;
        Transform m_Transform;
    }

    public IEnumerator moveToInSec(Transform obj, float dir, float t)
    {
        float timer = 0;
        Animator anim = obj.GetComponent<Animator>();
        
        while (t >= timer)
        {
            anim.SetBool("isWalking", true);
            timer += Time.deltaTime;
            obj.position += new Vector3(dir * Time.deltaTime * speedMove, 0, 0);
            if (dir < 0)
                obj.rotation = Quaternion.Lerp(obj.rotation, Quaternion.LookRotation(new Vector3(-1, 0, 0), Vector3.up), speedRot * Time.deltaTime);
            else
                obj.rotation = Quaternion.Lerp(obj.rotation, Quaternion.LookRotation(new Vector3(1, 0, 0), Vector3.up), speedRot * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        anim.SetBool("isWalking", false);
    }

    public void MoveTo(Transform m_Transform, float m_To, float timer)
    {
        StartCoroutine(moveToInSec(m_Transform, m_To, timer));
    }

    public bool up;
    public class UseStairs : ICommand
    {
        public UseStairs(Transform obj)
        {
            m_Transform = obj;
            tele = obj.GetComponent<Teleport>();

        }
        public void Execute()
        {
            
            if (m_Transform.GetComponent<DedEngine>().up)
            {
                m_Transform.position = down;
                m_Transform.GetComponent<DedEngine>().up = false;

            } else
            {
                m_Transform.position = up;
                m_Transform.GetComponent<DedEngine>().up = true;
            }
        }
        public float T
        {
            get { return 1; }
            set
            {
                T = 3;
            }
        }
        Vector2 up = new Vector3(3.47f, 12.68f, 1.3f);
        Vector3 down = new Vector3(2.12f, -0.66f, 1.3f);
        Transform m_Transform;
        Teleport tele;
    }

    private IEnumerator Instructions1()
    {
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, -1, 9f));
        actions.Add(new Wait(_transform, 2));
        actions.Add(new UseStairs(_transform));
        actions.Add(new MoveToInSec(_transform, -1, 10f));
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, 1, 10f));
        actions.Add(new UseStairs(_transform));
        actions.Add(new MoveToInSec(_transform, 1, 9f));


        while (true)
            foreach (ICommand act in actions)
            {
                act.Execute();
                yield return new WaitForSeconds(act.T);
            }
    }

    private IEnumerator Instructions2()
    {
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, -1, 9f));
        actions.Add(new Wait(_transform, 2));
        actions.Add(new UseStairs(_transform));
        actions.Add(new MoveToInSec(_transform, 1, 3f));
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, -1, 3f));
        actions.Add(new MoveToInSec(_transform, -1, 5f));
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, 1, 5f));
        actions.Add(new UseStairs(_transform));
        actions.Add(new MoveToInSec(_transform, 1f, 9f));


        while (true)
            foreach (ICommand act in actions)
            {
                act.Execute();
                yield return new WaitForSeconds(act.T);
            }
    }

    private void Detector()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_transform.position + new Vector3(0, 2, 0), 3f, _transform.forward, out hit, Mathf.Infinity)) {
            if(hit.collider.tag == "Player")
            {
                Debug.Log(hit.distance);
                agr += agrSpeed * (hit.distance / dist) * Time.deltaTime;
            }
        } else {
            if(agr > 0)
            {
                agr -= 1 * Time.deltaTime;
            }
        }
    }

    private void Start()
    {
        if(lvl == 1)
            StartCoroutine(Instructions1());
        else if(lvl == 2)
            StartCoroutine(Instructions2());
    }

    private void Update()
    {
        Detector();
        if (agr < maxAgr)
        {
            trig = (agr / maxAgr);
            TriggerMoment.fillAmount = trig;
        }
        if (agr > maxAgr)
        {
            GameOver();
        }
    }

    private void Awake()
    {
        up = true;
        _transform = GetComponent<Transform>();
        actions = new List<ICommand>();
        agr = 0;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            agr += agrSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item" && other.TryGetComponent(out Teleport item))
        {
            
            tele.x = item.twinTeleport.transform.position.x;
            tele.y = item.twinTeleport.transform.position.y;
            Debug.Log(tele);
        }
    }


    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerCore>().isMoving = false;
        Invoke("StopTime", 0);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Item" && other.TryGetComponent(out Item item))
    //    {
    //        tele.x = _transform.position.x;
    //        tele.y = _transform.position.y;
    //    }
    //}

    Vector2 tele;
    List<ICommand> actions;
    Transform _transform;
}