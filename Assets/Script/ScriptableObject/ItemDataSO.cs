using JetBrains.Annotations;
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
    Health,
    Clocking,
    SpeedUp

}

public enum Equiparts
{ 
    Body,
    Head,
    Shoe,
    Weapon

}


[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

public class ItemDataEquipStat
{
    public Equiparts part;
    public float attackPow;
    public float attackSpeed;
    public float AmorDefense;
    public float additionSpeed;

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

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;


}
