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

    int shipHp;

    [SerializeField] Button SetShipHullButton;
    [SerializeField] Button SetShipHeadButton;
    [SerializeField] Button SetShipBodyButton;
    [SerializeField] Button SetShipTailButton;

    private void Start()
    {
        SetShipHullButton.onClick.AddListener(() => SetShipHull(DataManager.Instance.tempShipData));
    }

    public void onShipHullButton()
    {
       // SetShipHullButton.onClick.AddListener(() => SetShipHull(DataManager.Instance.tempShipData));
        if(SetShipHullButton == null)
        {
            Debug.Log("버튼이 null");
        }
        if(DataManager.Instance.tempShipData == null)
        {
           Debug.Log("얘가 없어요");
        }
    }
    
    void SetShipHull(ShipBody shipbody)
    {
        if (shipbody == null)
        {
            this.shipbody = shipbody;
            this.shipHp = this.shipHp + shipbody.bodyHp;
            Debug.Log(this.shipbody.bodyName + " 가 들어갔습니다.");
        }
        Debug.Log("이미 값이 있습니다.");
    }
}
