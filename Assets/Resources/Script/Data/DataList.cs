using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "DataList", menuName = "Ship/DataList")]
public class DataList : ScriptableObject
{
    public Dictionary<string, List<ScriptableObject>> AllShipDataDic = new Dictionary<string, List<ScriptableObject>>();

    public List<string> datanamelist = new List<string>()
    {
        {"shipHullData" },
        {"shipHeadData" },
        {"shipBodyData" },
        {"shipTailData" },
        {"weaponData" },
        {"UtilityData" },
    };


    ScriptableObject scriptableObjectData;
    int LoadCount = 1;

    void AddTotalShipDataDic()
    {
        for (int i = 0; i < datanamelist.Count; i++)
        {
            AllShipDataDic.Add(datanamelist[i], new List<ScriptableObject>());
        }
    }

    void AllShipDataDicClear()
    {
        AllShipDataDic.Clear();
    }

    public void GetShipData()
    {
        AllShipDataDicClear();
        AddTotalShipDataDic();
        Debug.Log(AllShipDataDic.Count);

        for ( int i = 0;i < datanamelist.Count;i++)
        {
            scriptableObjectData = Resources.Load<ScriptableObject>($"Script/Data/{datanamelist[i]}/{datanamelist[i]} {LoadCount}");
            if (scriptableObjectData == null)
            {
                Debug.Log($"{datanamelist[i]} ³Î");

                break;
            }
            AllShipDataDic[datanamelist[i]].Add(scriptableObjectData);
            LoadCount++;
        }
    }
}
