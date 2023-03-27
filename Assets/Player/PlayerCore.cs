using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public GameObject playerrr;
    [SerializeField] float speedMove;
    [SerializeField] float speedRot;
    [SerializeField] Camera _cam;
    [SerializeField] Vector3 camPos;
    [SerializeField] float camSpeed;
    public AudioSource source;
    public AudioClip clip;
    bool sound=false;
    float i = 0.3f;
    float joy;
    public bool isMoving;
    bool isUsing;
    Item activeItem;
    float questItem;

    void FixedUpdate()
    {
        MoveControl(isMoving);
        //Crouch(isUsing);
        if (Input.GetButtonDown("Use"))
            StartCoroutine(ItemUse());
       
        CameraMove();
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

    void MoveControl(bool isMove)
    {
        joy = Input.GetAxis("Horizontal");
        if (joy != 0 && isMove)
        {
            anim.SetBool("isWalking", true);
            transform.GetComponent<AudioSource>().enabled = true;
            _transform.position += new Vector3(joy * Time.deltaTime * speedMove, 0, 0);
            if (joy < 0)
            { 
                _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(new Vector3(-1, 0, -0.01f), Vector3.up), speedRot * Time.deltaTime);
            }
            else
            {
                _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(new Vector3(1, 0, -0.01f), Vector3.up), speedRot * Time.deltaTime);
            }
        } else {
            anim.SetBool("isWalking", false);
            transform.GetComponent<AudioSource>().enabled = false;

        }
    }

    private void CameraMove()
    {
        _cam.transform.position = Vector3.Lerp(_cam.transform.position, new Vector3(_transform.position.x, _transform.position.y, 0) + camPos, camSpeed * Time.deltaTime);
    }

    private IEnumerator ItemUse()
    {
        if (activeItem != null && !isUsing)
        {
            anim.SetTrigger("isUsing");
            isMoving = false;
            isUsing = true;
            yield return new WaitForSeconds(1.5f);
            isMoving = true;
            isUsing = false;
            activeItem.Use();
        }
    }

    //private void Crouch(bool isCrouch)
    //{
    //    if (!isCrouch) { 
    //        if (Input.GetButton("Crouch"))
    //        {
    //            anim.SetBool("isCrouching", true);
    //            anim.SetBool("isWalking", false);
    //            if (joy != 0)
    //                anim.StopPlayback();
    //            else
    //                anim.StartPlayback();
    //        }
    //        if (Input.GetButtonUp("Crouch"))
    //        {
    //            anim.SetBool("isCrouching", false);
    //            anim.SetBool("isWalking", true);
    //        }
            
    //    }
    //}

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        isMoving = true;
        isUsing = false;
        activeItem = null;
    }

    public void PlaySteps()
    {
        source.Play();
    }
    Animator anim;
    Transform _transform;
}