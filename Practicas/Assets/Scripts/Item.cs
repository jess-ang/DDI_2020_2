using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Equip,
    Medicine,
    Money
}

[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventrario/Generic Item")]
public class Item : ScriptableObject
{
    public Sprite icon = null;
    public ItemType itemType = ItemType.Weapon;

    public virtual void Use()
    {
        Debug.Log("Usando item" + name);
    }
}
