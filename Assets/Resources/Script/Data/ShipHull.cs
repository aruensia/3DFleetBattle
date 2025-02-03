using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass
{
    Corvette =1, Frigate, Destroyer
}

[CreateAssetMenu(fileName = "ShipHullData", menuName = "Ship/ShipHullData")]
public class ShipHull : ScriptableObject
{
    public string hullName;
    public int defaultHp;
    public ShipClass shipClass;

}
