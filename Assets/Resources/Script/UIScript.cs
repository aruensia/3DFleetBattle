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

    public Text[] WeaponList;
    //public Text[] BodyWeaponList;
    //public Text[] TailWeaponList;


    Player isPlayers;

    void Start()
    {
        isPlayers = GameObject.Find("Player")?.GetComponent<Player>();

        SetUIText();
    }

    void SetUIText()
    {
        switch(isPlayers.userFleet[0].ShipClassType)
        {
            case ShipClassData.Corvette:
                shipType.text = "이름 : " + isPlayers.userFleet[0].Name;
                head.text = "선수 : " + isPlayers.userFleet[0].head.Name;
                WeaponList[0].text = "이름 : " + isPlayers.userFleet[0].head.PartArr[0].Name;
                WeaponList[1].text = "공격력 : " + isPlayers.userFleet[0].head.PartArr[0].Attack;
                WeaponList[2].text = "사용전력 : " + isPlayers.userFleet[0].head.PartArr[0].UseCap;

                body.text = "선체 : " + isPlayers.userFleet[0].body.Name;
                tail.text = "선미 : " + isPlayers.userFleet[0].tail.Name;
                break;

            case ShipClassData.Frigate:
                shipType.text = isPlayers.userFleet[0].Name;
                break;

        }
    }

    private void OnDestroy()
    {
        //Manager.Instance.GameMgr.OnShowGameDataSet -= SetUIText;
    }
}
