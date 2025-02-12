using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShipThrusterData", menuName = "Ship/ShipThrusterData")]
public class ShipThruster : DefaultShipPart
{
    public string thrusterName;
    public float thrusterSpeed;
    public int usePower;
}
