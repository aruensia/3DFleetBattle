using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipHeadData", menuName = "Ship/ShipHeadData")]
public class ShipHead : DefaultShipPart
{
    public List<Weapon> weapons = new List<Weapon>();
    public List<UtilityData> utility = new List<UtilityData>();
}
