using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINWIN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int locked = PlayerPrefs.GetInt("lvl");
        if (locked == 6)
        {
            Debug.Log("С победой");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
