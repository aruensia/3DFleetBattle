using UnityEngine;

public class TableManager
{
    private static TableManager instance;
    public static TableManager Instance
    {
        get
        {
            if (instance == null)
                instance = new TableManager();            

            return instance;
        }
    }

    public Weapon isWeapon = new Weapon();
    public ShipPart isShipPart = new ShipPart();
    public Ship isShip = new Ship();

    public TableManager()
    {
        isWeapon.SetWeaponData();
        isShipPart.SetPartData();
        isShip.SetShipValue();
    }
}