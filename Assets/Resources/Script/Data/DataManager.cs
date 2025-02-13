using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Mass, Laser, Drone
}

public enum PartType
{
    Hull, Head, Body, Tail, Weapon, Utility, Reactor, Thruster
}

public enum Grade
{
    Normal, Military, Epic, HighTech, end
}

public enum Utility
{
    Shields, Armor, Computer
}

public enum ShipClass
{
    Corvette = 1, Frigate, Destroyer
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

    public DefaultShipPart defaultShipPart;

    public DataList getNewDataList;
    public Weapon testweapon;
    ShopMain shopMain;

      private void Awake()
    {
        if (instance == null)
        {
            instance = this;

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
        GetDataObject();
        getNewDataList.GetShipData();
        shopMain.GetForManagerShipData();
        //TestSetting();
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
