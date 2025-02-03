using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShip : MonoBehaviour
{
    public ShipHull ShipHull;

    public ShipHead Head;
    public ShipBody Body;
    public ShipTail Tail;

    public int TotalHp => ShipHull != null ? (ShipHull.defaultHp + Head.headHp + Body.headHp + Tail.headHp) : 0;
    public int TotalDamage => Head.weapons.Count > 0 ? TotalWeaponCalculate() : 0;




    private void Start()
    {
        Debug.Log(TotalHp);
    }

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

}
