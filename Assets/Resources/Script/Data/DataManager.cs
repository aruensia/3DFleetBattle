using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Mass, Laser, Missile, Drone
}

public enum PartType
{
    Hull, Head, Body, Tail, Weapon, Utility, Reactor, Thruster
}

public enum Grade
{
    Normal = 65, Military = 75, HighTech = 89, LostTech = 97, end
}

public enum Utility
{
    Shields, Armor, Computer
}

public enum ComputerType
{
    Tracking, Line, Carrier
}

public enum ShipClass
{
    Corvette = 1, Frigate, Destroyer, Cruiser, Battleship, AircraftCarrier
}
public enum Size
{
    small, medium, large
}

public class DataManager : MonoBehaviour
{
    static DataManager instance;
    public static DataManager Instance
    {
        get { return instance; }
    }

    [HideInInspector]
    public DataList getNewDataList;
    ShopMain shopMain;
    ShipDesign shopDesign;
    [HideInInspector]
    public PlayerInfo playerInfo;

      private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GetDataObject();
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        shopMain = GetComponent<ShopMain>();
        shopDesign = GetComponent<ShipDesign>();
        playerInfo = GetComponent<PlayerInfo>();
        getNewDataList.GetShipData();
    }

    void GetDataObject()
    {
        getNewDataList = Resources.Load<DataList>($"Script/Data/DataList") ;
    }

    void TestSetting()
    {
        foreach(var item in getNewDataList.AllShipDataDic)
        {
            Debug.Log($"[Key: {item.Key}] 데이터 계수 : {item.Value.Count}");

            foreach(var item2 in item.Value)
            {
                Debug.Log($"- {item2.name}");
            }
        }
    }    
}
