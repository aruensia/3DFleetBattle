using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipReactorData", menuName = "Ship/ShipReactorData")]
public class ShipReactor : ScriptableObject
{
    public string reactorName;
    public int reactorPower;
    public ShipClass shipClass;
    public Size size;
    public int cost;
}
