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

    private IEnumerator Instructions()
    {
        actions.Add(new MoveToInSec(_transform, 1, 6));
        actions.Add(new Wait(_transform, 2));
        actions.Add(new MoveToInSec(_transform, -1, 3));
        actions.Add(new Wait(_transform, 2));

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
        if (Physics.Raycast(_transform.position, _transform.forward, out hit)) {
            if(hit.collider.tag == "Player")
            {
                Debug.Log(123321);
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
        _transform = GetComponent<Transform>();
        actions = new List<ICommand>();
    }

    List<ICommand> actions;
    Transform _transform;
}