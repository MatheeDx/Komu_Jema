using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] float speedMove;
    [SerializeField] float speedRot;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        MoveControl();
    }

    void MoveControl()
    {
        float joy = -Input.GetAxis("Horizontal");

        if (joy != 0)
        {
            _transform.position += new Vector3(joy * 0.1f * speedMove, 0, 0);
            if (joy < 0)
                _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(Vector3.left, Vector3.up), speedRot * Time.deltaTime);
            else
                _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(Vector3.right, Vector3.up), speedRot * Time.deltaTime);

        }
        
    }

    Transform _transform;
}