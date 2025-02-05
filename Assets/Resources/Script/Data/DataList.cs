using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "Ship/DataList")]
public class DataList : ScriptableObject
{
    public List<ScriptableObject> shipHullData = new List<ScriptableObject>();
    public List<ScriptableObject> shipHeadData = new List<ScriptableObject>();
    public List<ScriptableObject> shipBodyData = new List<ScriptableObject>();
    public List<ScriptableObject> shipTailData = new List<ScriptableObject>();
    public List<ScriptableObject> weaponData = new List<ScriptableObject>();
    ScriptableObject scriptableObjectData;
    int LoadCount = 1;

    private void Awake()
    {
        GetShipHullData();
    }

    void GetShipHullData()
    {
        bool whileEnd = false;
        int whileCount = 0;
        Debug.Log("級嬢身");
        while (whileEnd == false)
        {
            switch (whileCount)
            {
                case 0:
                    while (true)
                    {
                        scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/ShipHullData/ShipHullData {LoadCount}");
                        if (scriptableObjectData == null)
                        {
                            Debug.Log("ShipHullData 確");

                            break;
                        }
                        shipHullData.Add(scriptableObjectData);
                        Debug.Log(shipHullData[LoadCount - 1].name);
                        LoadCount++;
                    }
                    LoadCount = 1;
                    whileCount++;
                    break;
                case 1:
                    while (true)
                    {
                        scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/ShipHeadData/ShipHeadData {LoadCount}");
                        if (scriptableObjectData == null)
                        {
                            Debug.Log("ShipHeadData 確");

                            break;
                        }
                        shipHeadData.Add(scriptableObjectData);
                        Debug.Log(shipHeadData[LoadCount - 1].name);
                        LoadCount++;
                    }
                    LoadCount = 1;
                    whileCount++;
                    break;

                case 2:
                    while (true)
                    {
                        scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/ShipBodyData/ShipBodyData {LoadCount}");
                        if (scriptableObjectData == null)
                        {
                            Debug.Log("ShipBodyData 確");

                            break;
                        }
                        shipBodyData.Add(scriptableObjectData);
                        Debug.Log(shipBodyData[LoadCount - 1].name);
                        LoadCount++;
                    }
                    LoadCount = 1;
                    whileCount++;
                    break;

                case 3:
                    while (true)
                    {
                        scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/ShipTailData/ShipTailData {LoadCount}");
                        if (scriptableObjectData == null)
                        {
                            Debug.Log("ShipTailData 確");

                            break;
                        }
                        shipTailData.Add(scriptableObjectData);
                        Debug.Log(shipTailData[LoadCount - 1].name);
                        LoadCount++;
                    }
                    LoadCount = 1;
                    whileCount++;
                    break;

                case 4:
                    while (true)
                    {
                        scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/weaponData/WeaponData {LoadCount}");
                        if (scriptableObjectData == null)
                        {
                            Debug.Log("WeaponData 確");

                            break;
                        }
                        weaponData.Add(scriptableObjectData);
                        Debug.Log(weaponData[LoadCount - 1].name);
                        LoadCount++;
                    }
                    LoadCount = 1;
                    whileCount++;
                    break;

                case 5:
                    whileEnd = true;
                    break;
            }
        }
    }
}
