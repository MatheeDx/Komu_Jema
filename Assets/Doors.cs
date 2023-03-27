using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
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
