using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Weapons")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public int damage;
}
