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

    public Weapon isWeapon = new Weapon();
    public ShipPart isShipPart = new ShipPart();
    public Ship isShip = new Ship();
    public Reactor isReactor = new Reactor();
    public Thrusters isThrusters = new Thrusters();

    public TableManager()
    {
        isWeapon.SetWeaponData();
        isShipPart.SetPartData();
        isShip.SetShipValue();
    }
    
    public void SetPlayerShips()
    {
        //Currentplayer.ShipData = isShip.ShipList[10000];
    }
}