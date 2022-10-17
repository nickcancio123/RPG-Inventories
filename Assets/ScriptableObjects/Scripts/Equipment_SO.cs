using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultEquipment", menuName = "ScriptableObjects/Item/Equipment")]
public class Equipment_SO : Item_SO
{
    [SerializeField] float attack;
}
