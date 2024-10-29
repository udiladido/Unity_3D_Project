using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable
}

public enum ConsumableType
{
    Stamina,
    Health

}



[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}


[CreateAssetMenu(fileName = "Item", menuName ="New Item")]
public class ItemDataSO : ScriptableObject
{

    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;


    [Header("Equip")]
    public GameObject equipPrefab;


}
