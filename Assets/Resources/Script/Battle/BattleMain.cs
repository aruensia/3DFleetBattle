using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMain : MonoBehaviour
{
    public bool playerEngage = false;
    PlayerInfo playerInfo;
    public float BattleGroupWaitMoveSpeed = 10f;
    public GameObject PlayerSpawnObject;
    public GameObject playerBattleGroup;
    public bool ShipSettingOn = false;


    private void Start()
    {
        playerInfo = GameObject.Find("DataManager").GetComponent<PlayerInfo>();
        PlayerShipInstantiate();
    }

    void PlayerShipInstantiate()
    {
        int count = 0;
        foreach(var tempship in DataManager.Instance.playerInfo.MyShips)
        {
            Debug.Log(tempship.shipHull.name);
            Debug.Log(tempship.shiphead.name);
            Debug.Log(tempship.shipBody.name);
            Debug.Log(tempship.shipTail.name);
            GameObject instanships = Instantiate(tempship.shipHull.shipModel, PlayerSpawnObject.transform);
            instanships.transform.Translate(transform.position.x + count, 0, 0);

            switch(tempship.shipHull.shipClass)
            {
                case ShipClass.Corvette:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(0));
                    break;

                case ShipClass.Frigate:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(1));
                    break;

                case ShipClass.Destroyer:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(2));
                    break;

                case ShipClass.Cruiser:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(3));
                    break;

                case ShipClass.Battleship:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(4));
                    break;

                case ShipClass.AircraftCarrier:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(5));
                    break;

            }
            count += 15;
        }

        ShipSettingOn = true;
    }
}
