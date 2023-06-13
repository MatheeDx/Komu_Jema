using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animation anim;
    public float time;
    public float time1;
    public GameObject target;
    public GameObject targetS;
    public GameObject targetS1;
    public GameObject targetS2;
    public GameObject targetS3;
    public GameObject targetD;
    public void Anima()
    {
        anim = GetComponent<Animation>();
        anim.Play();
        target.SetActive(true);
    }
    public void PuskAnim()
    {
        Invoke("Anima", time);
    }
    public void DeletObject()
    {
        target.SetActive(false);
    }
    public void DeletObject111()
    {
        Invoke("DeletObject", time);
    }
    public void DeletObject2()
    {
        targetD.SetActive(false);
    }
    public void DeletObject222()
    {
        Invoke("DeletObject2", time);
    }
    public void SetObject()
    {
        targetS.SetActive(true);
        targetS1.SetActive(true);
        targetS2.SetActive(true);
        targetS3.SetActive(true);

    }
    public void SetObject111()
    {
        Invoke("SetObject", time1);
    }
}
