using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemPickup : MonoBehaviour, Item
{
    GameObject player;
    [SerializeField] QItem item;
    public string _text;
    public string _temp;
    public Vector3 btnPos;
    public QItem _item;

    public void Use()
    {
        if (_item == null)
        {
            player.GetComponent<Inventory>().AddItem(item);
            Destroy(gameObject);
        }
        else
        {
            if (ItemCheck(_item))
            {
                player.GetComponent<Inventory>().AddItem(item);
                Destroy(gameObject);
            }
            else
                button.GetComponent<TextMeshPro>().text = _temp;          
        }
            
        
    }

    bool ItemCheck(QItem item)
    {
        List<QItem> items = player.GetComponent<Inventory>().inventoryItems;
        if (items.Count == 0)
            return false;

        foreach (QItem ones in items)
        {
            if (ones.id == item.id)
            {
                return true;
            }
        }
        return false;
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
        text.text = _text;
        button.transform.SetParent(_transform);
        text.alignment = TextAlignmentOptions.Center;
        text.color = Color.white;
        text.fontSize = 10;
        button.transform.localPosition = btnPos;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    GameObject button = null;
    Transform _transform;

}


