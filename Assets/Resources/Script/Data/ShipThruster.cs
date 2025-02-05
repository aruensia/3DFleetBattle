using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShipThrusterData", menuName = "Ship/ShipThrusterData")]
public class ShipThruster : ScriptableObject
{
    public string thrusterName;
    public float thrusterSpeed;
    public int usePower;
    public ShipClass shipClass;
    public Size size;
    public int cost;
}
