using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    //상점은 유저 전투 등급에 따라 아이쇼핑할 수 있는 상품 개수가 증가한다.
    //한 번의 전투가 끝날 때마다 아이템의 목록을 새로고침한다. 유저가 특정 상품을 구매할 경우, 솔드아웃이 되어, 더이상 목록에 상품이 생성되지 않는다.

    Dictionary<string, List<ScriptableObject>> sellListShipData = new Dictionary<string, List<ScriptableObject>>();

    List<ScriptableObject> tempshopItemList = new List<ScriptableObject>(); // 상점에서 파는 아이템 목록
    List<List<ScriptableObject>> totalshopItemList = new List<List<ScriptableObject>>(); // sellListShipData에서 받은 딕셔너리를 상점에서 사용하기 위해 저장한 리스트.
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>(); //드롭다운 목록에 사용하는 키를 저장할 리스트
    List<List<ScriptableObject>> tempTotalShopItem;

    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Button TempSellectShipPartMenuButton;


    public Text shipPartName;
    public GameObject shopItemPrefab;
    Transform tempcanvas;
    RectTransform pos;

    bool isScenesOn = true;
    bool[] itemBuyCheck;

    [SerializeField] int shopListCount;


    private void Start()
    {
        tempcanvas = GameObject.Find("Canvas").transform.GetChild(3).GetComponent<Transform>();
        TempSellectShipPartMenuButton.onClick.AddListener(() => DropdownDataInit());
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
        //SceneManager.sceneLoaded += LoadShopData;
    }

    public void OnDropdownEvent(int index) //유저가 선택한 드랍목록의 int값을 인자로 넘김
    {
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
            tempshopItemList = new List<ScriptableObject>();
        }
        tempTotalShopItem = totalshopItemList;
    }


    void ShowShopItem(List<ScriptableObject> itemvalue)
    {
        //부품 목록을 누를 경우, 랜덤값을 통해 

        int itemGradeRange = Random.Range(1, (int)Grade.end);
        int itemItemRange = Random.Range(1, itemvalue.Count);
        List<ScriptableObject> sellItemList = new List<ScriptableObject>();
        string[] tempitemname = new string[itemvalue.Count];
        itemBuyCheck = new bool[shopListCount];

        sellItemList.Clear();
        Text shipPartName;
        int count = 0;
        foreach ( var item in itemvalue)
        {
            string typename = item.GetType().FullName;
            
            if (typename == "ShipBody")
            {
                ShipBody tempitem = item as ShipBody;
                sellItemList.Add(tempitem);
                if(tempitem.defaultShipPartName == null)
                {
                    Debug.Log("tempitem.defaultShipPartName의 값이 비어있음");
                }
                else
                {
                    Debug.Log($"tempitemname의 카운트는 : {count}, 이름은 : {tempitem.defaultShipPartName}");
                    tempitemname[count] = tempitem.defaultShipPartName;
                    count++;
                }
            }
        }

        for (int i = 0; i < itemvalue.Count; i++)
        {
            var a = Instantiate(shopItemPrefab, tempcanvas);

            if(itemvalue[i] == null)
            {
                Debug.Log($"{itemvalue}에 i가 없어요");
            }
            else
            {
                shipPartName = a.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>();
                shipPartName.text = tempitemname[i];
                Debug.Log($"ShipBody의 부품 이름은 {tempitemname[i]}");
            }
            a.transform.Translate(i * 180, -20, 0);
        }
    }

    private void OnDestroy()
    {
        //SceneManager.sceneLoaded -= LoadShopData;
    }

}   