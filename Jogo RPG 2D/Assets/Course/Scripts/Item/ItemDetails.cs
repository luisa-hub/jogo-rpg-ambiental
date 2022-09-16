using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemDetails 
{
    public int itemCode;
    public ItemType itemType;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool isStartingItem;
    public bool canBePicked;
    public bool canBeDropped;
    public bool canBeEaten;
    public bool canBeCarried;

}
