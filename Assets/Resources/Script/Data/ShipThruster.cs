using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShipThrusterData", menuName = "ShipData/ShipThrusterData")]
public class ShipThruster : DefaultShipPart
{
    public string thrusterName;
    public float thrusterSpeed;
    public int usePower;
}
