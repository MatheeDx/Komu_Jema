using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class usingIco : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Image image;
    Transform transform;
    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
