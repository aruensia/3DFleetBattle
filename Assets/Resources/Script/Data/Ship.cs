using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    ShipHull shipHull;
    ShipHead shiphead;
    ShipBody shipBody;
    ShipTail shipTail;

    int hp;
    int speed;
    int usecap;
    int reactor;

    //함선의 총 체력을 구함
    private int MaxHp () => shipHull.defaultHp + shiphead.headHp + shipBody.headHp + shipTail.headHp;

    //함선의 총 방어력을 구함
    private int maxdefence;

    //함선의 무기 총 개수를 구함
    private int WeaponCount () => shiphead.weapons.Count + shipBody.weapons.Count + shipTail.weapons.Count;




}
