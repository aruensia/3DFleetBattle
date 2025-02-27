using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{

    public void GoBattle()
    {
        SceneManager.LoadScene("BattleScene");
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
