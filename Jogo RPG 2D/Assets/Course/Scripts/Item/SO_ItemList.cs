using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="so_ItemList", menuName="Scriptable Object/Item/Item List")]
public class SO_ItemList : ScriptableObject
{
    [SerializeField]
    public List<ItemDetails> itemDetails;
}
