using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject PanelRAZ;
    public GameObject PanelDVA;
    bool raz;
    bool dva;
    private void Start()
    {
        bool raz = false;
        bool dva = false;
    }
    public void menyia()
    {
        if (raz == false)
        {
            PanelRAZ.SetActive(true);
            raz = true;
            dva = false;
            PanelDVA.SetActive(false);
        }

    }
}
