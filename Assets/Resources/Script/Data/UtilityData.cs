using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UtilityData", menuName = "Ship/UtilityData")]
public class UtilityData : ScriptableObject
{
    public string headName;
    public int defence;
    public int shild;
    public Utility utility;
    public ShipClass shipClass;
    public Size size;
    public int cost;
}
