using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipDesign : MonoBehaviour
{
    //유저가 생성할 함선에 대해서 뉴 할당.
    Ship currentship = new Ship();


    void SetShipHull(ShipHull shiphull)
    {
        if (this.currentship.shipHull == null)
        {
            this.currentship.shipHull = shiphull;

            Debug.Log(this.currentship.shipHull.hullName + " 가 들어갔습니다.");
        }
        else
        {
            Debug.Log("이미 값이 있습니다.");
        }
    }

    void SetShipPart(DefaultShipPart tempShipPart)
    {
        Debug.Log($"{tempShipPart.defaultShipPartName}를 호출함");
        switch(tempShipPart.partType)
        {
            case PartType.Head:
                if (this.currentship.shiphead == null)
                {
                    this.currentship.shiphead = (ShipHead)tempShipPart;
                    this.currentship.hp += tempShipPart.defaultShipPartArmor;
                    this.currentship.cost += tempShipPart.defaultShipPartCost;
                    Debug.Log(this.currentship.shiphead.defaultShipPartName + " 가 들어갔습니다.");
                }
                else
                {
                    Debug.Log("이미 값이 있습니다.");
                }
                break;

            case PartType.Body:
                if (this.currentship.shipBody == null)
                {
                    this.currentship.shipBody = (ShipBody)tempShipPart;
                    this.currentship.hp += tempShipPart.defaultShipPartArmor;
                    this.currentship.cost += tempShipPart.defaultShipPartCost;
                    Debug.Log(this.currentship.shipBody.defaultShipPartName + " 가 들어갔습니다.");
                }
                else
                {
                    Debug.Log("이미 값이 있습니다.");
                }
                break;

            case PartType.Tail:
                if (this.currentship.shipTail == null)
                {
                    this.currentship.shipBody = (ShipBody)tempShipPart;
                    this.currentship.hp += tempShipPart.defaultShipPartArmor;
                    this.currentship.cost += tempShipPart.defaultShipPartCost;
                    Debug.Log(this.currentship.shipTail.defaultShipPartName + " 가 들어갔습니다.");
                }
                else
                {
                    Debug.Log("이미 값이 있습니다.");
                }
                break;
        }
    }
}
