using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMain : MonoBehaviour
{
    public bool playerContect = false;
    public bool playerEngage = false;
    public bool enemyContect = false;
    public bool enemyEngage = false;
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
        int instantiateDistance = 0;
        foreach(var tempship in DataManager.Instance.playerInfo.MyShips)
        {
            Debug.Log(tempship.shipHull.name);
            Debug.Log(tempship.shiphead.name);
            Debug.Log(tempship.shipBody.name);
            Debug.Log(tempship.shipTail.name);
            GameObject instanships = Instantiate(tempship.shipHull.shipModel, PlayerSpawnObject.transform);
            instanships.AddComponent<Ship>();
            instanships.transform.Translate(transform.position.x + instantiateDistance, 0, 0);

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
                    instanships.GetComponent<Ship>().shipHull = tempship.shipHull;
                    instanships.GetComponent<Ship>().shiphead = tempship.shiphead;
                    instanships.GetComponent<Ship>().shipBody = tempship.shipBody;
                    instanships.GetComponent<Ship>().shipTail = tempship.shipTail;
                    instanships.GetComponent<Ship>().hp = tempship.hp;
                    instanships.GetComponent<Ship>().armor = tempship.armor;
                    instanships.GetComponent<Ship>().shield = tempship.shield;
                    instanships.GetComponent<Ship>().cost = tempship.cost;
                    instanships.GetComponent<Ship>().speed = tempship.speed;
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
                    instanships.GetComponent<Ship>().shipHull = tempship.shipHull;
                    instanships.GetComponent<Ship>().shiphead = tempship.shiphead;
                    instanships.GetComponent<Ship>().shipBody = tempship.shipBody;
                    instanships.GetComponent<Ship>().shipTail = tempship.shipTail;
                    instanships.GetComponent<Ship>().hp = tempship.hp;
                    instanships.GetComponent<Ship>().armor = tempship.armor;
                    instanships.GetComponent<Ship>().shield = tempship.shield;
                    instanships.GetComponent<Ship>().cost = tempship.cost;
                    instanships.GetComponent<Ship>().speed = tempship.speed;
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
                    instanships.GetComponent<Ship>().shipHull = tempship.shipHull;
                    instanships.GetComponent<Ship>().shiphead = tempship.shiphead;
                    instanships.GetComponent<Ship>().shipBody = tempship.shipBody;
                    instanships.GetComponent<Ship>().shipTail = tempship.shipTail;
                    instanships.GetComponent<Ship>().hp = tempship.hp;
                    instanships.GetComponent<Ship>().armor = tempship.armor;
                    instanships.GetComponent<Ship>().shield = tempship.shield;
                    instanships.GetComponent<Ship>().cost = tempship.cost;
                    instanships.GetComponent<Ship>().speed = tempship.speed;
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
                    instanships.GetComponent<Ship>().shipHull = tempship.shipHull;
                    instanships.GetComponent<Ship>().shiphead = tempship.shiphead;
                    instanships.GetComponent<Ship>().shipBody = tempship.shipBody;
                    instanships.GetComponent<Ship>().shipTail = tempship.shipTail;
                    instanships.GetComponent<Ship>().hp = tempship.hp;
                    instanships.GetComponent<Ship>().armor = tempship.armor;
                    instanships.GetComponent<Ship>().shield = tempship.shield;
                    instanships.GetComponent<Ship>().cost = tempship.cost;
                    instanships.GetComponent<Ship>().speed = tempship.speed;
                    unitGroup.Add(instanships);
                    count++;
                    break;

                case ShipClass.Battleship:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(4));
                    instanships.GetComponent<Ship>().shipHull = tempship.shipHull;
                    instanships.GetComponent<Ship>().shiphead = tempship.shiphead;
                    instanships.GetComponent<Ship>().shipBody = tempship.shipBody;
                    instanships.GetComponent<Ship>().shipTail = tempship.shipTail;
                    instanships.GetComponent<Ship>().hp = tempship.hp;
                    instanships.GetComponent<Ship>().armor = tempship.armor;
                    instanships.GetComponent<Ship>().shield = tempship.shield;
                    instanships.GetComponent<Ship>().cost = tempship.cost;
                    instanships.GetComponent<Ship>().speed = tempship.speed;
                    break;

                case ShipClass.AircraftCarrier:
                    instanships.transform.SetParent(playerBattleGroup.transform.GetChild(5));
                    instanships.GetComponent<Ship>().shipHull = tempship.shipHull;
                    instanships.GetComponent<Ship>().shiphead = tempship.shiphead;
                    instanships.GetComponent<Ship>().shipBody = tempship.shipBody;
                    instanships.GetComponent<Ship>().shipTail = tempship.shipTail;
                    instanships.GetComponent<Ship>().hp = tempship.hp;
                    instanships.GetComponent<Ship>().armor = tempship.armor;
                    instanships.GetComponent<Ship>().shield = tempship.shield;
                    instanships.GetComponent<Ship>().cost = tempship.cost;
                    instanships.GetComponent<Ship>().speed = tempship.speed;
                    break;

            }
            instantiateDistance += 5;
        }

        ShipSettingOn = true;
        playerfleet.StartFleetMove();
    }
}
