using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doors : MonoBehaviour
{
    public Vector3 btnPos;
    GameObject button;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ded")
        {
            door.SetBool("isOpening", true);
            door.gameObject.GetComponent<Collider>().enabled = false;
        }
        if (other.gameObject.tag == "Player")
        {
            if (key == null)
            {
                door.SetBool("isOpening", true);
                door.gameObject.GetComponent<Collider>().enabled = false;
            } else if (ItemCheck(key))
            {
                door.SetBool("isOpening", true);
                door.gameObject.GetComponent<Collider>().enabled = false;
            } else
            {
                button = new GameObject(name);
                TextMeshPro text = button.AddComponent<TextMeshPro>();
                text.text = "Закрыто!";
                button.transform.SetParent(transform);
                text.alignment = TextAlignmentOptions.Center;
                text.color = Color.white;
                text.fontSize = 10;
                button.transform.localPosition = new Vector3(0, 0, 0) + new Vector3(-4f, 4.4f, 0);
            }
        }
    }

    bool ItemCheck(QItem item)
    {
        List<QItem> items =  player.GetComponent<Inventory>().inventoryItems;
        if(items.Count == 0)
            return false;

        foreach (QItem ones in items)
        {
            if(ones.id == item.id)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ded")
        {
            door.SetBool("isOpening", false);
            door.gameObject.GetComponent<Collider>().enabled = true;
            Destroy(button);
        }
    }

    private void Awake()
    {
        Debug.Log(key);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    [SerializeField] QItem key;
    [SerializeField] Animator door;
    GameObject player;
}
