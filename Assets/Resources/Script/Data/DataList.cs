using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "DataList", menuName = "Ship/DataList")]
public class DataList : ScriptableObject
{
    List<string> folders = new List<string>()
    {
        {"ShipHullData"},
        {"ShipHeadData"},
        {"ShipBodyData"},
        {"ShipTailData"},
        {"WeaponData"},
        {"UtilityData"},
    };
    public Dictionary<string, List<ScriptableObject>> AllShipDataDic = new Dictionary<string, List<ScriptableObject>>()
    {
        { "ShipHullData", new List<ScriptableObject>()},
        { "ShipHeadData", new List<ScriptableObject>()},
        { "ShipBodyData", new List<ScriptableObject>()},
        { "ShipTailData", new List<ScriptableObject>()},
        { "WeaponData", new List<ScriptableObject>()},
        { "UtilityData", new List<ScriptableObject>()},
    };

    ScriptableObject scriptableObjectData;

    public void AllShipDataDicClear()
    {
        AllShipDataDic.Clear();
    }

    public void GetShipData()
    {
        int LoadCount = 1;
        for ( int i = 0; i< AllShipDataDic.Count; i++ )
        {
            Debug.Log(folders[i]);
            while (true)
            {
                //Debug.Log($"Script/Data/{folders[i]}/{folders[i]} {LoadCount}");
                scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/{folders[i]}/{folders[i]} {LoadCount}");
                if (scriptableObjectData == null)
                {
                    //데이터가 없을 경우 while문을 빠져나감.
                    Debug.Log($"-------------------{folders[i]}의 로드 완료");
                    break;
                }
                AllShipDataDic[folders[i]].Add(scriptableObjectData);
                LoadCount++;
            }
            LoadCount = 1;
        }
    }
}
