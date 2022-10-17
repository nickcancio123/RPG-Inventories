using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultItem", menuName = "ScriptableObjects/Item/Item")]
public class Item_SO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
}
