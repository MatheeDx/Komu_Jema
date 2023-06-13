using UnityEngine;

public class ZoneProp : MonoBehaviour
{
    public float impact = 1f;
    public bool onCol = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onCol = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onCol = false;
        }
    }
}
