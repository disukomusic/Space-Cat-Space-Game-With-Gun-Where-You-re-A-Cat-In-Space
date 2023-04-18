using UnityEngine;


[CreateAssetMenu(fileName="New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDescription;
    [Header("For HP Up: HP gain | " +
            " For Weapons: Weapon Fire Rate | " +
            "For Score Up: Score Gain |")]
    public float value;
    [Header("For Weapons: Weapon Damage")]
    public float value2;
    public Sprite icon;
    public ItemType itemType;

    public GameObject bullet;

    public enum ItemType
    {
        Test,
        HealthUp,
        ScoreUp,
        Weapon,
        Trophy,
    }
}
