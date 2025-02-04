using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipTailData", menuName = "Ship/ShipTailData")]
public class ShipTail : ScriptableObject
{
    public string headName;
    public int headHp;
    public List<Weapon> weapons = new List<Weapon>();
    public ShipThruster thruster;
}