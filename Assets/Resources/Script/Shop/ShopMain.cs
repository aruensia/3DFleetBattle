using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class ShopMain : MonoBehaviour
{
    //상점은 유저 전투 등급에 따라 아이쇼핑할 수 있는 상품 개수가 증가한다.
    //한 번의 전투가 끝날 때마다 아이템의 목록을 새로고침한다. 유저가 특정 상품을 구매할 경우, 솔드아웃이 되어, 더이상 목록에 상품이 생성되지 않는다.
    ShipDesign shipDesign;

    Dictionary<string, List<ScriptableObject>> sellListShipData = new Dictionary<string, List<ScriptableObject>>();

    List<ScriptableObject> tempshopItemList = new List<ScriptableObject>(); // 상점에서 파는 아이템 목록
    List<List<ScriptableObject>> totalshopItemList = new List<List<ScriptableObject>>(); // sellListShipData에서 받은 딕셔너리를 상점에서 사용하기 위해 저장한 리스트.
    List<List<ScriptableObject>> partItemList = new List<List<ScriptableObject>>(); // 
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>(); //드롭다운 목록에 사용하는 키를 저장할 리스트
    List<ScriptableObject> sellItemList = new List<ScriptableObject>();
    List<List<ScriptableObject>> tempTotalShopItem;

    [SerializeField] TMP_Dropdown dropdown; //유저가 구매할 아이템에 대한 상점 목록
    Button TempSelctShipHullButton;
    List<GameObject> currentShopItemList = new List<GameObject>();
    List<DefaultShipPart> currentsShopShipDatas = new List<DefaultShipPart>();
    List<GameObject> tempInventorylist = new List<GameObject>();
    List<int> slotPartList = new List<int>();


    public Text shipPartName;
    public GameObject shopItemPrefab;
    public GameObject itemSlot;
    public GameObject partSlot;
    public ScriptableObject tempSelectShopItem;
    Transform tempcanvas;
    public Transform userInven;
    public GameObject buyItemPopup;

    bool isScenesOn = true;
    bool[] itemBuyCheck;

    [SerializeField] int shopListCount;
    int tempInventoryCount;
    int itemItemRange;

    public GameObject[] activityUIControl;

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
        activityUIControl[1].GetComponent<Button>().onClick.AddListener(() => BuyItem(itemItemRange));
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
        CreateItemSlot();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("MainScene");
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            AddItemInUserInventory();
        }
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 로드 됌");
        shipDesign = GetComponent<ShipDesign>();
        GetForManagerShipData();
        DropdownDataInit();
        LoadShopData();
        CreatePartSlot();
    }

    public void OnDropdownEvent(int index) //유저가 선택한 드랍목록의 int값을 인자로 넘김
    {

        for( int i = 0; i < currentShopItemList.Count; i++ )
        {
            Destroy(currentShopItemList[i]);
        }
 
        ShowShopItem(tempTotalShopItem[index]);
    }

    public void GetForManagerShipData()
    {
        sellListShipData = DataManager.Instance.getNewDataList.AllShipDataDic;
        //메인 데이터에서 불러온 게임 데이터를 판매할 목록에 넣어놓음.
    }

    public void InitSceneChange()
    {
        isScenesOn = true;
        //씬 전환 기능이 완료될 경우 사라지는 함수.
    }

    void DropdownDataInit() //드롭다운 목록에 들어갈 값의 List를 생성함
    {
        if ( isScenesOn == true)
        {
            dropdown.ClearOptions();
            foreach (var dic in sellListShipData)
            {
                optionsList.Add(new TMP_Dropdown.OptionData(dic.Key));
            }

            dropdown.AddOptions(optionsList);
            dropdown.value = 0;
        }
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
                    tempshopItemList.Add(sellListShipData[optionsList[i].text][j]);
                }
            }
            else
            {
                Debug.LogWarning($"sellListShipData의 키가 없습니다.");
            }

            totalshopItemList.Add(tempshopItemList);

            if(i != optionsList.Count)
            {
                tempshopItemList = new List<ScriptableObject>();
            }
        }
        tempTotalShopItem = totalshopItemList;
    }

    void ShowShopItem(List<ScriptableObject> itemvalue)
    {
        int itemGradeRange = Random.Range(1, (int)Grade.end);
        string[] tempitemname = new string[itemvalue.Count];
        DefaultShipPart tempdata;
        Text shipPartName;
        int count = 0;
        itemBuyCheck = new bool[shopListCount];

        currentsShopShipDatas.Clear();
        sellItemList.Clear();

        foreach ( var item in itemvalue)
        {
            tempdata = item as DefaultShipPart;
            currentsShopShipDatas.Add(tempdata);
            sellItemList.Add(tempdata);

            Debug.Log("--s---ss--" + tempdata.defaultShipPartName);

            if (tempdata.defaultShipPartName == null)
            {
                Debug.Log("tempitem.defaultShipPartName의 값이 비어있음");
                Debug.Log($"카운트값은 : {count}");
            }
            else
            {
                tempitemname[count] = tempdata.defaultShipPartName;
                count++;
            }
        }

        for (int i = 0; i < itemvalue.Count; i++)
        {
            itemItemRange = Random.Range(1, itemvalue.Count);
            var a = Instantiate(shopItemPrefab, tempcanvas);
            currentShopItemList.Add(a);
            a.name = "ShipItemList" + itemvalue[i];
            a.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => SetButPopup());
            //a.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => BuyItem(itemItemRange));
            shipPartName = a.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>();

            if (itemvalue[itemItemRange] == null)
            {
                shipPartName.text = " ";
            }
            else
            {
                shipPartName.text = tempitemname[itemItemRange];
            }
            a.transform.Translate(i * 180, -20, 0);
        }
    }

    public void AddTempShipHull()
    {
        currentHullName.text = shipDesign.currentship.shipHull.hullName.ToString();
        currentHullHp.text = "체   력 : " + shipDesign.currentship.shipHull.hulltHp.ToString();
    }

    void CreateItemSlot()
    {
        tempInventoryCount = DataManager.Instance.playerInfo.inventoryCount;

        for (int i = 0; i < tempInventoryCount; i++)
        {
            var inventory = Instantiate(itemSlot, userInven.transform.GetChild(1));
            tempInventorylist.Add(inventory);
        }
    }

    void CreatePartSlot()
    {
        List<string> slots = new List<string>();
        int slotPartvalue = 0;

        foreach (var inventory in sellListShipData)
        {
            slots.Add(inventory.Key);
        }

        for ( int i = 0;i < sellListShipData.Count; i++)
        {
            var temppartslot = Instantiate(partSlot, userInven.transform.GetChild(0));
            temppartslot.name = "PartSlot" + i;
            temppartslot.GetComponent<Button>().onClick.AddListener(() => SetItemChange(temppartslot));
           
            slotPartList.Add(slotPartvalue);
            slotPartvalue++;

            switch (slots[i])
            {
                case "ShipHullData":
                    temppartslot.GetComponentInChildren<Text>().text = "함선 함체";
                    break;

                case "ShipHeadData":
                    temppartslot.GetComponentInChildren<Text>().text = "선두";
                    break;


                case "ShipBodyData":
                    temppartslot.GetComponentInChildren<Text>().text = "선체";
                    break;

                case "ShipTailData":
                    temppartslot.GetComponentInChildren<Text>().text = "선미";
                    break;

                case "WeaponData":
                    temppartslot.GetComponentInChildren<Text>().text = "무기";
                    break;

                case "UtilityData":
                    temppartslot.GetComponentInChildren<Text>().text = "보조장치";
                    break;

                case "ShipReactorData":
                    temppartslot.GetComponentInChildren<Text>().text = "반응로";
                    break;

                case "ShipThrusterData":
                    temppartslot.GetComponentInChildren<Text>().text = "추진체";
                    break;
            }
        }
    }

    void AddItemInUserInventory()
    {
        string addItemType = tempSelectShopItem.GetType().FullName;

        DataManager.Instance.playerInfo.PlayerData[addItemType + "Data"].Add(tempSelectShopItem);
        Debug.Log($"데이터 받아옴 {DataManager.Instance.playerInfo.PlayerData[addItemType + "Data"][0].name}");
    }

    void SetItemChange(GameObject partslot)
    {
        string number = Regex.Replace(partslot.name, @"\D", "");
        int tempnum = int.Parse(number);
        int tempCount = 0;

        switch(tempnum)
        {
            case 0:
                if(DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Count == 0 )
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if(DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 1:
                if (DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 2:
                if (DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 3:
                if (DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 4:
                if (DataManager.Instance.playerInfo.PlayerData["WeaponData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["WeaponData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 5:
                if (DataManager.Instance.playerInfo.PlayerData["UtilityData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["UtilityData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 6:
                if (DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;

            case 7:
                if (DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Count == 0)
                {
                    Debug.Log("아이템이 없습니다.");
                }
                else if (DataManager.Instance.playerInfo.PlayerData["ShipThrusterData"].Count > 0)
                {
                    Debug.Log("아이템이 있습니다.");
                }
                break;
        }
    }

    void SetButPopup()
    {
        activityUIControl[0].SetActive(true);
    }

    void BuyItem(int value)
    {
        Debug.Log("호출이 안됌!!!!");

        activityUIControl[0].SetActive(true);

        string type = sellItemList[value].GetType().FullName;
        switch (type)
        {
            case "ShipHull":

                ShipHull shipHull = currentsShopShipDatas[value] as ShipHull;
                if (shipHull.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipHull.defaultShipPartCost;
                    Debug.Log($"{shipHull.hullName}");
                    Debug.Log($"{DataManager.Instance.playerInfo.Money}");
                    DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Add(shipHull);
                    Debug.Log($"{DataManager.Instance.playerInfo.PlayerData["ShipHullData"].Count}");
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipHead":

                ShipHead shipHead = currentsShopShipDatas[value] as ShipHead;
                if (shipHead.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipHead.defaultShipPartCost;
                    Debug.Log($"{shipHead.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipHeadData"].Add(shipHead);
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipBody":

                ShipBody shipBody = currentsShopShipDatas[value] as ShipBody;
                if (shipBody.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipBody.defaultShipPartCost;
                    Debug.Log($"{shipBody.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipBodyData"].Add(shipBody);
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipTail":

                ShipTail shipTail = currentsShopShipDatas[value] as ShipTail;
                if (shipTail.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipTail.defaultShipPartCost;
                    Debug.Log($"{shipTail.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipTailData"].Add(shipTail);
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "Weapon":

                Weapon weapon = currentsShopShipDatas[value] as Weapon;
                if (weapon.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - weapon.defaultShipPartCost;
                    Debug.Log($"{weapon.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["WeaponData"].Add(weapon);
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "UtilityData":

                UtilityData utilityData = currentsShopShipDatas[value] as UtilityData;
                if (utilityData.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - utilityData.defaultShipPartCost;
                    Debug.Log($"{utilityData.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["UtilityData"].Add(utilityData);
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipReactor":

                ShipReactor shipReactor = currentsShopShipDatas[value] as ShipReactor;
                if (shipReactor.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipReactor.defaultShipPartCost;
                    Debug.Log($"{shipReactor.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Add(shipReactor);
                    //tempSelectShopItem = shipReactor;
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;

            case "ShipThruster":

                ShipThruster shipThruster = currentsShopShipDatas[value] as ShipThruster;
                if (shipThruster.defaultShipPartCost < DataManager.Instance.playerInfo.Money)
                {
                    DataManager.Instance.playerInfo.Money = DataManager.Instance.playerInfo.Money - shipThruster.defaultShipPartCost;
                    Debug.Log($"{shipThruster.defaultShipPartName}");
                    DataManager.Instance.playerInfo.PlayerData["ShipReactorData"].Add(shipThruster);
                }
                else
                {
                    Debug.Log("보유한 돈이 모자랍니다.");
                }
                break;
        }
    }




    private void OnDisable()
    {
        tempSelectShopItem = null;
    }

}   