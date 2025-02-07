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

    //함선의 총 체력을 구함
    //public int MaxHp () => shipHull.defaultHp + shiphead.headHp + shipBody.headHp + shipTail.headHp;

    //함선의 총 방어력을 구함
    //public int maxdefence;

    //함선의 무기 총 개수를 구함
    //public int WeaponCount () => shiphead.weapons.Count + shipBody.weapons.Count + shipTail.weapons.Count;

    public int GetMaxHp()
    {
        hp = shipHull.defaultHp + shiphead.headHp + shipBody.bodyHp + shipTail.tailHp;

        return hp;
    }
}
