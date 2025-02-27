using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMain : MonoBehaviour
{
    public bool playerEngage = false;
    PlayerFleetAI playerfleet;
    
    public float BattleGroupWaitMoveSpeed = 10f;
    public GameObject PlayerSpawnObject;
    public GameObject playerBattleGroup;
    public bool ShipSettingOn = false;

    List<GameObject> unitGroup = new List<GameObject>();
    

    private void Start()
    {
        playerfleet = GameObject.Find("PlayerFleet").GetComponent<PlayerFleetAI>();
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
            instanships.AddComponent<ShipContainer>();
            instanships.transform.Translate(transform.position.x + count, 0, 0);

            switch(tempship.shipHull.shipClass)
            {
                case ShipClass.Corvette:

                    if(count == 10)
                    {
                        playerfleet.corvetteGroup.Add(unitGroup);
                        unitGroup.Clear();
                        count = 0;
                    }

                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(0));

                    instanships.GetComponent<ShipContainer>().shipHull = tempship.shipHull;
                    instanships.GetComponent<ShipContainer>().shiphead = tempship.shiphead;
                    instanships.GetComponent<ShipContainer>().shipBody = tempship.shipBody;
                    instanships.GetComponent<ShipContainer>().shipTail = tempship.shipTail;
                    instanships.GetComponent<ShipContainer>().hp = tempship.hp;
                    instanships.GetComponent<ShipContainer>().armor = tempship.armor;
                    instanships.GetComponent<ShipContainer>().shield = tempship.shield;
                    instanships.GetComponent<ShipContainer>().cost = tempship.cost;
                    instanships.GetComponent<ShipContainer>().speed = tempship.speed;

                    unitGroup.Add(instanships);
                    count++;
                    break;

                case ShipClass.Frigate:

                    if (count == 8)
                    {
                        playerfleet.corvetteGroup.Add(unitGroup);
                        unitGroup.Clear();
                        count = 0;
                    }

                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(1));
                    unitGroup.Add(instanships);
                    count++;
                    break;

                case ShipClass.Destroyer:

                    if (count == 5)
                    {
                        playerfleet.corvetteGroup.Add(unitGroup);
                        unitGroup.Clear();
                        count = 0;
                    }

                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(2));
                    unitGroup.Add(instanships);
                    count++;
                    break;

                case ShipClass.Cruiser:

                    if (count == 3)
                    {
                        playerfleet.corvetteGroup.Add(unitGroup);
                        unitGroup.Clear();
                        count = 0;
                    }

                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(3));
                    unitGroup.Add(instanships);
                    count++;
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
        playerfleet.StartFleetMove();
    }
}
