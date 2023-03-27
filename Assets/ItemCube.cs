using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCube : MonoBehaviour, Item
{
    [SerializeField] Animator anim = null;
    [SerializeField] Vector3 btnPos;
    bool isCovering;
    
    public void Use()
    {
        if (!isCovering)
        {
            player.transform.position = player.transform.position + new Vector3(0, 0, 7);
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<PlayerCore>().isMoving = false;
            if (anim != null)
                anim.SetTrigger("isCover");
            isCovering = true;
            
        }
        else
        {
            player.transform.position = player.transform.position + new Vector3(0, 0, -7);
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<PlayerCore>().isMoving = true;
            if(anim != null)
                anim.SetTrigger("isCover");
            isCovering =false;
        }

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
        button.transform.localPosition = new Vector3(0, 0, 0) + btnPos;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        isCovering = false;
    }

    GameObject player;
    GameObject button = null;
    Transform _transform;
}
