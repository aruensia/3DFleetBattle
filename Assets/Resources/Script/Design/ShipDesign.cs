using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject itemInfoPanel;
    public GameObject weaponButton;
    public GameObject utilityButton;
    public Transform tempObject;

    public bool isWeaponSetting;
    bool saveOn = false;
    GameObject tempShiphullSlot;
    DefaultShipPart tempweapons;
    DefaultShipPart temputilitys;
    public Sprite defaultSlotImage1;
    public Sprite defaultSlotImage2;
    public string currentSelectRemoveItemType;

    int weaponheadCount = 0;
    int weaponbodyCount = 0;
    int weapontailCount = 0;

    int utilityheadCount = 0;
    int utilitybodyCount = 0;
    int utilitytailCount = 0;

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
                            var temp = Instantiate(itemIcon, shipHeadPos.transform.GetChild(0).transform);
                            temp.name = "weapons"+i;
                        }
                    }
                    if (shipHead.utility.Count > 0)
                    {
                        for (int i = 0; i < shipHead.utility.Count; i++)
                        {
                            var temp = Instantiate(itemIcon, shipHeadPos.transform.GetChild(1).transform);
                            temp.name = "utility" + i;
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
                            var temp = Instantiate(itemIcon, shipHeadPos.transform.GetChild(0).transform);
                            temp.name = "weapons" + i;
                        }
                    }
                    if (shipHead.utility.Count > 0)
                    {
                        Debug.Log(shipHead.utility.Count);
                        for (int i = 0; i < shipHead.utility.Count; i++)
                        {
                            var temp = Instantiate(itemIcon, shipHeadPos.transform.GetChild(1).transform);
                            temp.name = "utility" + i;
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
                            var temp = Instantiate(itemIcon, shipBodyPos.transform.GetChild(0).transform);
                            temp.name = "weapons" + i;
                        }
                    }
                    if (shipBody.utility.Count > 0)
                    {
                        Debug.Log(shipBody.utility.Count);
                        for (int i = 0; i < shipBody.utility.Count; i++)
                        {
                            var temp = Instantiate(itemIcon, shipBodyPos.transform.GetChild(1).transform);
                            temp.name = "utility" + i;
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
                            var temp = Instantiate(itemIcon, shipBodyPos.transform.GetChild(0).transform);
                            temp.name = "weapons" + i;
                        }
                    }
                    if (shipBody.utility.Count > 0)
                    {
                        Debug.Log(shipBody.utility.Count);
                        for (int i = 0; i < shipBody.utility.Count; i++)
                        {
                            var temp = Instantiate(itemIcon, shipBodyPos.transform.GetChild(1).transform);
                            temp.name = "utility" + i;
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
                            var temp = Instantiate(itemIcon, shipTailPos.transform.GetChild(0).transform);
                            temp.name = "weapons" + i;
                        }
                    }
                    if (shipTail.utility.Count > 0)
                    {
                        for (int i = 0; i < shipTail.utility.Count; i++)
                        {
                            var temp = Instantiate(itemIcon, shipTailPos.transform.GetChild(1).transform);
                            temp.name = "utility" + i;
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
                            var temp = Instantiate(itemIcon, shipTailPos.transform.GetChild(0).transform);
                            temp.name = "weapons" + i;
                        }
                    }
                    if (shipTail.utility.Count > 0)
                    {
                        for (int i = 0; i < shipTail.utility.Count; i++)
                        {
                            var temp = Instantiate(itemIcon, shipTailPos.transform.GetChild(1).transform);
                            temp.name = "utility" + i;
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

                tempweapons = tempShipPart;
                ActiveSubItem();
                break;


            case PartType.Utility:

                temputilitys = tempShipPart;
                ActiveSubItem();
                break;

        }
    }

    void ActiveSubItem()
    {
        isWeaponSetting = true;

        itemInfoPanel.gameObject.SetActive(false);

        weaponButton.gameObject.SetActive(true);
    }

    public void SetSubItem(int buttonnum)
    {
        Weapon weapons = (Weapon)tempweapons;
        UtilityData utility = (UtilityData)temputilitys;

        if(weapons != null )
        {
            switch (buttonnum)
            {
                case 1:
                    if (this.currentship.shiphead != null)
                    {
                        if (this.currentship.shiphead.weapons.Count > weaponheadCount)
                        {
                            this.currentship.shiphead.weapons[weaponheadCount] = weapons;
                            shipHeadPos.transform.GetChild(0).GetChild(weaponheadCount).GetComponent<Image>().sprite = weapons.iconImage;
                            weaponheadCount++;
                            weaponButton.gameObject.SetActive(false);
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Remove(weapons);
                        }
                        else if (this.currentship.shiphead.weapons.Count <= weaponheadCount)
                        {
                            weaponheadCount = 0;
                            Weapon tempcurrentshipweapon = this.currentship.shiphead.weapons[weaponheadCount];
                            this.currentship.shiphead.weapons[weaponheadCount] = weapons;
                            shipHeadPos.transform.GetChild(0).GetChild(weaponheadCount).GetComponent<Image>().sprite = weapons.iconImage;
                            weaponheadCount++;
                            weaponButton.gameObject.SetActive(false);
                            tempcurrentshipweapon = this.currentship.shiphead.weapons[weaponheadCount];
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Remove(weapons);
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(tempcurrentshipweapon);
                        }
                    }
                    tempweapons = null;

                    break;

                case 2:
                    if (this.currentship.shipBody != null)
                    {
                        if (this.currentship.shipBody.weapons.Count > weaponbodyCount)
                        {
                            this.currentship.shipBody.weapons[weaponbodyCount] = weapons;
                            shipBodyPos.transform.GetChild(0).GetChild(weaponbodyCount).GetComponent<Image>().sprite = weapons.iconImage;
                            weaponbodyCount++;
                            weaponButton.gameObject.SetActive(false);
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Remove(weapons);
                        }
                        else if (this.currentship.shipBody.weapons.Count <= weaponbodyCount)
                        {
                            weaponbodyCount = 0;
                            Weapon tempcurrentshipweapon = this.currentship.shipBody.weapons[weaponbodyCount];
                            this.currentship.shipBody.weapons[weaponbodyCount] = weapons;
                            shipBodyPos.transform.GetChild(0).GetChild(weaponbodyCount).GetComponent<Image>().sprite = weapons.iconImage;
                            weaponbodyCount++;
                            weaponButton.gameObject.SetActive(false);
                            tempcurrentshipweapon = this.currentship.shipBody.weapons[weaponbodyCount];
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Remove(weapons);
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(tempcurrentshipweapon);
                        }
                    }
                    tempweapons = null;

                    break;

                case 3:
                    if (this.currentship.shipTail != null)
                    {
                        if (this.currentship.shipTail.weapons.Count > weapontailCount)
                        {
                            this.currentship.shipTail.weapons[weapontailCount] = weapons;
                            shipTailPos.transform.GetChild(0).GetChild(weapontailCount).GetComponent<Image>().sprite = weapons.iconImage;
                            weapontailCount++;
                            weaponButton.gameObject.SetActive(false);
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Remove(weapons);
                        }
                        else if (this.currentship.shipTail.weapons.Count <= weapontailCount)
                        {
                            weapontailCount = 0;
                            Weapon tempcurrentshipweapon = this.currentship.shipTail.weapons[weapontailCount];
                            this.currentship.shipTail.weapons[weapontailCount] = weapons;
                            shipTailPos.transform.GetChild(0).GetChild(weapontailCount).GetComponent<Image>().sprite = weapons.iconImage;
                            weapontailCount++;
                            weaponButton.gameObject.SetActive(false);
                            tempcurrentshipweapon = this.currentship.shipTail.weapons[weapontailCount];
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Remove(weapons);
                            DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(tempcurrentshipweapon);
                        }
                    }
                    tempweapons = null;

                    break;
            }
            isWeaponSetting = false;
        }
        else if( utility != null)
        {
            switch (buttonnum)
            {
                case 1:
                    if (this.currentship.shiphead != null)
                    {
                        if (this.currentship.shiphead.utility.Count > utilityheadCount)
                        {
                            this.currentship.shiphead.utility[utilityheadCount] = utility;
                            shipHeadPos.transform.GetChild(1).GetChild(utilityheadCount).GetComponent<Image>().sprite = utility.iconImage;
                            utilityheadCount++;
                            weaponButton.gameObject.SetActive(false);
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Remove(utility);
                        }
                        else if (this.currentship.shiphead.utility.Count <= utilityheadCount)
                        {
                            utilityheadCount = 0;
                            UtilityData tempcurrentshipUtility = this.currentship.shiphead.utility[utilityheadCount];
                            this.currentship.shiphead.utility[utilityheadCount] = utility;
                            shipHeadPos.transform.GetChild(1).GetChild(utilityheadCount).GetComponent<Image>().sprite = utility.iconImage;
                            utilityheadCount++;
                            weaponButton.gameObject.SetActive(false);
                            tempcurrentshipUtility = this.currentship.shiphead.utility[utilityheadCount];
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Remove(utility);
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(tempcurrentshipUtility);
                        }
                    }
                    temputilitys = null;

                    break;

                case 2:
                    if (this.currentship.shipBody != null)
                    {
                        if (this.currentship.shipBody.utility.Count > utilitybodyCount)
                        {
                            this.currentship.shipBody.utility[utilitybodyCount] = utility;
                            shipBodyPos.transform.GetChild(1).GetChild(utilitybodyCount).GetComponent<Image>().sprite = utility.iconImage;
                            utilitybodyCount++;
                            weaponButton.gameObject.SetActive(false);
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Remove(utility);
                        }
                        else if (this.currentship.shipBody.utility.Count <= utilitybodyCount)
                        {
                            utilitybodyCount = 0;
                            UtilityData tempcurrentshipUtility = this.currentship.shipBody.utility[utilitybodyCount];
                            this.currentship.shipBody.weapons[utilitybodyCount] = weapons;
                            shipBodyPos.transform.GetChild(1).GetChild(utilitybodyCount).GetComponent<Image>().sprite = utility.iconImage;
                            utilitybodyCount++;
                            weaponButton.gameObject.SetActive(false);
                            tempcurrentshipUtility = this.currentship.shipBody.utility[utilitybodyCount];
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Remove(utility);
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(tempcurrentshipUtility);
                        }
                    }
                    temputilitys = null;

                    break;

                case 3:
                    if (this.currentship.shipTail != null)
                    {
                        if (this.currentship.shipTail.utility.Count > utilitytailCount)
                        {
                            this.currentship.shipTail.utility[utilitytailCount] = utility;
                            shipTailPos.transform.GetChild(1).GetChild(utilitytailCount).GetComponent<Image>().sprite = utility.iconImage;
                            utilitytailCount++;
                            weaponButton.gameObject.SetActive(false);
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Remove(utility);
                        }
                        else if (this.currentship.shipTail.utility.Count <= utilitytailCount)
                        {
                            utilitytailCount = 0;
                            UtilityData tempcurrentshipUtility = this.currentship.shipTail.utility[utilitytailCount];
                            this.currentship.shipTail.utility[utilitytailCount] = utility;
                            shipTailPos.transform.GetChild(1).GetChild(utilitytailCount).GetComponent<Image>().sprite = utility.iconImage;
                            utilitytailCount++;
                            weaponButton.gameObject.SetActive(false);
                            tempcurrentshipUtility = this.currentship.shipTail.utility[utilitytailCount];
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Remove(utility);
                            DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(tempcurrentshipUtility);
                        }
                    }
                    temputilitys = null;

                    break;
            }
            isWeaponSetting = false;
        }
    }

    public void ShipSave()
    {
        saveOn = true;
        if(this.currentship.shipHull != null && this.currentship.shiphead != null && this.currentship.shipBody != null && this.currentship.shipTail != null)
        {
            Debug.Log(this.currentship.shipHull.name);
            Debug.Log(this.currentship.shiphead.name);
            Debug.Log(this.currentship.shipBody.name);
            Debug.Log(this.currentship.shipTail.name);

            DataManager.Instance.playerInfo.MyShips.Add(this.currentship);

            Ship currentship = new Ship();

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

        shipHullpos.transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
        for (int i = 0; i < shipHeadPos.transform.GetChild(0).childCount; i++)
        {
            Debug.Log(shipHeadPos.transform.GetChild(0).childCount + " 이며 i의 값은 : " + i);
            var tempobj = shipHeadPos.transform.GetChild(0).GetChild(i);
            Destroy(tempobj.gameObject);
        }
        for (int i = 0; i < shipHeadPos.transform.GetChild(1).childCount; i++)
        {
            var tempobj = shipHeadPos.transform.GetChild(1).GetChild(i);
            Destroy(tempobj.gameObject);
        }
        for (int i = 0; i < shipBodyPos.transform.GetChild(0).childCount; i++)
        {
            var tempobj = shipBodyPos.transform.GetChild(0).GetChild(i);
            Destroy(tempobj.gameObject);
        }
        for (int i = 0; i < shipBodyPos.transform.GetChild(1).childCount; i++)
        {
            var tempobj = shipBodyPos.transform.GetChild(1).GetChild(i);
            Destroy(tempobj.gameObject);
        }
        for (int i = 0; i < shipTailPos.transform.GetChild(0).childCount; i++)
        {
            Debug.Log(shipTailPos.transform.GetChild(0).childCount + " 이며 i의 값은 : " + i);
            if (shipTailPos.transform.GetChild(0).childCount -1 > 0 )
            {
                var tempobj = shipTailPos.transform.GetChild(0).GetChild(i);
                Destroy(tempobj.gameObject);
            }
        }
        for (int i = 0; i < shipTailPos.transform.GetChild(1).childCount; i++)
        {
            Debug.Log(shipTailPos.transform.GetChild(1).childCount + " 이며 i의 값은 : " + i);
            if (shipTailPos.transform.GetChild(1).childCount > 0)
            {
                var tempobj = shipTailPos.transform.GetChild(1).GetChild(i);
                Destroy(tempobj.gameObject);
            }
        }
    }

    public void RemoveSubItem(PointerEventData eventData)
    {
        var removeItemName = eventData.pointerCurrentRaycast.gameObject.transform.parent.name;
        string number = Regex.Replace(removeItemName, @"\D", "");
        int tempnum = int.Parse(number);

        var removeItemPart = eventData.pointerCurrentRaycast.gameObject.transform.parent.transform.parent.transform.parent.name;
        Debug.Log("현재 선택한 슬롯의 번호는 : " +  tempnum);
        if (currentSelectRemoveItemType == "Weapons")
        {
            if (removeItemPart == "ShipHeadItemSlot")
            {
                DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(this.currentship.shiphead.weapons[tempnum]);
                this.currentship.shiphead.weapons.Remove(this.currentship.shiphead.weapons[tempnum]);
                this.currentship.shiphead.weapons.Insert(tempnum, null);
                shipHeadPos.transform.GetChild(0).GetChild(tempnum).GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
                shipHeadPos.transform.GetChild(0).GetChild(tempnum).GetComponent<Image>().sprite = defaultSlotImage2;
            }
            else if (removeItemPart == "ShipBodyItemSlot")
            {
                DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(this.currentship.shipBody.weapons[tempnum]);
                this.currentship.shipBody.weapons.Remove(this.currentship.shipBody.weapons[tempnum]);
                this.currentship.shipBody.weapons.Insert(tempnum, null);
                shipBodyPos.transform.GetChild(0).GetChild(tempnum).GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
                shipBodyPos.transform.GetChild(0).GetChild(tempnum).GetComponent<Image>().sprite = defaultSlotImage2;
            }
            else if (removeItemPart == "ShipTailItemSlot")
            {
                DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(this.currentship.shipTail.weapons[tempnum]);
                this.currentship.shipTail.weapons.Remove(this.currentship.shipTail.weapons[tempnum]);
                this.currentship.shipTail.weapons.Insert(tempnum, null);
                shipTailPos.transform.GetChild(0).GetChild(tempnum).GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
                shipTailPos.transform.GetChild(0).GetChild(tempnum).GetComponent<Image>().sprite = defaultSlotImage2;
            }
        }
        else if ( currentSelectRemoveItemType == "Utilitys")
        {
            if (removeItemPart == "ShipHeadItemSlot")
            {
                DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(this.currentship.shiphead.utility[tempnum]);
                this.currentship.shiphead.utility.Remove(this.currentship.shiphead.utility[tempnum]);
                this.currentship.shiphead.utility.Insert(tempnum, null);
                shipHeadPos.transform.GetChild(1).GetChild(tempnum).GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
                shipHeadPos.transform.GetChild(1).GetChild(tempnum).GetComponent<Image>().sprite = defaultSlotImage2;
            }
            else if (removeItemPart == "ShipBodyItemSlot")
            {
                DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(this.currentship.shipBody.utility[tempnum]);
                this.currentship.shipBody.utility.Remove(this.currentship.shipBody.utility[tempnum]);
                this.currentship.shipBody.utility.Insert(tempnum, null);
                shipBodyPos.transform.GetChild(1).GetChild(tempnum).GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
                shipBodyPos.transform.GetChild(1).GetChild(tempnum).GetComponent<Image>().sprite = defaultSlotImage2;
            }
            else if (removeItemPart == "ShipTailItemSlot")
            {
                DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(this.currentship.shipTail.utility[tempnum]);
                this.currentship.shipTail.utility.Remove(this.currentship.shipTail.utility[tempnum]);
                this.currentship.shipTail.utility.Insert(tempnum, null);
                shipTailPos.transform.GetChild(1).GetChild(tempnum).GetChild(0).GetComponent<Image>().sprite = defaultSlotImage1;
                shipTailPos.transform.GetChild(1).GetChild(tempnum).GetComponent<Image>().sprite = defaultSlotImage2;
            }
        }
        
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
            
            for ( int i = 0; i < this.currentship.shiphead.weapons.Count; i++)
            {
                if (this.currentship.shiphead.weapons[i] != null)
                {
                    DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(this.currentship.shiphead.weapons[i]);
                    this.currentship.shiphead.weapons.Remove(this.currentship.shiphead.weapons[i]);
                    this.currentship.shiphead.weapons.Insert(i, null);
                }
            }
            for (int i = 0; i < this.currentship.shiphead.utility.Count; i++)
            {
                if (this.currentship.shiphead.utility[i] != null)
                {
                    DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(this.currentship.shiphead.utility[i]);
                    this.currentship.shiphead.utility.Remove(this.currentship.shiphead.utility[i]);
                    this.currentship.shiphead.utility.Insert(i, null);
                }
            }
        }

        if (this.currentship.shipBody != null)
        {
            DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Add(this.currentship.shipBody);

            for (int i = 0; i < this.currentship.shipBody.weapons.Count; i++)
            {
                if (this.currentship.shipBody.weapons[i] != null)
                {
                    DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(this.currentship.shipBody.weapons[i]);
                    this.currentship.shipBody.weapons.Remove(this.currentship.shipBody.weapons[i]);
                    this.currentship.shipBody.weapons.Insert(i, null);
                }
            }
            for (int i = 0; i < this.currentship.shipBody.utility.Count; i++)
            {
                if (this.currentship.shipBody.utility[i] != null)
                {
                    DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(this.currentship.shipBody.utility[i]);
                    this.currentship.shipBody.utility.Remove(this.currentship.shipBody.utility[i]);
                    this.currentship.shipBody.utility.Insert(i, null);
                }
            }
        }

        if (this.currentship.shipTail != null)
        {
            DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Add(this.currentship.shipTail);

            for (int i = 0; i < this.currentship.shipTail.weapons.Count; i++)
            {
                if (this.currentship.shipTail.weapons[i] != null)
                {
                    DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(this.currentship.shipTail.weapons[i]);
                    this.currentship.shipTail.weapons.Remove(this.currentship.shipTail.weapons[i]);
                    this.currentship.shipTail.weapons.Insert(i, null);
                }
            }
            for (int i = 0; i < this.currentship.shipTail.utility.Count; i++)
            {
                if (this.currentship.shipTail.utility[i] != null)
                {
                    DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(this.currentship.shipTail.utility[i]);
                    this.currentship.shipTail.utility.Remove(this.currentship.shipTail.utility[i]);
                    this.currentship.shipTail.utility.Insert(i, null);
                }

            }
        }
    }

    private void OnDisable()
    {
        if( saveOn == false)
        {
            ResetItemList();
        }
    }
}

