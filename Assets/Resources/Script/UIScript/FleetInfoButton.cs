using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text UnitCount;
    public Text UseCap;
    public Text MaxHp;
    public Text Defence;

    public Text[] SubData;

    Player Players;


    public void SetUnitInfo(int name)
    {
        Players = Manager.Instance.PlayerMgr;

        switch (name)
        {

            case 0:
                if (Players.userFleet[0] == null)
                {
                    SubData[0].text = "유닛 수 : ";
                    SubData[1].text = "사용 전력 : ";
                    SubData[2].text = "최대 체력 : ";
                }
                else
                {
                    SubData[0].text = "유닛 수 : " + Players.userFleet[0].ShipCount.ToString();
                    Debug.Log(Players.userFleet[0].ShipCount);
                    SubData[1].text = "사용 전력 : " + Players.userFleet[0].Ship.ShipData.ShipCaps.ToString();
                    SubData[2].text = "최대 체력 : " + Players.userFleet[0].Ship.ShipData.MaxHp.ToString();
                }
                break;

            case 1:
                if (Players.userFleet[1] == null)
                {
                    SubData[0].text = "유닛 수 : ";
                    SubData[1].text = "사용 전력 : ";   
                    SubData[2].text = "최대 체력 : ";
                }
                else
                {
                    SubData[0].text = "유닛 수 : " + Players.userFleet[1].ShipCount.ToString();
                    SubData[1].text = "사용 전력 : " + Players.userFleet[1].Ship.ShipData.ShipCaps.ToString();
                    SubData[2].text = "최대 체력 : " + Players.userFleet[1].Ship.ShipData.MaxHp.ToString();
                }
                break;

            case 2:
                if (Players.userFleet[1] == null)
                {
                    SubData[0].text = "유닛 수 : ";
                    SubData[1].text = "사용 전력 : ";
                    SubData[2].text = "최대 체력 : ";
                }
                else
                {
                    SubData[0].text = "유닛 수 : " + Players.userFleet[2].ShipCount.ToString();
                    SubData[1].text = "사용 전력 : " + Players.userFleet[2].Ship.ShipData.ShipCaps.ToString();
                    SubData[2].text = "최대 체력 : " + Players.userFleet[2].Ship.ShipData.MaxHp.ToString();
                }
                break;

            case 3:
                if (Players.userFleet[1] == null)
                {
                    SubData[0].text = "유닛 수 : ";
                    SubData[1].text = "사용 전력 : ";
                    SubData[2].text = "최대 체력 : ";
                }
                else
                {
                    SubData[0].text = "유닛 수 : " + Players.userFleet[3].ShipCount.ToString();
                    SubData[1].text = "사용 전력 : " + Players.userFleet[3].Ship.ShipData.ShipCaps.ToString();
                    SubData[2].text = "최대 체력 : " + Players.userFleet[3].Ship.ShipData.MaxHp.ToString();
                }
                break;

            case 4:
                if (Players.userFleet[1] == null)
                {
                    SubData[0].text = "유닛 수 : ";
                    SubData[1].text = "사용 전력 : ";
                    SubData[2].text = "최대 체력 : ";
                }
                else
                {
                    SubData[0].text = "유닛 수 : " + Players.userFleet[4].ShipCount.ToString();
                    SubData[1].text = "사용 전력 : " + Players.userFleet[4].Ship.ShipData.ShipCaps.ToString();
                    SubData[2].text = "최대 체력 : " + Players.userFleet[4].Ship.ShipData.MaxHp.ToString();
                }
                break;

            case 5:
                if (Players.userFleet[1] == null)
                {
                    SubData[0].text = "유닛 수 : ";
                    SubData[1].text = "사용 전력 : ";
                    SubData[2].text = "최대 체력 : ";
                }
                else
                {
                    SubData[0].text = "유닛 수 : " + Players.userFleet[5].ShipCount.ToString();
                    SubData[1].text = "사용 전력 : " + Players.userFleet[5].Ship.ShipData.ShipCaps.ToString();
                    SubData[2].text = "최대 체력 : " + Players.userFleet[5].Ship.ShipData.MaxHp.ToString();
                }
                break;
        }
    }


}
