using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour, Item
{
    [SerializeField] Teleport twinTeleport;
    GameObject player;

    public void Use()
    {
        player.transform.position = new Vector3(twinTeleport.transform.position.x, twinTeleport.transform.position.y, 0);
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
        button.transform.localPosition = new Vector3(0, 8, -6);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    GameObject button = null;
    Transform _transform;
}
