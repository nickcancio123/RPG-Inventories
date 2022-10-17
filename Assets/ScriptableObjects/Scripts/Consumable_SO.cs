using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultConsumable", menuName = "ScriptableObjects/Item/Consumable")]
public class Consumable_SO : Item_SO
{
    [SerializeField] float hungerFillAmount;
}
