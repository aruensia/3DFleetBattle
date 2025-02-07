using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetShipData : MonoBehaviour
{
    public ShipBody shipbody;

    public void AddBodyDataButton()
    {
            if (DataManager.Instance.defaultShipPart == null)
            {
                Debug.Log("≥Œ¿Ãæﬂ");
            } 
            else
            {
                Debug.Log(DataManager.Instance.defaultShipPart.name);
            }
    }
}
