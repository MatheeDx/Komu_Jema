using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class lvlproiden : MonoBehaviour
{
    public int lvll;
    public GameObject zamok;
    public void complete()
    {
        int lvl = (SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("lvl", lvl);
        PlayerPrefs.Save();
    }
    void Start()
    {
        int locked = PlayerPrefs.GetInt("lvl");
        Debug.Log(locked);
        if (locked+1 >= lvll )
        {
            zamok.SetActive(false);
        }
    }
    public void Clear()
    {
            PlayerPrefs.DeleteAll();
            Debug.Log("—бросилось");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Opener()
    {
        PlayerPrefs.SetInt("lvl", 6);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
