using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceShip : MonoBehaviour
{
    public Ship ShipData {  get; set; }

    private void Awake()
    {
        TableManager.Instance.InstanceShip = this;
    }
}
