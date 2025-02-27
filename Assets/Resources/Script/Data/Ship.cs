using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum state
{
    Idle, Move, Attack, Die
}

public class Ship
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

    public void TakeDamage(int damage)
    {
        if( shield > 0)
        {
            shield -= damage;

            if (shield <= 0)
            {
                if( armor > 0)
                {
                    armor -= damage;

                    if ( armor <= 0)
                    { 
                        hp -= damage;

                        if ( hp <= 0)
                        {
                            
                        }
                    }
                }
            }
        }
    }


    public void CheckState(bool engage)
    {

    }

}
