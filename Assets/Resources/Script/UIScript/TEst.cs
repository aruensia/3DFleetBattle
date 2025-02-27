using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.T) )
        {
            TestDefaultSetting();
        }
    }



    public void TestDefaultSetting()
    {
        for(int i = 0; i < 10; i++)
        {
            DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["ShipHullData"][0]);
            DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["ShipHeadData"][0]);
            DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["ShipBodyData"][0]);
            DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["ShipTailData"][0]);
            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["WeaponData"][0]);
            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["UtilityData"][0]);
            DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["ShipReactorData"][0]);
            DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Add(DataManager.Instance.getNewDataList.AllShipDataDic["ShipThrusterData"][0]);

        }
    }

}
