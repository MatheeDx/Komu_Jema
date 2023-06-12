using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animation anim;
    public float time;
    public GameObject target;
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
}
