using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour, Item
{
    public Teleport twinTeleport;
    GameObject player;
    public GameObject target;
    public void Use()
    {
        target.transform.GetComponent<AudioSource>().enabled = true;
        player.transform.position = new Vector3(twinTeleport.transform.position.x, twinTeleport.transform.position.y, 1.3f);
        Invoke("sound", 1);

    }

    public void Sleep()
    {
        if (button != null)
        {
            Destroy(button);
            button = null;
        }
    }

    public void Alarm()
    {
        button = new GameObject(name);
        TextMeshPro text = button.AddComponent<TextMeshPro>();
        text.text = "E";
        button.transform.SetParent(_transform);
        text.alignment = TextAlignmentOptions.Center;
        text.color = Color.white;
        text.fontSize = 10;
        button.transform.localPosition = new Vector3(0, 8, -2);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void sound()
    {
        target.transform.GetComponent<AudioSource>().enabled = false;
    }
    GameObject button = null;
    Transform _transform;

}
