using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDB", menuName = "ScriptableObjects/Item")]
public class QItem : ScriptableObject
{
    public int id;
    public string name;
    public Sprite icon;
}
