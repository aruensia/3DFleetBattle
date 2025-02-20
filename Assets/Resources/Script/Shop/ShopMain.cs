using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using static UnityEditor.Progress;

public class ShopMain : MonoBehaviour
{
    ItemPopup invenSlot;
    PlayerInfo playerInfo;

    Dictionary<string, List<ScriptableObject>> sellListShipData = new Dictionary<string, List<ScriptableObject>>();

    List<DefaultShipPart> tempshopItemList = new List<DefaultShipPart>(); // 상점에서 파는 아이템 목록
    List<List<DefaultShipPart>> totalshopItemList = new List<List<DefaultShipPart>>(); // sellListShipData에서 받은 딕셔너리를 상점에서 사용하기 위해 저장한 리스트.
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>(); //드롭다운 목록에 사용하는 키를 저장할 리스트
    List<List<DefaultShipPart>> tempTotalShopItem;

    [SerializeField] TMP_Dropdown dropdown; //유저가 구매할 아이템에 대한 상점 목록
    List<GameObject> currentShopItemList = new List<GameObject>();  // 드롭다운 목록에 사용하는 아이템 리스트
    List<DefaultShipPart> currentsShopShipDatas = new List<DefaultShipPart>();
    public List<GameObject> tempInventorylist = new List<GameObject>();
    List<int> slotPartList = new List<int>();
    List<DefaultShipPart> tempGetItemList = new List<DefaultShipPart>();

    public Text shipPartName;
    public GameObject shopItemPrefab;
    public GameObject tempselectItem;
    public GameObject itemRefresh;
    public GameObject playerMoney;
    Transform tempcanvas;
    public GameObject buyItemPopup;

    public int tempInventoryCount;
    int itemItemRange;
    int itemGradeRange;
    int currentDropDownNum;
    GameObject expectBuyItem;
    List<bool> buyCheckList = new List<bool>();

    public int maxListCount = 6;
    DefaultShipPart currentSelectItem;
    public GameObject[] activityUIControl;

    public List<Text> itemDefalutData = new List<Text>();
    public List<Text> head = new List<Text>();
    public List<Text> body = new List<Text>();
    public List<Text> tail = new List<Text>();
    public List<Text> hull = new List<Text>();
    public List<Text> weapon = new List<Text>();
    public List<Text> shild = new List<Text>();
    public List<Text> defence = new List<Text>();
    public List<Text> thruster = new List<Text>();
    public List<Text> reactor = new List<Text>();

    //------------------------------------------------------------------
    #region 유저가 디자인중인 함선

    public Text currentHullName;
    public Text currentHullHp;
    public Text currentHullArmor;


    #endregion
    private void Start()
    {
        //TempSelctShipHullButton = GameObject.Find("TempUserShipSetting").transform.GetChild(4).GetComponent<Button>();
        //TempSelctShipHullButton.onClick.AddListener(() => shipDesign.SetShipHull(tempSelectShopItem));
        //TempSelctShipHullButton.onClick.AddListener(() => AddTempShipHull());
        tempcanvas = GameObject.Find("Canvas").transform.GetChild(3).GetComponent<Transform>(); // 드랍목록 아이템이 생성될 부모의 위치
        invenSlot = GameObject.Find("CurrentItemPopup").GetComponent<ItemPopup>();
        activityUIControl[1].GetComponent<Button>().onClick.AddListener(() => BuyItem(itemItemRange, expectBuyItem));
        activityUIControl[2].GetComponent<Button>().onClick.AddListener(() => ColseBuyPopup());
        itemRefresh.GetComponent<Button>().onClick.AddListener(() => ShowShopItem(tempTotalShopItem[currentDropDownNum]));
        playerMoney.GetComponent<Text>().text = "보유 재화 : " + DataManager.Instance.playerInfo.Money.ToString();
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
        GetText();
        //CreateItemSlot();
    }

    private void OnEnable()
    {
        playerInfo = GameObject.Find("DataManager").GetComponent<PlayerInfo>();
        GetForManagerShipData();
        DropdownDataInit();
        LoadShopData();
        Debug.Log("OnEnable 로드 됌");
        //CreatePartSlot();
    }

    void GetText()
    {
        itemDefalutData[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>();
        itemDefalutData[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>();
        itemDefalutData[2] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Text>();
        hull[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>();
        weapon[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>();
        weapon[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(11).GetComponent<Text>();
        weapon[2] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(12).GetComponent<Text>();
        shild[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>();
        shild[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(13).GetComponent<Text>();
        defence[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>();
        defence[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(13).GetComponent<Text>();
        thruster[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(9).GetComponent<Text>();
        thruster[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(13).GetComponent<Text>();
        reactor[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(10).GetComponent<Text>();
        head[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(14).GetComponent<Text>();
        head[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(15).GetComponent<Text>();
        body[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(14).GetComponent<Text>();
        body[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(15).GetComponent<Text>();
        tail[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(14).GetComponent<Text>();
        tail[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(15).GetComponent<Text>();

    }

    void falseText()
    {
        itemDefalutData[0].gameObject.SetActive(false);
        itemDefalutData[1].gameObject.SetActive(false);
        itemDefalutData[2].gameObject.SetActive(false);
        hull[0].gameObject.SetActive(false);
        weapon[0].gameObject.SetActive(false);
        weapon[1].gameObject.SetActive(false);
        weapon[2].gameObject.SetActive(false);
        shild[0].gameObject.SetActive(false);
        shild[1].gameObject.SetActive(false);
        defence[0].gameObject.SetActive(false);
        defence[1].gameObject.SetActive(false);
        thruster[0].gameObject.SetActive(false);
        thruster[1].gameObject.SetActive(false);
        reactor[0].gameObject.SetActive(false);
        head[0].gameObject.SetActive(false);
        head[1].gameObject.SetActive(false);
        body[0].gameObject.SetActive(false);
        body[1].gameObject.SetActive(false);
        tail[0].gameObject.SetActive(false);
        tail[1].gameObject.SetActive(false);
    }

    public void OnDropdownEvent(int index) //유저가 선택한 드랍목록의 int값을 인자로 넘김
    {
        for( int i = 0; i < currentShopItemList.Count; i++ )
        {
            Destroy(currentShopItemList[i]);
        }

        currentDropDownNum = index;
        ShowShopItem(tempTotalShopItem[index]);
    }

    public void GetForManagerShipData()
    {
        sellListShipData = DataManager.Instance.getNewDataList.AllShipDataDic;
        //메인 데이터에서 불러온 게임 데이터를 판매할 목록에 넣어놓음.
    }

    void DropdownDataInit() //드롭다운 목록에 들어갈 값의 List를 생성함
    {
        dropdown.ClearOptions();
        foreach (var dic in sellListShipData)
        {
            optionsList.Add(new TMP_Dropdown.OptionData(dic.Key));
        }

        dropdown.AddOptions(optionsList);
        dropdown.value = 0;
    }

    public void LoadShopData()
    {
        Debug.Log("LoadShopData 호출");
        for (int i = 0; i < optionsList.Count; i++)
        {
            if(sellListShipData.ContainsKey(optionsList[i].text)) //만일 키가 있을 경우 List에 상품 목록을 넣고 없을 경우 오류를 내놓음.
            {
                for (int j = 0; j < sellListShipData[optionsList[i].text].Count; j++)
                {

                    tempshopItemList.Add(sellListShipData[optionsList[i].text][j] as DefaultShipPart);
                }
            }

            else
            {
                Debug.LogWarning($"sellListShipData의 키가 없습니다.");
            }

            totalshopItemList.Add(tempshopItemList);

            if(i != optionsList.Count)
            {
                tempshopItemList = new List<DefaultShipPart>();
            }
        }
        tempTotalShopItem = totalshopItemList;
    }

    void ShowShopItem(List<DefaultShipPart> itemvalue)
    {
        for (int i = 0; i < currentShopItemList.Count; i++)
        {
            Destroy(currentShopItemList[i]);
        }

        string[] tempitemname = new string[itemvalue.Count];
        int count = 0;

        currentsShopShipDatas.Clear();
        tempGetItemList.Clear();
        buyCheckList.Clear();

        while (true)
        {
            itemGradeRange = Random.Range(0, 100);
            int tempGradeRange = itemGradeRange;
            if (tempGradeRange > (int)Grade.LostTech)
            {
                foreach (var item in itemvalue)
                {
                    if (item.DefaultShipPartGrade == Grade.LostTech)
                    {
                        if (tempGetItemList.Count == maxListCount)
                        {
                            break;
                        }
                        else
                        {
                            tempGetItemList.Add(item);
                        }
                    }
                }
            }
            else if (tempGradeRange > (int)Grade.HighTech)
            {
                foreach (var item in itemvalue)
                {
                    if (item.DefaultShipPartGrade == Grade.HighTech)
                    {
                        if (tempGetItemList.Count == maxListCount)
                        {
                            break;
                        }
                        else
                        {
                            tempGetItemList.Add(item);
                        }
                    }
                }
            }
            else if (tempGradeRange > (int)Grade.Military)
            {
                foreach (var item in itemvalue)
                {
                    if (item.DefaultShipPartGrade == Grade.Military)
                    {
                        if (tempGetItemList.Count == maxListCount)
                        {
                            break;
                        }
                        else
                        {
                            tempGetItemList.Add(item);
                        }
                    }
                }
            }
            else if (tempGradeRange <= (int)Grade.Normal )
            {
                foreach (var item in itemvalue)
                {
                    if (item.DefaultShipPartGrade == Grade.Normal)
                    {
                        if (tempGetItemList.Count == maxListCount)
                        {
                            break;
                        }
                        else
                        {
                            tempGetItemList.Add(item);
                        }
                    }
                }
            }

            if (tempGetItemList.Count == maxListCount)
            {
                break;
            }
        }

        foreach (var item in tempGetItemList)
        {
            currentsShopShipDatas.Add(item);

            if (item.defaultShipPartName == null)
            {
                Debug.Log("tempitem.defaultShipPartName의 값이 비어있음");
                Debug.Log($"카운트값은 : {count}");
            }
            else
            {
                tempitemname[count] = item.defaultShipPartName;
                count++;
            }
        }

        for (int i = 0; i < tempGetItemList.Count; i++)
        {
            itemItemRange = Random.Range(0, tempGetItemList.Count);
            int tempint = itemItemRange;
            var a = Instantiate(shopItemPrefab, tempcanvas);
            a.name = "shopItem" + i;
            buyCheckList.Add(a);
            a.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = tempitemname[itemItemRange];

            a.transform.Translate(i * 180, -20, 0);
            currentShopItemList.Add(a);
            a.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => SetBuyPopup(tempint, a));
        }
        Debug.Log(buyCheckList.Count);
    }

    //void CreateItemSlot()
    //{
    //    tempInventoryCount = DataManager.Instance.playerInfo.inventoryCount;
    //
    //    for (int i = 0; i < tempInventoryCount; i++)
    //    {
    //        var inventory = Instantiate(itemSlot, userInven.transform.GetChild(1));
    //        tempInventorylist.Add(inventory);
    //    }
    //}

    //void CreatePartSlot()
    //{
    //    List<string> slots = new List<string>();
    //    int slotPartvalue = 0;
    //
    //    foreach (var inventory in sellListShipData)
    //    {
    //        slots.Add(inventory.Key);
    //    }
    //
    //    for ( int i = 0; i < sellListShipData.Count; i++)
    //    {
    //        var temppartslot = Instantiate(partSlot, userInven.transform.GetChild(0));
    //        temppartslot.name = "PartSlot" + i;
    //
    //        temppartslot.GetComponent<Button>().onClick.AddListener(() => invenSlot.SetItemChange(temppartslot));
    //        slotPartList.Add(slotPartvalue);
    //        slotPartvalue++;
    //
    //        switch (slots[i])
    //        {
    //            case "ShipHullData":
    //                temppartslot.GetComponentInChildren<Text>().text = "함선 함체";
    //                break;
    //
    //            case "ShipHeadData":
    //                temppartslot.GetComponentInChildren<Text>().text = "선두";
    //                break;
    //
    //            case "ShipBodyData":
    //                temppartslot.GetComponentInChildren<Text>().text = "선체";
    //                break;
    //
    //            case "ShipTailData":
    //                temppartslot.GetComponentInChildren<Text>().text = "선미";
    //                break;
    //
    //            case "WeaponData":
    //                temppartslot.GetComponentInChildren<Text>().text = "무기";
    //                break;
    //
    //            case "UtilityData":
    //                temppartslot.GetComponentInChildren<Text>().text = "보조장치";
    //                break;
    //
    //            case "ShipReactorData":
    //                temppartslot.GetComponentInChildren<Text>().text = "반응로";
    //                break;
    //
    //            case "ShipThrusterData":
    //                temppartslot.GetComponentInChildren<Text>().text = "추진체";
    //                break;
    //        }
    //    }
    //}

    void SetBuyPopup(int value, GameObject item)
    {
        falseText();
        expectBuyItem = item;

        itemDefalutData[0].gameObject.SetActive(true);
        itemDefalutData[1].gameObject.SetActive(true);
        itemDefalutData[2].gameObject.SetActive(true);
        currentSelectItem = currentsShopShipDatas[value];

        string type = currentSelectItem.GetType().FullName;


        switch (type)
        {
            case "ShipHull":
                ShipHull tempHull = (ShipHull)currentSelectItem;
                hull[0].gameObject.SetActive(true);
                itemDefalutData[0].text = "이     름 : " + tempHull.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempHull.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempHull.DefaultShipPartGrade.ToString();
                hull[0].text = "체     력 : " + tempHull.hulltHp.ToString();
                break;

            case "ShipHead":
                head[0].gameObject.SetActive(true);
                head[1].gameObject.SetActive(true);
                ShipHead tempHead = (ShipHead)currentSelectItem;
                itemDefalutData[0].text = "이     름 : " + tempHead.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempHead.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempHead.DefaultShipPartGrade.ToString();
                head[0].text = "사용 무기 개수 : " + tempHead.weapons.Count;
                head[1].text = "사용 무기 개수 : " + tempHead.utility.Count;

                break;

            case "ShipBody":
                body[0].gameObject.SetActive(true);
                body[1].gameObject.SetActive(true);
                ShipBody tempBody = (ShipBody)currentSelectItem;
                itemDefalutData[0].text = "이     름 : " + tempBody.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempBody.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempBody.DefaultShipPartGrade.ToString();
                body[0].text = "사용 무기 개수 : " + tempBody.weapons.Count;
                body[1].text = "사용 무기 개수 : " + tempBody.utility.Count;
                break;


            case "ShipTail":
                tail[0].gameObject.SetActive(true);
                tail[1].gameObject.SetActive(true);
                ShipTail tempTail = (ShipTail)currentSelectItem;
                itemDefalutData[0].text = "이     름 : " + tempTail.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempTail.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempTail.DefaultShipPartGrade.ToString();
                tail[0].text = "사용 무기 개수 : " + tempTail.weapons.Count;
                tail[1].text = "사용 무기 개수 : " + tempTail.utility.Count;
                break;


            case "Weapon":
                Weapon tempWeapon = (Weapon)currentSelectItem;
                weapon[0].gameObject.SetActive(true);
                weapon[1].gameObject.SetActive(true);
                weapon[2].gameObject.SetActive(true);
                weapon[3].gameObject.SetActive(true);


                itemDefalutData[0].text = "이     름 : " + tempWeapon.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempWeapon.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempWeapon.DefaultShipPartGrade.ToString();
                weapon[0].text = "공 격 력 : " + tempWeapon.damage;
                weapon[1].text = "공격속도 : " + tempWeapon.attackRange;
                weapon[2].text = "공격거리 : " + tempWeapon.attackSpeed;
                weapon[3].text = "전력소모 : " + tempWeapon.usePower;
                break;

            case "UtilityData":
                UtilityData tempUtility = (UtilityData)currentSelectItem;
                if (Utility.Shields == tempUtility.utility)
                {
                    shild[0].gameObject.SetActive(true);
                    shild[1].gameObject.SetActive(true);

                    itemDefalutData[0].text = "이     름 : " + tempUtility.defaultShipPartName;
                    itemDefalutData[1].text = "함     급 : " + tempUtility.defaultShipPartClass.ToString();
                    itemDefalutData[2].text = "등     급 : " + tempUtility.DefaultShipPartGrade.ToString();
                    shild[0].text = "보 호 막 : " + tempUtility.shild;
                    shild[1].text = "전력소모 : " + tempUtility.usePower;
                }
                else if (Utility.Armor == tempUtility.utility)
                {
                    defence[0].gameObject.SetActive(true);
                    defence[1].gameObject.SetActive(true);

                    itemDefalutData[0].text = "이     름 : " + tempUtility.defaultShipPartName;
                    itemDefalutData[1].text = "함     급 : " + tempUtility.defaultShipPartClass.ToString();
                    itemDefalutData[2].text = "등     급 : " + tempUtility.DefaultShipPartGrade.ToString();
                    defence[0].text = "방어력 : " + tempUtility.defence;
                    defence[1].text = "방어력 : " + tempUtility.usePower;
                }
                break;

            case "ShipReactor":
                reactor[0].gameObject.SetActive(true);

                ShipReactor tempReactor = (ShipReactor)currentSelectItem;
                itemDefalutData[0].text = "이     름 : " + tempReactor.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempReactor.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempReactor.DefaultShipPartGrade.ToString();
                reactor[0].text = "최대전력 : " + tempReactor.reactorPower;
                break;

            case "ShipThruster":
                thruster[0].gameObject.SetActive(true);
                thruster[1].gameObject.SetActive(true);

                ShipThruster tempThruster = (ShipThruster)currentSelectItem;
                itemDefalutData[0].text = "이     름 : " + tempThruster.defaultShipPartName;
                itemDefalutData[1].text = "함     급 : " + tempThruster.defaultShipPartClass.ToString();
                itemDefalutData[2].text = "등     급 : " + tempThruster.DefaultShipPartGrade.ToString();
                thruster[0].text = "이동속도 : " + tempThruster.thrusterSpeed;
                thruster[1].text = "최대전력 : " + tempThruster.usePower;
                break;
        }

        activityUIControl[0].SetActive(true);
        activityUIControl[3].GetComponent<CanvasGroup>().interactable = false;
    }

    void ColseBuyPopup()
    {
        activityUIControl[0].SetActive(false);
        activityUIControl[3].GetComponent<CanvasGroup>().interactable = true;
    }

    void BuyItem(int value, GameObject item)
    {
        string type = currentSelectItem.GetType().FullName;

        string number = Regex.Replace(item.name, @"\D", "");
        int tempnum = int.Parse(number);

        switch (type)
        {
            case "ShipHull":
                
                //if(buyCheckList[tempnum] == true)
                //{
                  ShipHull shipHull = currentSelectItem as ShipHull;
                  if (shipHull.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                  {
                      DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipHull.defaultShipPartCost;
                      DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Add(shipHull);
                      buyCheckList[tempnum] = false;
                  }
                  else
                  {
                      Debug.Log("보유한 돈이 모자랍니다.");
                  }

                //}
                //else
                //{
                //    Debug.Log("이미 구입한 아이템 입니다.");
                //}

                break;

            case "ShipHead":

                //if (buyCheckList[tempnum] == true)
                //{
                  ShipHead shipHead = currentSelectItem as ShipHead;
                  if (shipHead.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                  {
                      DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipHead.defaultShipPartCost;
                      DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Add(shipHead);
                      buyCheckList[tempnum] = false;
                  }
                  else
                  {
                      Debug.Log("보유한 돈이 모자랍니다.");
                  }
                //}
                //else
                //{
                //    Debug.Log("이미 구입한 아이템 입니다.");
                //}

                break;

            case "ShipBody":

                //if (buyCheckList[tempnum] == true)
                //{
                  ShipBody shipBody = currentSelectItem as ShipBody;
                  if (shipBody.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                  {
                      DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipBody.defaultShipPartCost;
                      Debug.Log($"{shipBody.defaultShipPartName}");
                      DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Add(shipBody);
                      buyCheckList[tempnum] = false;

                  }
                  else
                  {
                      Debug.Log("보유한 돈이 모자랍니다.");
                  }
                //}
                //else
                //{
                    //Debug.Log("이미 구입한 아이템 입니다.");
                //}

                break;

            case "ShipTail":

                ShipTail shipTail = currentSelectItem as ShipTail;
                if (shipTail.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipTail.defaultShipPartCost;
                    Debug.Log($"{shipTail.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Add(shipTail);
                    buyCheckList[tempnum] = false;
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "Weapon":

                Weapon weapon = currentSelectItem as Weapon;
                if (weapon.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - weapon.defaultShipPartCost;
                    Debug.Log($"{weapon.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(weapon);
                    buyCheckList[tempnum] = false;
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "UtilityData":

                UtilityData utilityData = currentSelectItem as UtilityData;
                if (utilityData.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - utilityData.defaultShipPartCost;
                    Debug.Log($"{utilityData.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(utilityData);
                    buyCheckList[tempnum] = false;
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipReactor":

                ShipReactor shipReactor = currentSelectItem as ShipReactor;
                if (shipReactor.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipReactor.defaultShipPartCost;
                    Debug.Log($"{shipReactor.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Add(shipReactor);
                    buyCheckList[tempnum] = false;
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipThruster":

                ShipThruster shipThruster = currentSelectItem as ShipThruster;
                if (shipThruster.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipThruster.defaultShipPartCost;
                    Debug.Log($"{shipThruster.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Add(shipThruster);
                    buyCheckList[tempnum] = false;
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;
        }
        playerMoney.GetComponent<Text>().text = "보유 재화 : " + DataManager.Instance.playerInfo.Money.ToString(); DataManager.Instance.playerInfo.Money.ToString();
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

}   