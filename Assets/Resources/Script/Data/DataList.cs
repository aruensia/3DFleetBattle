using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "Ship/DataList")]
public class DataList : ScriptableObject
{
    public Dictionary<string, List<ScriptableObject>> AllShipDataDic = new Dictionary<string, List<ScriptableObject>>()
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

    ScriptableObject scriptableObjectData;

    public void AllShipDataDicClear()
    {
        AllShipDataDic.Clear();
    }

    public void GetShipData()
    {
        int LoadCount = 1;
        foreach ( var dic in AllShipDataDic )
        {
            while(true)
            {
                scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/{dic.Key}/{dic.Key} {LoadCount}");
                if (scriptableObjectData == null)
                {
                    //데이터가 없을 경우 while문을 빠져나감.
                    Debug.Log($"-------------------{dic.Key}의 로드 완료. {dic.Key}의 데이터 갯수 : {dic.Value.Count}");
                    break;
                }
                dic.Value.Add(scriptableObjectData);
                LoadCount++;
            }
            LoadCount = 1;
        }
    }
}
