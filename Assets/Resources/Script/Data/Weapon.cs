using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Ship/WeaponData")]
public class Weapon : DefaultShipPart
{
    public int damage;
    public int attackRange;
    public WeaponType weaponType;
    public float attackSpeed;
    public int usePower;
}
