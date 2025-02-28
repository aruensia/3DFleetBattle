using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UtilityData", menuName = "ShipData/UtilityData")]
public class UtilityData : DefaultShipPart
{
    public string utilityName;
    public int defence;
    public int shild;
    public int usePower;
    public Utility utility;
    public float searchRange;
}
