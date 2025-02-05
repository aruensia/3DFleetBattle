using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipBodyData", menuName = "Ship/ShipBodyData")]
public class ShipBody : ScriptableObject
{
    public string headName;
    public int headHp;
    public List<Weapon> weapons = new List<Weapon>();
    public ShipReactor reactor;
    public List<Utility> utility = new List<Utility>();
    public ShipClass shipClass;
    public Size size;
    public int cost;

}
