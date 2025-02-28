using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    Dictionary<string, List<ScriptableObject>> playerData = new Dictionary<string, List<ScriptableObject>>()
    {
        { "ShipHullData", new List<ScriptableObject>()},
        { "ShipHeadData", new List<ScriptableObject>()},
        { "ShipBodyData", new List<ScriptableObject>()},
        { "ShipTailData", new List<ScriptableObject>()},
        { "WeaponData", new List<ScriptableObject>()},
        { "UtilityData", new List<ScriptableObject>()},
        { "ShipReactorData", new List<ScriptableObject>()},
        { "ShipThrusterData", new List<ScriptableObject>()},
    };

    public List<GameObject> tempInventorylist = new List<GameObject>();
    public string currentSelectDataValue;
    public List<ShipData> MyShips = new List<ShipData>();

    public Dictionary<string, List<ScriptableObject>> PlayerData
    {
        get { return playerData; }
        set { playerData = value; }
    }

    int money;

    public int Money
    {
        get { return money; }
        set { money = value; }
    }

    public int inventoryCount;

    public void SetDefaultData()
    {
        money = 5000;
        Debug.Log($"@@@@-- 함선의 데이터를 초기화 했음 --@@@@");
        Debug.Log($"@@@@-- 인벤토리의 크기는 : {inventoryCount} --@@@@");
        Debug.Log($"@@@@-- 초기화된 돈은 : {money} --@@@@");
    }
}
