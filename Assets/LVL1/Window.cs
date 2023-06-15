using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Window : MonoBehaviour, Item
{
    [SerializeField] Animator anim = null;
    [SerializeField] Vector3 btnPos;
    [SerializeField] GameObject win;
    public GameObject svet;
    public Text tasks;
    [SerializeField] GameObject load;
    public GameObject winplane;

    public void Use()
    {
        StartCoroutine(Win());
    }

    IEnumerator Win()
    {
        transform.GetComponent<Renderer>().material.color = Color.white;
        svet.gameObject.SetActive(false);
        tasks.text = "1/1";
        yield return new WaitForSeconds(4);
        win.SetActive(true);
        winplane.SetActive(true);
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
        text.text = "≈Ã¿≈!";
        button.transform.SetParent(_transform);
        text.alignment = TextAlignmentOptions.Center;
        text.color = Color.white;
        text.fontSize = 10;
        button.transform.localPosition = new Vector3(0, 0, 0) + new Vector3(0, 0.005f, 0.01f);
    }

    public void Loading()
    {
        button = Instantiate(load);


        button.transform.SetParent(_transform);

        button.transform.localPosition = new Vector3(0, 0, 0) + btnPos;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.GetComponent<Renderer>().material.color = Color.red;
    }

    GameObject player;
    GameObject button = null;
    Transform _transform;
}
