using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedEngine : MonoBehaviour
{
    float speedRot = 5.41f;
    float speedMove = 2.1f;

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
                obj.rotation = Quaternion.Lerp(obj.rotation, Quaternion.LookRotation(new Vector3(-1, 0, -0.01f), Vector3.up), speedRot * Time.deltaTime);
            else
                obj.rotation = Quaternion.Lerp(obj.rotation, Quaternion.LookRotation(new Vector3(1, 0, -0.01f), Vector3.up), speedRot * Time.deltaTime);
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
        Vector2 up = new Vector3(3.47f, 12.68f, 1f);
        Vector3 down = new Vector3(2.12f, -0.66f, 1f);
        Transform m_Transform;
        Teleport tele;
    }

    private IEnumerator Instructions()
    {
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, -1, 9f));
        actions.Add(new Wait(_transform, 2));
        actions.Add(new UseStairs(_transform));
        actions.Add(new MoveToInSec(_transform, -1, 9f));
        actions.Add(new Wait(_transform, 3));
        actions.Add(new MoveToInSec(_transform, 1, 9f));
        actions.Add(new UseStairs(_transform));
        actions.Add(new MoveToInSec(_transform, 1, 9f));


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
        if (Physics.Raycast(_transform.position + new Vector3(0, 2, 0), _transform.forward, out hit)) {
            if(hit.collider.tag == "Player")
            {
                //
            }
        }
    }

    private void Start()
    {
        StartCoroutine(Instructions());
    }

    private void Update()
    {
        Detector();
    }

    private void Awake()
    {
        up = true;
        _transform = GetComponent<Transform>();
        actions = new List<ICommand>();
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