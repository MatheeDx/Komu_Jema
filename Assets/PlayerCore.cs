using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] float speedMove;
    [SerializeField] float speedRot;
    Item activeItem;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        activeItem = null;
    }

    void Update()
    {
        MoveControl();

        if(Input.GetButtonDown("Use"))
            ItemUse();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item" && other.TryGetComponent(out Item item))
        {
            activeItem = item;
            item.Alarm();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item" && other.TryGetComponent(out Item item))
        {
            activeItem = null;
            item.Sleep();
        }
    }

    void MoveControl()
    {
        float joy = Input.GetAxis("Horizontal");

        if (joy != 0)
        {
            _transform.position += new Vector3(joy * 0.1f * speedMove, 0, 0);
            if (joy < 0)
                _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(Vector3.left, Vector3.up), speedRot * Time.deltaTime);
            else
                _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(Vector3.right, Vector3.up), speedRot * Time.deltaTime);
        }
    }

    void ItemUse()
    {
        if (activeItem != null)
        {
            activeItem.Use();
        }
    }

    Transform _transform;
}