using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLNExt : MonoBehaviour
{
    public int lvl;
    public void SelectScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + lvl);
    }
}
