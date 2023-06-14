using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimCamera : MonoBehaviour
{
    public Animation anim;
    public float time;
    private void Start()
    {
        Invoke("StopTime", 2);
        Invoke("Pusk", time);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Stop();
            Invoke("PlayTime", 0);
        }
    }
    public void Pusk()
    {
        anim = GetComponent<Animation>();
        anim.Play();
        Invoke("PlayTime", 12);
    }
    void StopTime()
    {
        Time.timeScale = 0f;
    }
    void PlayTime()
    {
        Time.timeScale = 1f;
    }
}
