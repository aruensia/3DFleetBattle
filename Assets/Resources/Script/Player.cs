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
    public List<Ship> ShipData = new List<Ship>(); // 배 설정을 임시로 저장할 배열
    public GameObject[] DefaultShip;
    

    int _money;
 

    public int Money
    {
        get { return _money; }
        private set { _money = value; }
    }

    private void Awake()
    {
        //Manager.Instance.PlayerMgr = this;
    }

    private void Start()
    {
        DefaultShip[0] = GameObject.Find("Player").GetComponent<Player>().DefaultShip[0];
        if (Manager.Instance.GameMgr == null)
            Debug.Log("얘 널이에요");

        TableManager.Instance.SetPlayerShips();
        
        PlayerDefaultDataSetting();
        SetDefaultShips();
        ResetShipData();
        Manager.Instance.PlayerMgr = this;
    }

    void ResetShipData()
    {
        ShipData[0] = null;
    }

    public void PlayerDefaultDataSetting()
    {

        ShipData.Add(TableManager.Instance.Ship.ShipList[10000]);
        ShipData[0].head = TableManager.Instance.ShipPart.HeadPartData[1000];
        ShipData[0].body = TableManager.Instance.ShipPart.BodyPartData[1100];
        ShipData[0].tail = TableManager.Instance.ShipPart.TailPartData[1200];
        ShipData[0].head.PartArr[0] = TableManager.Instance.Weapon.WeaponData[2000];
        ShipData[0].head.PartArr[1] = TableManager.Instance.Weapon.WeaponData[2000];
        ShipData[0].body.Reactor = TableManager.Instance.ShipPart.ReactorPartData[1300];
        ShipData[0].tail.Thrusters = TableManager.Instance.ShipPart.ThrusterPartData[1400];

        ShipData[0].MaxHp = ShipData[0].head.HP + ShipData[0].body.HP + ShipData[0].tail.HP;

        ShipData[0].ShipCaps = AddUseCap();

        Debug.Log("총 hp는 : " + ShipData[0].MaxHp);
        Debug.Log("사용 Cap은 : " + ShipData[0].ShipCaps);


        int AddUseCap()
        {
            int cap = 0;

            for( int i = 0; i < ShipData[0].head.PartArr.Length; i++ )
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

    }

    void SetDefaultShips()
    {
        InstanceShip SetShipInfo = DefaultShip[0].GetComponent<InstanceShip>();
        SetShipInfo.ShipData = this.ShipData[0];
        userFleet.Add(new FleetData(SetShipInfo, 5));

        for ( int i = 0; i < userFleet[0].ShipCount; i++ )
        {
            Instantiate(DefaultShip[0], this.transform.GetChild(0));
        }
    }
}
