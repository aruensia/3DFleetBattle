using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBluePrint : MonoBehaviour
{
    public BuildShip currentShip = new BuildShip();



    #region Ui 버튼에서 호출하여 쓸 함수
    //마우스에서 드래그를 놓을 경우, 해당 함수를 호출하여 데이터를 입력함.
    public void SetHull(BuildShip Ship)
    {
        currentShip.ShipHull = Ship.ShipHull;
    }

    public void SetHead(BuildShip Ship)
    {
        currentShip.Head = Ship.Head;
    }

    public void SetBody(BuildShip Ship)
    {
        currentShip.Body = Ship.Body;
    }

    public void SetTail(BuildShip Ship)
    {
        currentShip.Tail = Ship.Tail;
    }
    #endregion

    public GameObject GetShipClass(ShipClass shipClass)
    {
        switch (shipClass)
        {
            case ShipClass.Corvette:
                return Resources.Load<GameObject>("Prefabs/ShipClassData/Corvette");

            default:
                return null;
        }
    }

    public void ShipRollout(ShipClass type)
    {
        GameObject shipPrefab = GetShipClass(type);
        GameObject newShip = Instantiate(shipPrefab, this.transform);


    }
}