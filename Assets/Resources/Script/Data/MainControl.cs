using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{

    public void GoBattle()
    {
        if(DataManager.Instance.playerInfo.MyShips.Count == 0)
        {
            Debug.Log("보유한 함선이 없습니다.");
        }
        else
        {
            SceneManager.LoadScene("BattleScene");
        }
    }

    public void GoDesign()
    {
        SceneManager.LoadScene("ShipDesign");
    }

    public void GoShop()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
