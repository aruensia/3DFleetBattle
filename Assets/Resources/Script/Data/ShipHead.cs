using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipHeadData", menuName = "Ship/ShipHeadData")]
public class ShipHead : ScriptableObject
{
    public string headName;
    public int headHp;
    public List<Weapon> weapons = new List<Weapon>();
    public List<Utility> utility = new List<Utility>();
    public ShipClass shipClass;
    public Size size;
    public int cost;

}
