using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UtilityData", menuName = "Ship/UtilityData")]
public class DefaultShipPart : ScriptableObject
{
    public PartType partType;
    public string defaultShipPartName;
    public Sprite iconImage;
    public int defaultShipPartArmor;
    public int defaultShipPartCost;
    public Size defaultShipPartSize;
    public ShipClass defaultShipPartClass;
    public Grade DefaultShipPartGrade;
}
