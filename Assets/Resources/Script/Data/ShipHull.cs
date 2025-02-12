using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipHullData", menuName = "Ship/ShipHullData")]
public class ShipHull : DefaultShipPart
{
    public string hullName;
    public int hulltHp;
    public ShipClass shipClass;
    public Size size;
    public int cost;
}
