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
    GameObject ships;

    int _money;
 

    public int Money
    {
        get { return _money; }
        private set { _money = value; }
    }

    private void Awake()
    {

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
        ShipData = TableManager.Instance.isShip.ShipList[10000];
        //userFleet.Add(new FleetData(ShipData,5);

        //userFleet.Add(new FleetData(TableManager.Instance.InstanceShip.ShipData.ShipList[10000], 5));
        ShipData.head = TableManager.Instance.isShipPart.HeadPartData[1000];
        ShipData.body = TableManager.Instance.isShipPart.BodyPartData[1100];
        ShipData.tail = TableManager.Instance.isShipPart.TailPartData[1200];
        ShipData.head.PartArr[0] = TableManager.Instance.isWeapon.WeaponData[2000];
        ShipData.head.PartArr[1] = TableManager.Instance.isWeapon.WeaponData[2000];
        ShipData.body.Reactor = TableManager.Instance.isShipPart.ReactorPartData[1300];
        ShipData.tail.Thrusters = TableManager.Instance.isShipPart.ThrusterPartData[1400];
    }

    void SetShips()
    {
        GameObject asd = Instantiate(GameObject.Find("Clone"));
        InstanceShip Setship = asd.GetComponent<InstanceShip>();
        Setship.ShipData = ShipData;
        userFleet.Add(new FleetData(Setship, 5));
        Debug.Log(Setship.ShipData.Name);
        Debug.Log(userFleet[0].ShipCount);

    }

    private void OnDisable()
    {
        //TableManager.Instance.Currentplayer = null;
    }
}
