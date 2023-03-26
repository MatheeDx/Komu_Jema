using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetBool("isOpening", true);
            door.gameObject.GetComponent<Collider>().enabled = false;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetBool("isOpening", false);
            door.gameObject.GetComponent<Collider>().enabled = true;
        }
            
    }

    [SerializeField] Animator door;
}
