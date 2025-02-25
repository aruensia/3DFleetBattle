using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShipDesign : MonoBehaviour
{
    public GameObject equipShipPartButton;
    public GameObject shipInstantiatePos;
    public GameObject shipHullpos;
    public GameObject shipHeadPos;
    public GameObject shipBodyPos;
    public GameObject shipTailPos;
    public GameObject itemIcon;
    public GameObject itemInfoPanel;
    public GameObject weaponButton;
    public GameObject utilityButton;
    public Transform tempObject;

    public bool isWeaponSetting;
    bool saveOn = false;
    GameObject tempShiphullSlot;

    List<DefaultShipPart> tempShipPartSaveList = new List<DefaultShipPart>();


    //유저가 생성할 함선에 대해서 뉴 할당.
    public Ship currentship = new Ship();

    private void Start()
    {
        isWeaponSetting = false;
    }

    public void SetShipPart(DefaultShipPart tempShipPart)
    {
        Debug.Log($"{tempShipPart.defaultShipPartName}를 호출함");
        Debug.Log($"{tempShipPart.partType}를 호출함");

        string number = Regex.Replace(tempShipPart.name, @"\D", "");
        int tempnum = int.Parse(number);

        Debug.Log(currentship.shiphead);

        switch (tempShipPart.partType)
        {
            case PartType.Head:
                if( this.currentship.shiphead == null)
                {
                    this.currentship.shiphead = null;
                    ShipHead shipHead = (ShipHead)tempShipPart;
                    this.currentship.shiphead = shipHead;
                    this.currentship.hp += shipHead.defaultShipPartArmor;
                    this.currentship.cost += shipHead.defaultShipPartCost;
                    Debug.Log(this.currentship.shiphead.defaultShipPartName + " 가 들어갔습니다.");
                    
                    if (shipHead.weapons.Count > 0)
                    {
                        for (int i = 0; i < shipHead.weapons.Count; i++)
                        {
                            Instantiate(itemIcon, shipHeadPos.transform.GetChild(0).transform);
                        }
                    }
                    if (shipHead.utility.Count > 0)
                    {
                        for (int i = 0; i < shipHead.utility.Count; i++)
                        {
                            Instantiate(itemIcon, shipHeadPos.transform.GetChild(1).transform);
                        }
                    }
                    DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Remove(shipHead);
                }
                else
                {
                    for ( int i = 0; i < shipHeadPos.transform.GetChild(0).childCount; i++)
                    {
                        Destroy((shipHeadPos.transform.GetChild(0).transform.GetChild(i)).gameObject);
                    }
                    for (int i = 0; i < shipHeadPos.transform.GetChild(1).childCount; i++)
                    {
                        Destroy((shipHeadPos.transform.GetChild(1).transform.GetChild(i)).gameObject);
                    }

                    ShipHead tempcurrentshiphead = this.currentship.shiphead;
                    this.currentship.hp -= tempcurrentshiphead.defaultShipPartArmor;
                    this.currentship.cost -= tempcurrentshiphead.defaultShipPartCost;

                    this.currentship.shiphead = null;
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
                    DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Remove(shipHead);
                    DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Add(tempcurrentshiphead);
                }

                break;

            case PartType.Body:
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
                    DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Remove(shipBody);
                }
                else
                {
                    for (int i = 0; i < shipBodyPos.transform.GetChild(0).childCount; i++)
                    {
                        Destroy((shipBodyPos.transform.GetChild(0).transform.GetChild(i)).gameObject);
                    }
                    for (int i = 0; i < shipBodyPos.transform.GetChild(1).childCount; i++)
                    {
                        Destroy((shipBodyPos.transform.GetChild(1).transform.GetChild(i)).gameObject);
                    }

                    ShipBody tempcurrentshipBody = this.currentship.shipBody;
                    this.currentship.hp -= tempcurrentshipBody.defaultShipPartArmor;
                    this.currentship.cost -= tempcurrentshipBody.defaultShipPartCost;


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
                    DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Remove(shipBody);
                    DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Add(tempcurrentshipBody);
                }
                break;

            case PartType.Tail:

                if (this.currentship.shipTail == null)
                {
                    ShipTail shipTail = (ShipTail)tempShipPart;
                    this.currentship.shipTail = shipTail;
                    this.currentship.hp += shipTail.defaultShipPartArmor;
                    this.currentship.cost += shipTail.defaultShipPartCost;

                    if (shipTail.weapons.Count > 0)
                    {
                        for (int i = 0; i < shipTail.weapons.Count; i++)
                        {
                            Instantiate(itemIcon, shipTailPos.transform.GetChild(0).transform);
                        }
                    }
                    if (shipTail.utility.Count > 0)
                    {
                        for (int i = 0; i < shipTail.utility.Count; i++)
                        {
                            Instantiate(itemIcon, shipTailPos.transform.GetChild(1).transform);
                        }
                    }
                    DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Remove(shipTail);
                }
                else
                {
                    for (int i = 0; i < shipTailPos.transform.GetChild(0).childCount; i++)
                    {
                        Destroy((shipTailPos.transform.GetChild(0).transform.GetChild(i)).gameObject);
                    }
                    for (int i = 0; i < shipTailPos.transform.GetChild(1).childCount; i++)
                    {
                        Destroy((shipTailPos.transform.GetChild(1).transform.GetChild(i)).gameObject);
                    }

                    ShipTail tempcurrentshipTail = this.currentship.shipTail;
                    this.currentship.hp -= tempcurrentshipTail.defaultShipPartArmor;
                    this.currentship.cost -= tempcurrentshipTail.defaultShipPartCost;

                    ShipTail shipTail = (ShipTail)tempShipPart;
                    this.currentship.shipTail = shipTail;
                    this.currentship.hp += shipTail.defaultShipPartArmor;
                    this.currentship.cost += shipTail.defaultShipPartCost;

                    if (shipTail.weapons.Count > 0)
                    {
                        for (int i = 0; i < shipTail.weapons.Count; i++)
                        {
                            Instantiate(itemIcon, shipTailPos.transform.GetChild(0).transform);
                        }
                    }
                    if (shipTail.utility.Count > 0)
                    {
                        for (int i = 0; i < shipTail.utility.Count; i++)
                        {
                            Instantiate(itemIcon, shipTailPos.transform.GetChild(1).transform);
                        }
                    }
                    DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Remove(shipTail);
                    DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Add(tempcurrentshipTail);
                    
                }
                break;

            case PartType.Hull:
 
                if(tempShiphullSlot != null)
                {
                    Destroy(tempShiphullSlot);
                }

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
                Debug.Log(shipHull.name);

                if (this.currentship.shiphead != null)
                {
                    
                    for (int i = 0; i < this.currentship.shiphead.weapons.Count; i++)
                    {
                        Instantiate(itemIcon, shipHeadPos.transform.GetChild(0).transform);
                    }
     
                    for (int i = 0; i < this.currentship.shiphead.utility.Count; i++)
                    {
                        Instantiate(itemIcon, shipHeadPos.transform.GetChild(1).transform);
                    }
                    
                }
                break;

            case PartType.Weapon:
                Debug.Log("나 호출됌");
                ActiveEntryItem();
                break;

        }
    }

    void ActiveEntryItem()
    {
        isWeaponSetting = true;

        itemInfoPanel.transform.GetChild(0).gameObject.SetActive(false);
        itemInfoPanel.transform.GetChild(1).gameObject.SetActive(false);
        itemInfoPanel.transform.GetChild(2).gameObject.SetActive(false);

        weaponButton.gameObject.SetActive(true);
    }

    public void SetEntryItem(DefaultShipPart tempShipPart)
    {

    }

    public void ShipSave()
    {
        saveOn = true;
        if(this.currentship.shipHull != null && this.currentship.shiphead != null && this.currentship.shipBody != null && this.currentship.shipTail != null)
        {
            DataManager.Instance.playerInfo.MyShips.Add(currentship);
            ShipDesignSlotReset();
            Debug.Log(DataManager.Instance.playerInfo.MyShips.Count);
        }
        else
        {
            Debug.Log(" 현재 준비된 함선이 없습니다.");
        }
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

    void ResetItemList()
    {
        if (this.currentship.shiphead != null)
        {
            DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Add(this.currentship.shiphead);
        }

        if (this.currentship.shipBody != null)
        {
            DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Add(this.currentship.shipBody);
        }

        if (this.currentship.shipTail != null)
        {
            DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Add(this.currentship.shipTail);
        }
    }

    private void OnDisable()
    {
        ResetItemList();
    }
}

