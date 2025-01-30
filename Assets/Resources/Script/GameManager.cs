using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{       
    public bool IsGameStart { get; private set; }

    public GameManager()
    {
        IsGameStart = true;
    }

    public GameManager(Ship ship, Head head, Body body, Tail tail, Weapon weapon)
    {
        
    }

    public void PlayerDafultDataSetting()
    {
        Ship DefaultShip = TableManager.Instance.isShip;
        DefaultShip.Name = "√ ∞Ë«‘";
        DefaultShip.head = TableManager.Instance.isShipPart.HeadPartData[1000];
        DefaultShip.body = TableManager.Instance.isShipPart.BodyPartData[1100];
        DefaultShip.tail = TableManager.Instance.isShipPart.TailPartData[1200];

        DefaultShip.head.PartArr[0] = TableManager.Instance.isWeapon.WeaponData[2000];
        DefaultShip.head.PartArr[1] = TableManager.Instance.isWeapon.WeaponData[2000];
        DefaultShip.head.PartArr[2] = TableManager.Instance.isWeapon.WeaponData[2000];
    }
}
