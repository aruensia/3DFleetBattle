using UnityEngine;

public class TableManager
{
    private static TableManager instance;

    public InstanceShip InstanceShip;

    public static TableManager Instance
    {
        get
        {
            if (instance == null)
                instance = new TableManager();            

            return instance;
        }
    }

    public Weapon Weapon = new();
    public ShipPart ShipPart = new();
    public Ship Ship = new();
    public Reactor Reactor = new();
    public Thrusters Thrusters = new();

    public TableManager()
    {
        Weapon.SetWeaponData();
        ShipPart.SetPartData();
        Ship.SetShipValue();
    }
}