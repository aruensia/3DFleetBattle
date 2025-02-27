using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public ShipHull shipHull;
    public ShipHead shiphead;
    public ShipBody shipBody;
    public ShipTail shipTail;

    public int hp;
    public int speed;
    public int usecap;
    public int cost;

    GameObject useWeaponTarget;

    public void EngageMove()
    {
        switch(shipHull.shipClass)
        {
            case ShipClass.Corvette:
                break;

            case ShipClass.Frigate:
                break;

            case ShipClass.Destroyer:
                break;

            case ShipClass.Cruiser:
                break;

            case ShipClass.Battleship:
                break;

            case ShipClass.AircraftCarrier:
                break;
        }
    }

    public void SearchTarget()
    {
        switch (shipHull.shipClass)
        {
            case ShipClass.Corvette:
                break;

            case ShipClass.Frigate:
                break;

            case ShipClass.Destroyer:
                break;

            case ShipClass.Cruiser:
                break;

            case ShipClass.Battleship:
                break;

            case ShipClass.AircraftCarrier:
                break;
        }

    }

    public void WeaponFire()
    {
        
    }

    public void TakeDamage()
    {

    }


}
