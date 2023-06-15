using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINWIN : MonoBehaviour
{
    public GameObject winwin;
    public float time;
    void Start()
    {
        Invoke("vkl", time);

    }
    public void vkl()
    {
        int locked = PlayerPrefs.GetInt("lvl");
        if (locked == 6)
        {
            winwin.SetActive(true);
        }
    }
}
