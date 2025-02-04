using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetShipData : MonoBehaviour
{
    public ShipBody shipbody;

    public void AddBodyDataButton()
    {
            if (DataManager.Instance.tempShipData == null)
            {
                DataManager.Instance.tempShipData = shipbody;
                Debug.Log(DataManager.Instance.tempShipData.name);
            } 
            else
            {
                Debug.Log("≥Œ¿Ãæﬂ");
            }
    }
}
