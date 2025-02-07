using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Grade
{
    Normal, Military, Epic, HighTech
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

    public ShipBody tempShipBodyData;
    public ShipHead tempShipHeadData;
    public ShipTail tempShipTailData;
    public Weapon tempWeaponData;
    public ShipReactor tempShipREactorData;
    public ShipThruster tempShipThrusterData;

    DataList getNewDataList;
    public Weapon testweapon;

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
        GetDataObject();
        getNewDataList.GetShipData();
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
