using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raztm : MonoBehaviour
{
    public GameObject ztm;
    public float time;
    void Start()
    {
        Invoke("razztm", time);
    }
    public void razztm()
    {
        ztm.SetActive(false);
    }

}
