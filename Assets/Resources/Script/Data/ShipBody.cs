using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipBodyData", menuName = "Ship/ShipBodyData")]
public class ShipBody : ScriptableObject
{
    public string bodyName;
    public int bodyHp;
    public List<Weapon> weapons = new List<Weapon>();
    public ShipReactor reactor;
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
        Debug.Log(weapon + "이 장착이 됌");
        return true;
    }

}
