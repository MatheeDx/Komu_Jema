using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLNExt : MonoBehaviour
{
    public int lvl;
    public float time;
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + lvl);
    }
    public void SelectScene()
    {
        Invoke("LoadScene", time);
    }
    
}
