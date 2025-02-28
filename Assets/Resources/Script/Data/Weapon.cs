using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ShipData/WeaponData")]
public class Weapon : DefaultShipPart
{
    public int damage;
    public int attackRange;
    public WeaponType weaponType;
    public float attackMinCool;
    public float attackMaxCool;
    public float attackLoadCount;
    public bool weaponFireOn;
    public bool equipOn = true;
    public int usePower;
}
