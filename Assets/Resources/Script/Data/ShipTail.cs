using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipTailData", menuName = "Ship/ShipTailData")]
public class ShipTail : ScriptableObject
{
    public string tailName;
    public int tailHp;
    public List<Weapon> weapons = new List<Weapon>();
    public ShipThruster thruster;
    public List<UtilityData> utility = new List<UtilityData>();
    public ShipClass shipClass;
    public Size size;
    public int cost;



    public bool AddWeapon(Weapon weapon)
    {
        if (size != weapon.size)
        {
            Debug.Log("사이즈가 달라 장착 안됌");
            return false;
        }

        weapons.Add(weapon);
        Debug.Log(weapon.name + "이 장착이 됌");
        return true;
    }

    public bool AddUtility(UtilityData Utility)
    {
        if (size != Utility.size)
        {
            Debug.Log("사이즈가 달라 장착 안됌");
            return false;
        }

        utility.Add(Utility);
        Debug.Log(Utility.name + "이 장착이 됌");
        return true;
    }


}