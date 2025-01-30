using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum WeaponType
{
    Missile = 1, Cannon, Laser, Dron, None
}

public enum ShipClassData
{
    Corvette = 1, Frigate, Destroyer, Cruiser, Battleship, AircraftCarrier, None
}

public class Weapon
{
    int _index;
    string _name;
    int _attack;
    int _useCap;
    WeaponType _weaponType;

    public int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    public int UseCap
    { 
        get { return _useCap; }
        set { _useCap = value; }
    }

    public WeaponType WeaponType
    {
        get { return _weaponType; }
        set { _weaponType = value; }
    }

    public Weapon()
    {

    }

    public Weapon(int Index, string name, int attack, int usecap, WeaponType weapontype)
    {
        this.Name = name;
        this.Attack = attack;
        this.UseCap = usecap;
        this.WeaponType = weapontype;
    }

    public Dictionary<int, Weapon> WeaponData = new Dictionary<int, Weapon>();

    public void SetWeaponData()
    {
        Weapon MassWeapon1 = new Weapon(2000,"매스 드라이버", 5, 3, WeaponType.Cannon);
        Weapon MassWeapon2 = new Weapon(2001, "매스 드라이버", 5, 3, WeaponType.Cannon);
        Weapon MassWeapon3 = new Weapon(2002, "매스 드라이버", 5, 3, WeaponType.Cannon);

        WeaponData.Add(2000, MassWeapon1);
        WeaponData.Add(2001, MassWeapon2);
        WeaponData.Add(2002, MassWeapon3);
    }
}

public class Ship
{
    string _name;
    int _maxHp;
    int _shipCaps;
    int _fleetCost;
    int _shipCount;
    ShipClassData _shipClassType;

    public Head head;
    public Body body;
    public Tail tail;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int MaxHp
    {
        get { return _maxHp; }
        set { _maxHp = value; }
    }

    public int ShipCaps
    {
        get { return _shipCaps; }
        set { _shipCaps = value; }
    }

    public int FleetCost
    {
        get { return _fleetCost; }
        set { _fleetCost = value; } 
    }

    public int ShipCount
    {
        get { return _shipCount; }
        set { _shipCount = value; }
    }

    public ShipClassData ShipClassType
    {
        get { return _shipClassType; }
        set { _shipClassType = value; }
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetHead(Head isHead)
    {
        head = isHead;
    }

    public void SetBody(Body isBody)
    {
        body = isBody;
    }

    public void SetTail(Tail isTail)
    {
        tail = isTail;
    }

    public int SetMaxHp(int Hhp, int Bhp, int Thp)
    {
        int setmaxHp = Hhp + Bhp + Thp;
        return setmaxHp;
    }

    public Ship()
    {

    }

    public Ship(string name, int maxhp, int shipcaps, int fleetcost, ShipClassData shipClassData, int shipcount)
    {
        this.Name = name;
        this.MaxHp = maxhp; 
        this.ShipCaps = shipcaps;
        this.FleetCost = fleetcost;
        this.ShipClassType = shipClassData;
        this.ShipCount = shipcount;
    }

    public Dictionary<int, Ship> ShipList = new Dictionary<int, Ship>();

    public void SetShipValue()
    {
        Ship Ship01 = new Ship("Corvette", 50, 40, 2, ShipClassData.Corvette, 5);

        ShipList.Add(10000, Ship01);
    }
}

public class Head
{
    int _index;
    string _name;
    ShipClassData _shiptype;
    int _hp;
    Weapon[] _partArr;

    public int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public ShipClassData Shiptype
    {
        get { return _shiptype; }
        set { _shiptype = value; }
    }

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public Weapon[] PartArr
    {
        get { return _partArr; }
        set { _partArr = value; }
    }

    public Head()
    {

    }

    public Head(int index, string name, ShipClassData shiptype, int hp, Weapon[] partarr)
    {
        this.Index = index;
        this.Name = name;
        this.Shiptype = shiptype;
        this.HP = hp;
        this.PartArr = partarr;
    }
}

public class Body
{
    int _index;
    string _name;
    ShipClassData _shiptype;
    int _hp;
    Weapon[] _partArr;

    public int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public ShipClassData Shiptype
    {
        get { return _shiptype; }
        set { _shiptype = value; }
    }

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public Weapon[] PartArr
    {
        get { return _partArr; }
        set { _partArr = value; }
    }

    public Body()
    {

    }

    public Body(int index, string name, ShipClassData shiptype, int hp, Weapon[] partarr)
    {
        this.Index = index;
        this.Name = name;
        this.Shiptype = shiptype;
        this.HP = hp;
        this.PartArr = partarr;
    }
}

public class Tail
{
    int _index;
    string _name;
    ShipClassData _shiptype;
    int _hp;
    Weapon[] _partArr;

    public int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public ShipClassData Shiptype
    {
        get { return _shiptype; }
        set { _shiptype = value; }
    }

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public Weapon[] PartArr
    {
        get { return _partArr; }
        set { _partArr = value; }
    }

    public Tail()
    {

    }

    public Tail(int index, string name, ShipClassData shiptype, int hp, Weapon[] partarr)
    {
        this.Index = index;
        this.Name = name;
        this.Shiptype = shiptype;
        this.HP = hp;
        this.PartArr = partarr;
    }
}

public class ShipPart
{
    Head head = new Head();
    Body body = new Body();
    Tail tail = new Tail();

    public Dictionary<int, Head> HeadPartData = new Dictionary<int, Head>();
    public Dictionary<int, Body> BodyPartData = new Dictionary<int, Body>();
    public Dictionary<int, Tail> TailPartData = new Dictionary<int, Tail>();

    public void SetPartData()
    {
        Head HeadPart1 = new Head(1000, "기본형 선수", ShipClassData.Corvette, 20, new Weapon[3]);
        Head HeadPart2 = new Head(1001, "기습형 선수", ShipClassData.Corvette, 15, new Weapon[1]);
        Head HeadPart3 = new Head(1002, "방어형 선수", ShipClassData.Corvette, 25, new Weapon[3]);
        Body BodyPart1 = new Body(1100, "기본형 선체", ShipClassData.Corvette, 100, new Weapon[3]);
        Body BodyPart2 = new Body(1101, "기습형 선체", ShipClassData.Corvette, 80, new Weapon[2]);
        Body BodyPart3 = new Body(1102, "방어형 선체", ShipClassData.Corvette, 130, new Weapon[4]);
        Tail TailPart1 = new Tail(1200, "기본형 선미", ShipClassData.Corvette, 50, new Weapon[2]);
        Tail TailPart2 = new Tail(1201, "기습형 선미", ShipClassData.Corvette, 30, new Weapon[2]);
        Tail TailPart3 = new Tail(1202, "방어형 선미", ShipClassData.Corvette, 65, new Weapon[2]);


        //-------------------------------------------------------------
        HeadPartData.Add(1000, HeadPart1);
        HeadPartData.Add(1001, HeadPart2);
        HeadPartData.Add(1002, HeadPart3);
        BodyPartData.Add(1100, BodyPart1);
        BodyPartData.Add(1101, BodyPart2);
        BodyPartData.Add(1102, BodyPart3);
        TailPartData.Add(1200, TailPart1);
        TailPartData.Add(1201, TailPart2);
        TailPartData.Add(1202, TailPart3);
    }
}