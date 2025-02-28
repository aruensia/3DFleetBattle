using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipBodyData", menuName = "ShipData/ShipBodyData")]
public class ShipBody : DefaultShipPart
{

    public List<Weapon> weapons = new List<Weapon>();
    public ShipReactor reactor;
    public List<UtilityData> utility = new List<UtilityData>();
}
