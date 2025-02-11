using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    //상점은 유저 전투 등급에 따라 아이쇼핑할 수 있는 상품 개수가 증가한다.
    //한 번의 전투가 끝날 때마다 아이템의 목록을 새로고침한다. 유저가 특정 상품을 구매할 경우, 솔드아웃이 되어, 더이상 목록에 상품이 생성되지 않는다.

    Dictionary<string, List<ScriptableObject>> sellListShipData = new Dictionary<string, List<ScriptableObject>>();

    //List<ScriptableObject> shopShipHullDataList = new List<ScriptableObject>();
    //List<ScriptableObject> shopShipHeadDataList = new List<ScriptableObject>();
    //List<ScriptableObject> shopShipBodyDataList = new List<ScriptableObject>();
    //List<ScriptableObject> shopShipTailDataList = new List<ScriptableObject>();
    //List<ScriptableObject> shopWeaponDataList = new List<ScriptableObject>();
    //List<ScriptableObject> shopUtilityDataList = new List<ScriptableObject>();

    List<ScriptableObject> shopItemList = new List<ScriptableObject>();
    List<List<ScriptableObject>> totalshopItemList = new List<List<ScriptableObject>>();
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>();

    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Button TempSellectShipPartMenuButton;

    ScriptableObject tempDataObject;

    bool isScenesOn = false;
    List<List<ScriptableObject>> tempTotalShopItem;

    private void Start()
    {
        TempSellectShipPartMenuButton.onClick.AddListener(() => DropdownDataInit());
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
        //SceneManager.sceneLoaded += LoadShopData;
    }

    public void OnDropdownEvent(int index)
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
            for (int j = 0; j < sellListShipData[optionsList[i].text].Count; j++)
            {
                shopItemList.Add(sellListShipData[optionsList[i].text][j]);
            }
            totalshopItemList.Add(shopItemList);
            shopItemList = new List<ScriptableObject>();
        }

        foreach (var item in totalshopItemList)
        {
            for( int i = 0; i < item.Count; i ++)
            {
                Debug.Log(item[i].name);
            }
        }

        tempTotalShopItem = totalshopItemList;
    }


    void ShowShopItem(List<ScriptableObject> itemvalue)
    {
        //부품 목록을 누를 경우, 랜덤값을 통해 

        int itemGradeRange = Random.Range(1, (int)Grade.end);
        int itemItemRange = Random.Range(1, 101);

        Debug.Log(itemvalue[0].name);

 
        
    }

    private void OnDestroy()
    {
        //SceneManager.sceneLoaded -= LoadShopData;
    }

}