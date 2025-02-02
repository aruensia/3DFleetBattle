using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text shipType;
    public Text head;
    public Text body;
    public Text tail;

    public Text[] SubData;

    Player Players;

    void Start()
    {
        Players = Manager.Instance.PlayerMgr;
        SetUnitInfo();
        

    }

    void SetUnitInfo()
    {
        SubData[0].text = "유닛 수 : " + Players.userFleet[0].ShipCount.ToString();
        SubData[1].text = "사용 전력 : " + Players.userFleet[0].Ship.ShipData.ShipCaps.ToString();
        SubData[2].text = "최대 체력 : " + Players.userFleet[0].Ship.ShipData.MaxHp.ToString();
    }

    //void SetUIText()
    //{
    //    switch(isPlayers.userFleet[0].Ship.ShipClassType)
    //    {
    //        case ShipClassData.Corvette:
    //            shipType.text = "이름 : " + isPlayers.userFleet[0].Ship.Name;
    //            head.text = "선수 : " + isPlayers.userFleet[0].Ship.head.Name;
    //            WeaponList[0].text = "이름 : " + isPlayers.userFleet[0].Ship.head.PartArr[0].Name;
    //            WeaponList[1].text = "공격력 : " + isPlayers.userFleet[0].Ship.head.PartArr[0].Attack;
    //            WeaponList[2].text = "사용전력 : " + isPlayers.userFleet[0].Ship.head.PartArr[0].UseCap;
    //
    //            body.text = "선체 : " + isPlayers.userFleet[0].Ship.body.Name;
    //            tail.text = "선미 : " + isPlayers.userFleet[0].Ship.tail.Name;
    //            break;
    //
    //        case ShipClassData.Frigate:
    //            shipType.text = isPlayers.userFleet[0].Ship.Name;
    //            break;
    //
    //    }
    //}
}
