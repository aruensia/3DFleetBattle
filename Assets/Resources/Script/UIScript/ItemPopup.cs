using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemPopup : MonoBehaviour
{

    PlayerInfo playerInfo;
    ShopMain shopmain;
    ShipDesign shipdesign;
    public Button itemSlotButton;
    public Sprite defaultSlotImage;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "ShipDesign")
        {
            playerInfo = GameObject.Find("DataManager").GetComponent<PlayerInfo>();
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            shopmain = GameObject.Find("ShopManager").GetComponent<ShopMain>();
            playerInfo = GameObject.Find("DataManager").GetComponent<PlayerInfo>();
        }
        itemSlotButton = GetComponent<Button>();
    }

    public void SetItemChange(GameObject partslot)
    {
        string number = Regex.Replace(partslot.name, @"\D", "");
        int tempnum = int.Parse(number);
        int count = 0;

        switch (tempnum)
        {
            case 0:
                if (DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "ShipHullData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Count > 0)
                {
                    for (int i = 0; i < DataManager.Instance.playerInfo.inventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipHullData"])
                    {
                        ShipHull currentShipHull = (ShipHull)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "ShipHullData";
                    count = 0;
                }
                break;

            case 1:
                if (DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "ShipHeadData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Count > 0)
                {
                    for (int i = 0; i < DataManager.Instance.playerInfo.inventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipHeadData"])
                    {
                        ShipHead currentShipHead = (ShipHead)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHead.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "ShipHeadData";
                    count = 0; Debug.Log("아이템이 있습니다.");
                }
                break;

            case 2:
                if (DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "ShipBodyData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Count > 0)
                {
                    for (int i = 0; i < DataManager.Instance.playerInfo.inventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipBodyData"])
                    {
                        ShipBody currentShipBody = (ShipBody)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipBody.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "ShipBodyData";
                    count = 0;
                }
                break;

            case 3:
                if (DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "ShipTailData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Count > 0)
                {
                    for (int i = 0; i < DataManager.Instance.playerInfo.inventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipTailData"])
                    {
                        ShipTail currentShipTail = (ShipTail)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipTail.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "ShipTailData";
                    count = 0;
                }
                break;

            case 4:
                if (DataManager.Instance.playerInfo.PlayerData["WeaponData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "WeaponData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["WeaponData"].Count > 0)
                {
                    for (int i = 0; i < DataManager.Instance.playerInfo.inventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["WeaponData"])
                    {
                        Weapon currentShipWeapon = (Weapon)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipWeapon.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "WeaponData";
                    count = 0;
                }
                break;

            case 5:
                if (DataManager.Instance.playerInfo.PlayerData["UtilityData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "UtilityData";

                }
                else if (DataManager.Instance.playerInfo.PlayerData["UtilityData"].Count > 0)
                {
                    for (int i = 0; i < DataManager.Instance.playerInfo.inventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["UtilityData"])
                    {
                        UtilityData currentShipUtility = (UtilityData)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipUtility.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "UtilityData";
                    count = 0;
                }
                break;

            case 6:
                if (DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "ShipReactorData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipReactorData"])
                    {
                        ShipReactor currentShipReactor = (ShipReactor)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipReactor.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "ShipReactorData";
                    count = 0;
                }
                break;

            case 7:
                if (DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                    playerInfo.currentSelectDataValue = "ShipThrusterData";
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        playerInfo.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"])
                    {
                        ShipThruster currentShipThruster = (ShipThruster)item;
                        playerInfo.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipThruster.iconImage;
                        count++;
                    }
                    playerInfo.currentSelectDataValue = "ShipThrusterData";
                    count = 0;
                }
                break;
        }
    }

}
