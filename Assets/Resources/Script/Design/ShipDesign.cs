using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipDesign : MonoBehaviour
{
    public GameObject equipShipPartButton;
    public GameObject shipInstantiatePos;
    public GameObject shipHullpos;
    public GameObject shipHeadPos;
    public GameObject shipBodyPos;
    public GameObject shipTailPos;
    public GameObject itemIcon;

    GameObject tempShiphullSlot;


    //유저가 생성할 함선에 대해서 뉴 할당.
    public Ship currentship = new Ship();

    DefaultShipPart curruentSelectUserItem;

    public void SetShipPart(DefaultShipPart tempShipPart)
    {
        Debug.Log($"{tempShipPart.defaultShipPartName}를 호출함");
        switch(tempShipPart.partType)
        {
            case PartType.Head:
                if( this.currentship.shipHull != null)
                {
                    if (this.currentship.shiphead == null)
                    {
                        ShipHead shipHead = (ShipHead)tempShipPart;
                        this.currentship.shiphead = shipHead;
                        this.currentship.hp += shipHead.defaultShipPartArmor;
                        this.currentship.cost += shipHead.defaultShipPartCost;
                        Debug.Log(this.currentship.shiphead.defaultShipPartName + " 가 들어갔습니다.");

                        if (shipHead.weapons.Count > 0)
                        {
                            Debug.Log(shipHead.weapons.Count);
                            for (int i = 0; i < shipHead.weapons.Count; i++)
                            {
                                Instantiate(itemIcon, shipHeadPos.transform.GetChild(0).transform);
                            }
                        }
                        if (shipHead.utility.Count > 0)
                        {
                            Debug.Log(shipHead.utility.Count);
                            for (int i = 0; i < shipHead.utility.Count; i++)
                            {
                                Instantiate(itemIcon, shipHeadPos.transform.GetChild(1).transform);
                            }
                        }
                    }
                    else
                    {

                    }
                }
                break;

            case PartType.Body:
                if (this.currentship.shipHull != null)
                {
                    if (this.currentship.shipBody == null)
                    {
                        ShipBody shipBody = (ShipBody)tempShipPart;
                        this.currentship.shipBody = shipBody;
                        this.currentship.hp += shipBody.defaultShipPartArmor;
                        this.currentship.cost += shipBody.defaultShipPartCost;
                        Debug.Log(this.currentship.shipBody.defaultShipPartName + " 가 들어갔습니다.");


                        if (shipBody.weapons.Count > 0)
                        {
                            Debug.Log(shipBody.weapons.Count);
                            for (int i = 0; i < shipBody.weapons.Count; i++)
                            {
                                Instantiate(itemIcon, shipBodyPos.transform.GetChild(0).transform);
                            }
                        }
                        if (shipBody.utility.Count > 0)
                        {
                            Debug.Log(shipBody.utility.Count);
                            for (int i = 0; i < shipBody.utility.Count; i++)
                            {
                                Instantiate(itemIcon, shipBodyPos.transform.GetChild(1).transform);
                            }
                        }
                    }
                }
                else
                {

                }
                break;

            case PartType.Tail:

                if (this.currentship.shipHull != null)
                {
                    if (this.currentship.shipTail == null)
                    {
                        ShipTail shipTail = (ShipTail)tempShipPart;
                        this.currentship.shipTail = shipTail;
                        this.currentship.hp += shipTail.defaultShipPartArmor;
                        this.currentship.cost += shipTail.defaultShipPartCost;
                        Debug.Log(this.currentship.shipTail.defaultShipPartName + " 가 들어갔습니다.");

                        if (shipTail.weapons.Count > 0)
                        {
                            Debug.Log(shipTail.weapons.Count);
                            for (int i = 0; i < shipTail.weapons.Count; i++)
                            {
                                Instantiate(itemIcon, shipTailPos.transform.GetChild(0).transform);
                            }
                        }
                        if (shipTail.utility.Count > 0)
                        {
                            Debug.Log(shipTail.utility.Count);
                            for (int i = 0; i < shipTail.utility.Count; i++)
                            {
                                Instantiate(itemIcon, shipTailPos.transform.GetChild(1).transform);
                            }
                        }
                    }

                }
                else
                {

                }
                break;

            case PartType.Hull:
                if (this.currentship.shipHull == null)
                {
                    ShipHull shipHull = (ShipHull)tempShipPart;
                    this.currentship.shipHull = shipHull;
                    this.currentship.hp += shipHull.defaultShipPartArmor;
                    this.currentship.cost += shipHull.defaultShipPartCost;
                    Debug.Log(this.currentship.shipHull.defaultShipPartName + " 가 들어갔습니다.");
                    tempShiphullSlot = Instantiate(shipHull.shipModel, shipInstantiatePos.transform);
                    shipHullpos.transform.GetChild(0).GetComponent<Image>().sprite = shipHull.iconImage;
                    Image tempImage = shipHullpos.transform.GetChild(0).GetComponent<Image>();
                    Color tempColor = tempImage.color;
                    tempColor.a = 1f;
                    tempImage.color = tempColor;
                }
                break;
        }
    }

    public void ShipSave()
    {
        if(this.currentship.shipHull == null && this.currentship.shiphead == null && this.currentship.shipBody == null && this.currentship.shipTail == null)
        {
            Debug.Log(" 현재 준비된 함선이 없습니다.");
        }
        DataManager.Instance.playerInfo.MyShips.Add(currentship);
        ShipDesignSlotReset();
        Debug.Log(DataManager.Instance.playerInfo.MyShips.Count);
    }

    void ShipDesignSlotReset()
    {
        currentship = null;
        Destroy(tempShiphullSlot);
        
    }



    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
