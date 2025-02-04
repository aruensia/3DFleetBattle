using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShip
{
    public ShipHull ShipHull { get; set; }

    public ShipHead Head { get; set; }
    public ShipBody Body { get; set; }
    public ShipTail Tail { get; set; }

    bool BuildOn = false;

    public int TotalHp => ShipHull != null ? (ShipHull.defaultHp + Head.headHp + Body.headHp + Tail.headHp) : 0;
    public int TotalDamage => Head.weapons.Count > 0 ? TotalWeaponCalculate() : 0;
    public int MaxReactor => Body.reactor.reactorPower > 0 ? ReacotrPowerCalculate() : 0;

    int TotalWeaponCalculate()
    {
        int damage = 0;

        foreach (Weapon i in Head.weapons)
        {
            damage += i.damage;
        }
        foreach (Weapon i in Body.weapons)
        {
            damage += i.damage;
        }
        foreach (Weapon i in Tail.weapons)
        {
            damage += i.damage;
        }

        return damage;
    }

    int ReacotrPowerCalculate()
    {
        int power = 0;

        foreach (Weapon i in Head.weapons)
        {
            power += i.usePower;
        }

        foreach (Weapon i in Body.weapons)
        {
            power += i.usePower;
        }

        foreach (Weapon i in Tail.weapons)
        {
            power += i.usePower;
        }

        if (Body.reactor.reactorPower >= power)
        {
            BuildOn = true;
        }

        if (Body.reactor.reactorPower < power)
        {
            BuildOn = false;
        }

        return power;
    }
}
