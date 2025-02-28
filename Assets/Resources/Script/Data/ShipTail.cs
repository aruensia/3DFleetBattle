using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipTailData", menuName = "ShipData/ShipTailData")]
public class ShipTail : DefaultShipPart
{

    public List<Weapon> weapons = new List<Weapon>();
    public ShipThruster thruster;
    public List<UtilityData> utility = new List<UtilityData>();

}