using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gorshenev : MonoBehaviour, Item
{
    [SerializeField] Animator anim = null;
    [SerializeField] Vector3 btnPos;
    [SerializeField] GameObject win;
    public Text tasks;
    public string _temp;
    public QItem _item;


    public void Use()
    {
        
        if (_item == null)
        {
            StartCoroutine(Win());
            Destroy(gameObject);
        }
        else
        {
            if (ItemCheck(_item))
            {
                StartCoroutine(Win()); 
                Destroy(gameObject);
            }
            else
                button.GetComponent<TextMeshPro>().text = _temp;
        }
    }

    bool ItemCheck(QItem item)
    {
        List<QItem> items = player.GetComponent<Inventory>().inventoryItems;
        if (items.Count == 0)
            return false;

        foreach (QItem ones in items)
        {
            if (ones.id == item.id)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator Win()
    {
        tasks.text = "1/1";
        yield return new WaitForSeconds(4);
        win.SetActive(true);
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
        text.text = "—бой в матрице!";
        button.transform.SetParent(_transform);
        text.alignment = TextAlignmentOptions.Center;
        text.color = Color.white;
        text.fontSize = 10;
        button.transform.localPosition = new Vector3(0, 0, 0) + new Vector3(0, 0.005f, 0.01f);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    GameObject player;
    GameObject button = null;
    Transform _transform;
}
