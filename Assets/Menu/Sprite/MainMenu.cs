using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float f;
    public Animation anim;
    public void PlayGame()
    {  
        anim = GetComponent<Animation>();
        anim.Play();
        Invoke("NextScene", f);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Debug.Log("»гра всЄ");
        Application.Quit();
    }
}
