using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipTest : MonoBehaviour
{
    int tempButtonNumber = 0;

    List<Object> shiplist = new List<Object>();



    public void GetButtonInt(int value)
    {
        tempButtonNumber = value;
        Debug.Log(tempButtonNumber);
    }

    public void InitShipItem()
    {
        
    }

    void CreateShipItemStatInfo()
    {
        
        //transform.Translate
    }

}
