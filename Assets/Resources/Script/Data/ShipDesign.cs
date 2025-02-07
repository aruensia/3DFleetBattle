using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipDesign : MonoBehaviour
{
    //유저가 생성할 함선에 대해서 뉴 할당.
    Ship currentship = new Ship();
    Ship tempship;

    ShipHull shiphull;
    ShipHead shiphead;
    ShipBody shipbody;
    ShipTail shiptail;

    [SerializeField] Button SetShipHullButton;
    [SerializeField] Button SetShipHeadButton;
    [SerializeField] Button SetShipBodyButton;
    [SerializeField] Button SetShipTailButton;

    private void Start()
    {
        SetShipBodyButton.onClick.AddListener(() => SetShipBody(DataManager.Instance.tempShipBodyData));
        SetShipHeadButton.onClick.AddListener(() => SetShipHead(DataManager.Instance.tempShipHeadData));
        SetShipTailButton.onClick.AddListener(() => SetShipTail(DataManager.Instance.tempShipTailData));
    }

    void SetShipHull(ShipHull shiphull)
    {
        if (this.shiphull == null)
        {
            this.shiphull = shiphull;

            Debug.Log(this.shipbody.bodyName + " 가 들어갔습니다.");
        }
        else
        {
            Debug.Log("이미 값이 있습니다.");
        }
    }


    void SetShipBody(ShipBody shipbody)
    {
        if(this.shipbody == null)
        {
            this.shipbody = shipbody;
            this.currentship.hp = this.currentship.hp + shipbody.bodyHp;
            this.currentship.cost += shipbody.cost;
            Debug.Log(this.shipbody.bodyName + " 가 들어갔습니다.");
        }
        else
        {
            Debug.Log("이미 값이 있습니다.");
        }
    }

    void SetShipHead(ShipHead shiphead)
    {
        if (this.shiphead == null)
        {
            this.shiphead = shiphead;
            this.currentship.hp += shiphead.headHp;
            this.currentship.cost += shipbody.cost;
            Debug.Log(this.shiphead.headName + " 가 들어갔습니다.");
        }
        else
        {
            Debug.Log("이미 값이 있습니다.");
        }
    }

    void SetShipTail(ShipTail shiptail)
    {
        if (this.shiptail == null)
        {
            this.shiptail = shiptail;
            this.currentship.hp += shiptail.tailHp;
            this.currentship.cost += shipbody.cost;
            Debug.Log(this.shiptail.tailName + " 가 들어갔습니다.");
        }
        else
        {
            Debug.Log("이미 값이 있습니다.");
        }
    }

}
