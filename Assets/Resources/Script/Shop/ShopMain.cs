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

    List<ScriptableObject> shopShipHullDataList = new List<ScriptableObject>();
    List<ScriptableObject> shopShipHeadDataList = new List<ScriptableObject>();
    List<ScriptableObject> shopShipBodyDataList = new List<ScriptableObject>();
    List<ScriptableObject> shopShipTailDataList = new List<ScriptableObject>();
    List<ScriptableObject> shopWeaponDataList = new List<ScriptableObject>();
    List<ScriptableObject> shopUtilityDataList = new List<ScriptableObject>();

    [SerializeField] TMP_Dropdown dropdown;
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>();
    [SerializeField] Button TempSellectShipPartMenuButton;

    ScriptableObject tempDataObject;

    bool isScenesOn = false;

    int tempListInt;

    private void Start()
    {
        TempSellectShipPartMenuButton.onClick.AddListener(() => DropdownDataInit());
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
    }

    public void OnDropdownEvent(int index)
    {
        tempListInt = index;
        ShowShopItem(index);
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

    void DropdownDataInit()
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
        shopShipHullDataList = sellListShipData["ShipHullData"];
        shopShipHeadDataList = sellListShipData["ShipHeadData"];
        shopShipBodyDataList = sellListShipData["ShipBodyData"];
        shopShipTailDataList = sellListShipData["ShipTailData"];
        shopWeaponDataList = sellListShipData["WeaponData"];
        shopUtilityDataList = sellListShipData["UtilityData"];

        //for (int i = 0; i < optionsList.Count; i++)
        //{
        //    for (int j = 0; j < sellListShipData[optionsList[i].text].Count; j++)
        //    {
        //        shopItemList.Add(sellListShipData[optionsList[i].text]);
        //    }
        //}
    }


    void ShowShopItem(int itemindex)
    {
        //부품 목록을 누를 경우, 랜덤값을 통해 

        int itemGradeRange = Random.Range(1, (int)Grade.end);
        int itemItemRange = Random.Range(1, 101);

        switch (tempListInt)
        {
            case 0:
                if (itemItemRange < 85)
                {

                }
                else if(itemItemRange < 95)
                {

                }
                else if(itemItemRange < 99)
                {

                }


                Debug.Log($"shopShipHullDataList는 {shopShipHullDataList.Count}의 개수를 가지고 있으며 시작 값은 {shopShipHullDataList[0].name} 입니다.");
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;


            case 1:
                Debug.Log($"shopShipHullDataList는 {shopShipHeadDataList.Count}의 개수를 가지고 있으며 시작 값은 {shopShipHeadDataList[0].name} 입니다.");
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;


            case 2:
                Debug.Log($"shopShipHullDataList는 {shopShipBodyDataList.Count}의 개수를 가지고 있으며 시작 값은 {shopShipBodyDataList[0].name} 입니다.");
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;


            case 3:
                Debug.Log($"shopShipHullDataList는 {shopShipTailDataList.Count}의 개수를 가지고 있으며 시작 값은 {shopShipTailDataList[0].name} 입니다.");
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;

            case 4:
                Debug.Log($"shopShipHullDataList는 {shopWeaponDataList.Count}의 개수를 가지고 있으며 시작 값은 {shopWeaponDataList[0].name} 입니다.");
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;

            case 5:
                Debug.Log($"shopShipHullDataList는 {shopUtilityDataList.Count}의 개수를 가지고 있으며 시작 값은 {shopUtilityDataList[0].name} 입니다.");
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;

        }
    }



}
