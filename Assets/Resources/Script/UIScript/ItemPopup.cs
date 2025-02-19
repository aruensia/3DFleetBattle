using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{
    int inventoryCount;
    ShopMain shopmain;
    ShipDesign shipdesign;
    public Sprite defaultSlotImage;

    private void Start()
    {
        shopmain = GameObject.Find("ShopManager").GetComponent<ShopMain>();
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
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipHullData"])
                    {
                        ShipHull currentShipHull = (ShipHull)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;

            case 1:
                if (DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipHeadData"])
                    {
                        ShipHead currentShipHull = (ShipHead)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0; Debug.Log("아이템이 있습니다.");
                }
                break;

            case 2:
                if (DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipBodyData"])
                    {
                        ShipBody currentShipHull = (ShipBody)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;

            case 3:
                if (DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipTailData"])
                    {
                        ShipTail currentShipHull = (ShipTail)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;

            case 4:
                if (DataManager.Instance.playerInfo.PlayerData["WeaponData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["WeaponData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["WeaponData"])
                    {
                        Weapon currentShipHull = (Weapon)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;

            case 5:
                if (DataManager.Instance.playerInfo.PlayerData["UtilityData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["UtilityData"].Count > 0)
                {
                    for (int i = 0; i < inventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["UtilityData"])
                    {
                        UtilityData currentShipHull = (UtilityData)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;

            case 6:
                if (DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipReactorData"])
                    {
                        ShipReactor currentShipHull = (ShipReactor)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;

            case 7:
                if (DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Count > 0)
                {
                    for (int i = 0; i < shopmain.tempInventoryCount; i++)
                    {
                        shopmain.tempInventorylist[i].transform.GetChild(0).GetComponent<Image>().sprite = defaultSlotImage;
                    }

                    foreach (var item in DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"])
                    {
                        ShipThruster currentShipHull = (ShipThruster)item;
                        shopmain.tempInventorylist[count].transform.GetChild(0).GetComponent<Image>().sprite = currentShipHull.iconImage;
                        count++;
                    }
                    count = 0;
                }
                break;
        }
    }

}
