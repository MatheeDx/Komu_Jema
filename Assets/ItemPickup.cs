using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemPickup : MonoBehaviour, Item
{
    GameObject player;
    [SerializeField] QItem item;

    public void Use()
    {
        player.GetComponent<Inventory>().AddItem(item);
        Destroy(gameObject);
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
        button.transform.localPosition = new Vector3(19.46f, -4.1f, 0.3f);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    GameObject button = null;
    Transform _transform;

}


