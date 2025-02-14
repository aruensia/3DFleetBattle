using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMain : MonoBehaviour
{
    //상점은 유저 전투 등급에 따라 아이쇼핑할 수 있는 상품 개수가 증가한다.
    //한 번의 전투가 끝날 때마다 아이템의 목록을 새로고침한다. 유저가 특정 상품을 구매할 경우, 솔드아웃이 되어, 더이상 목록에 상품이 생성되지 않는다.
    ShipDesign shipDesign;

    Dictionary<string, List<ScriptableObject>> sellListShipData = new Dictionary<string, List<ScriptableObject>>();

    List<ScriptableObject> tempshopItemList = new List<ScriptableObject>(); // 상점에서 파는 아이템 목록
    List<List<ScriptableObject>> totalshopItemList = new List<List<ScriptableObject>>(); // sellListShipData에서 받은 딕셔너리를 상점에서 사용하기 위해 저장한 리스트.
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>(); //드롭다운 목록에 사용하는 키를 저장할 리스트
    List<ScriptableObject> sellItemList = new List<ScriptableObject>();
    List<List<ScriptableObject>> tempTotalShopItem;

    [SerializeField] TMP_Dropdown dropdown; //유저가 구매할 아이템에 대한 상점 목록
    Button TempSelctShipHullButton;
    public List<GameObject> ShipPartSlot = new List<GameObject>();
    List<GameObject> currentShopItemList = new List<GameObject>();
    List<DefaultShipPart> currentsShopShipDatas = new List<DefaultShipPart>();


    public Text shipPartName;
    public GameObject shopItemPrefab;
    public ScriptableObject tempSelectShopItem;
    Transform tempcanvas;

    bool isScenesOn = true;
    bool[] itemBuyCheck;

    [SerializeField] int shopListCount;

    //------------------------------------------------------------------
    #region 유저가 디자인중인 함선

    public Text currentHullName;
    public Text currentHullHp;
    public Text currentHullArmor;


    #endregion
    private void Start()
    {
        TempSelctShipHullButton = GameObject.Find("TempUserShipSetting").transform.GetChild(4).GetComponent<Button>();
        TempSelctShipHullButton.onClick.AddListener(() => shipDesign.SetShipHull(tempSelectShopItem));
        TempSelctShipHullButton.onClick.AddListener(() => AddTempShipHull());
        tempcanvas = GameObject.Find("Canvas").transform.GetChild(3).GetComponent<Transform>();
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 로드 됌");
        shipDesign = GetComponent<ShipDesign>();
        GetForManagerShipData();
        DropdownDataInit();
        LoadShopData();
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
        itemBuyCheck = new bool[shopListCount];
        currentsShopShipDatas.Clear();
        sellItemList.Clear();
        Text shipPartName;
        int count = 0;
        foreach ( var item in itemvalue)
        {
            DefaultShipPart tempdata = item as DefaultShipPart;
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
            int itemItemRange = Random.Range(1, itemvalue.Count);
            var a = Instantiate(shopItemPrefab, tempcanvas);
            currentShopItemList.Add(a);
            a.name = "ShipItemList" + itemvalue[i];
            a.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => SelectShopItem(itemItemRange));
            shipPartName = a.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>();

            if (itemvalue[itemItemRange] == null)
            {
                shipPartName.text = " ";
            }
            else
            {
                shipPartName.text = tempitemname[itemItemRange];
                Debug.Log($"ShipBody의 부품 이름은 {tempitemname[itemItemRange]}");
            }
            a.transform.Translate(i * 180, -20, 0);
        }

        Debug.Log($"--------------{currentsShopShipDatas.Count}");
        Debug.Log($"--------------{currentsShopShipDatas[0].name}");
    }

    public void SelectShopItem(int value)
    {
        string type = sellItemList[value].GetType().FullName;
        switch(type)
        {
            case "ShipHull":

                ShipHull shipHull = currentsShopShipDatas[value] as ShipHull;

                Debug.Log($"{shipHull.hullName}");
                tempSelectShopItem = shipHull;
                break;

            case "ShipHead":

                ShipHead shipHead = currentsShopShipDatas[value] as ShipHead;

                Debug.Log($"{shipHead.defaultShipPartName}");
                tempSelectShopItem = shipHead;
                break;

            case "ShipBody":

                ShipBody shipBody = currentsShopShipDatas[value] as ShipBody;

                Debug.Log($"{shipBody.defaultShipPartName}");
                tempSelectShopItem = shipBody;
                break;

            case "ShipTail":

                ShipTail shipTail = currentsShopShipDatas[value] as ShipTail;

                Debug.Log($"{shipTail.defaultShipPartName}");
                tempSelectShopItem = shipTail;
                break;

            case "Weapon":

                Weapon weapon = currentsShopShipDatas[value] as Weapon;

                Debug.Log($"{weapon.defaultShipPartName}");
                tempSelectShopItem = weapon;
                break;

            case "UtilityData":

                UtilityData utilityData = currentsShopShipDatas[value] as UtilityData;

                Debug.Log($"{utilityData.defaultShipPartName}");
                tempSelectShopItem = utilityData;
                break;

            case "ShipReactor":

                ShipReactor shipReactor = currentsShopShipDatas[value] as ShipReactor;

                Debug.Log($"{shipReactor.defaultShipPartName}");
                tempSelectShopItem = shipReactor;
                break;

            case "ShipThruster":

                ShipThruster shipThruster = currentsShopShipDatas[value] as ShipThruster;

                Debug.Log($"{shipThruster.defaultShipPartName}");
                tempSelectShopItem = shipThruster;
                break;
        }
    }

    public void AddTempShipHull()
    {
        currentHullName.text = shipDesign.currentship.shipHull.hullName.ToString();
        currentHullHp.text = "체   력 : " + shipDesign.currentship.shipHull.hulltHp.ToString();
    }

    void CreatePartSlot()
    {

    }



    private void OnDisable()
    {
        tempSelectShopItem = null;
    }

}   