using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipContainer : MonoBehaviour
{
    public ShipHull shipHull;
    public ShipHead shiphead;
    public ShipBody shipBody;
    public ShipTail shipTail;

    public int hp;
    public int armor;
    public int shield;

    public int speed;
    public int usecap;
    public int cost;
}
