using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FleetData
{
    public InstanceShip Ship { get; set; }
    public int ShipCount { get; set; }

    public FleetData(InstanceShip ship, int shipCount)
    {
        this.Ship = ship;
        this.ShipCount = shipCount;
    }
}

    public class Player : MonoBehaviour // 인게임에 관련된 유저 정보를 담는 곳
{
    public List<FleetData> userFleet = new List<FleetData>();
    public Ship ShipData { get; set; }
    public GameObject DefaultShip;

    int _money;
 

    public int Money
    {
        get { return _money; }
        private set { _money = value; }
    }

    private void Start()
    {
        if (Manager.Instance.GameMgr == null)
            Debug.Log("얘 널이에요");

        TableManager.Instance.SetPlayerShips();
        
        PlayerDafultDataSetting();
        SetShips();
    }

    public void PlayerDafultDataSetting()
    {
        ShipData = TableManager.Instance.Ship.ShipList[10000];
        ShipData.head = TableManager.Instance.ShipPart.HeadPartData[1000];
        ShipData.body = TableManager.Instance.ShipPart.BodyPartData[1100];
        ShipData.tail = TableManager.Instance.ShipPart.TailPartData[1200];
        ShipData.head.PartArr[0] = TableManager.Instance.Weapon.WeaponData[2000];
        ShipData.head.PartArr[1] = TableManager.Instance.Weapon.WeaponData[2000];
        ShipData.body.Reactor = TableManager.Instance.ShipPart.ReactorPartData[1300];
        ShipData.tail.Thrusters = TableManager.Instance.ShipPart.ThrusterPartData[1400];
    }

    void SetShips()
    {
        DefaultShip = GameObject.Find("Player").GetComponent<Player>().DefaultShip;
        InstanceShip SetShipInfo = DefaultShip.GetComponent<InstanceShip>();
        SetShipInfo.ShipData = ShipData;
        userFleet.Add(new FleetData(SetShipInfo, 5));

        for ( int i = 0; i < userFleet[0].ShipCount; i++ )
        {
            Instantiate(DefaultShip);
        }
        Debug.Log(userFleet[0].ShipCount);
    }
}
