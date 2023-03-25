using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animation anim;
    public float time;
    public GameObject target;
    private void Start()
    {
        target.SetActive(false);
        PuskAnim();
    }
    public void Anima()
    {
        anim = GetComponent<Animation>();
        anim.Play();
        target.SetActive(true);
    }
    void PuskAnim()
    {
        Invoke("Anima", time);
    }
}
