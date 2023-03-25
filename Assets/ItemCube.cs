using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCube : MonoBehaviour, Item
{
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void Use()
    {
        Debug.Log(321);
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
        text.color = Color.black;
        text.fontSize = 10;
        button.transform.localPosition = new Vector3(0, 2, -3);
    }

    GameObject button = null;
    Transform _transform;
}
