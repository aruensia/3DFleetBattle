using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetShipData : MonoBehaviour
{
    public ShipBody shipbody;

    public void AddBodyDataButton()
    {
            if (DataManager.Instance.tempShipBodyData == null)
            {
                DataManager.Instance.tempShipBodyData = shipbody;
                Debug.Log(DataManager.Instance.tempShipBodyData.name);
            } 
            else
            {
                Debug.Log("≥Œ¿Ãæﬂ");
            }
    }
}
