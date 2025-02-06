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

    public ShipBody tempShipData;
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
        Debug.Log("sdfsdfsdf" + getNewDataList.weaponData[0].name);
       //TestSetting();
    }


    void GetDataObject()
    {
        getNewDataList = Resources.Load<DataList>($"Script/Data/DataList") ;
        Debug.Log(getNewDataList);

    }

    //void TestSetting()
    //{
    //    ShipHead testhead = new ShipHead();
    //    testweapon = new Weapon();

    //    testhead.weapons.Add(testweapon);
    //    Debug.Log(testhead.weapons[0].name);
    //}    


}
