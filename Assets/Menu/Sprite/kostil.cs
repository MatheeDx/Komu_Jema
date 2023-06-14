using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kostil : MonoBehaviour
{
    public GameObject vklychenie;
    public float time;
    public void vkl()
    {
        vklychenie.SetActive(true);
    }
    public void timeeer()
    {
        Invoke("vkl", time);
    }
}
