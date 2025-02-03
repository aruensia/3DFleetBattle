using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Ship/WeaponData")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int damage;
    public int attackRange;
    public float attackSpeed;

}
