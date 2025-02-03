using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FleetData
{
    public InstanceShip Ship { get; private set; }
    public int ShipCount { get; private set; }

    public FleetData(InstanceShip ship, int shipCount)
    {
        this.Ship = ship;
        this.ShipCount = shipCount;
    }
}

public class Player : MonoBehaviour // 인게임에 관련된 유저 정보를 담는 곳
{
    public List<FleetData> userFleet = new List<FleetData>(); // 실재로 유저가 들고 싸울 함대 List
    public List<Ship> ShipData = new List<Ship>(); // 배 설정을 임시로 저장할 배열
    public GameObject[] DefaultShip;  // 실제로 생성한 함선 게임오브젝트가 생성될 부모 게임오브젝트
    InstanceShip[] tempShipData = new InstanceShip[6];

    int _money;

    public int Money
    {
        get { return _money; }
        private set { _money = value; }
    }


    private void Start()
    {
        Manager.Instance.PlayerMgr = this;
        if (Manager.Instance.GameMgr == null)
            Debug.Log("얘 널이에요");
        DefaultShipDataSetUp();
        SetUserFleetArr();

        PlayerDefaultDataSetting();
        AddFirstUserFleet(5);
    }

    void DefaultShipDataSetUp()
    {
        for( int i = 0; i < 6;  i++)
        {
            ShipData.Add(TableManager.Instance.Ship.ShipList[19999]);
        }
    }

    void SetUserFleetArr()
    {
        for( int i = 0; i < 6;  i++)
        {
            tempShipData[i] = DefaultShip[i].GetComponent<InstanceShip>();
            tempShipData[i].ShipData = this.ShipData[i];
            userFleet.Add(new FleetData(tempShipData[i], 0));
        }
    }

    public void PlayerDefaultDataSetting()
    {
        ShipData[0] = TableManager.Instance.Ship.ShipList[10000];
        ShipData[0].head = TableManager.Instance.ShipPart.HeadPartData[1000];
        ShipData[0].body = TableManager.Instance.ShipPart.BodyPartData[1100];
        ShipData[0].tail = TableManager.Instance.ShipPart.TailPartData[1200];
        ShipData[0].head.PartArr[0] = TableManager.Instance.Weapon.WeaponData[2000];
        ShipData[0].head.PartArr[1] = TableManager.Instance.Weapon.WeaponData[2000];
        ShipData[0].body.Reactor = TableManager.Instance.ShipPart.ReactorPartData[1300];
        ShipData[0].tail.Thrusters = TableManager.Instance.ShipPart.ThrusterPartData[1400];

        ShipData[0].MaxHp = AddMaxHp();
        ShipData[0].ShipCaps = AddUseCap();

        int AddUseCap()
        {
            int cap = 0;

            for (int i = 0; i < ShipData[0].head.PartArr.Length; i++)
            {
                cap = cap + ShipData[0].head.PartArr[i].UseCap;
            }

            for (int i = 0; i < ShipData[0].body.PartArr.Length; i++)
            {
                cap = cap + ShipData[0].body.PartArr[i].UseCap;
            }

            for (int i = 0; i < ShipData[0].tail.PartArr.Length; i++)
            {
                cap = cap + ShipData[0].tail.PartArr[i].UseCap;
            }

            return cap;
        }

        int AddMaxHp()
        {
            for (int i = 0; i < ShipData[0].head.PartArr.Length; i++)
            {
                ShipData[0].MaxHp = ShipData[0].MaxHp + ShipData[0].head.HP;
            }

            for (int i = 0; i < ShipData[0].body.PartArr.Length; i++)
            {
                ShipData[0].MaxHp = ShipData[0].MaxHp + ShipData[0].body.HP;
            }

            for (int i = 0; i < ShipData[0].tail.PartArr.Length; i++)
            {
                ShipData[0].MaxHp = ShipData[0].MaxHp + ShipData[0].tail.HP;
            }

            return ShipData[0].MaxHp;
        }
    }

    void AddFirstUserFleet(int shipCount) //최초 유저가 보유한 함대를 세팅.
    {
        tempShipData[0] = DefaultShip[0].GetComponent<InstanceShip>();
        tempShipData[0].ShipData = this.ShipData[0];
        tempShipData[0].ShipData.ShipCount = shipCount;

        userFleet[0] = new FleetData(tempShipData[0],shipCount);
        for (int i = 0; i < shipCount; i++)
        {
            Instantiate(DefaultShip[0], this.transform.GetChild(0));
            tempShipData[0].transform.Translate(3, 0, 0);
        }
    }
}

