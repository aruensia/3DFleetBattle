using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public DataList getNewDataList;

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
    }


    void GetDataObject()
    {
        getNewDataList = Resources.Load<DataList>($"Script/Data/DataList") ;
        Debug.Log(getNewDataList);

    }


}
