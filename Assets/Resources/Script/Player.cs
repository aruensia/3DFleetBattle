using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour // 인게임에 관련된 유저 정보를 담는 곳
{
    int _money;
    public GameObject myships;
    public Ship[] userFleet = new Ship[6];

    public int Money
    {
        get { return _money; }
        private set { _money = value; }
    }

    private void Awake()
    {
        PlayerDafultDataSetting();

        Debug.Log(userFleet[0].Name);
    }

    private void Start()
    {
        if (Manager.Instance.GameMgr == null)
            Debug.Log("얘 널이에요");

        TableManager.Instance.Currentplayer = this;

        PlayerDafultDataSetting();
        
    }

    public void PlayerDafultDataSetting()
    {
        userFleet[0] = TableManager.Instance.isShip.ShipList[10000];
        userFleet[0].Name = "초계함";
        userFleet[0].head = TableManager.Instance.isShipPart.HeadPartData[1000];
        userFleet[0].body = TableManager.Instance.isShipPart.BodyPartData[1100];
        userFleet[0].tail = TableManager.Instance.isShipPart.TailPartData[1200];

        userFleet[0].head.PartArr[0] = TableManager.Instance.isWeapon.WeaponData[2000];
        userFleet[0].head.PartArr[1] = TableManager.Instance.isWeapon.WeaponData[2000];
        userFleet[0].head.PartArr[2] = TableManager.Instance.isWeapon.WeaponData[2000];
    }
}
