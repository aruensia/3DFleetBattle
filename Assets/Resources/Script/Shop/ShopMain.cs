using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    //상점은 유저 전투 등급에 따라 아이쇼핑할 수 있는 상품 개수가 증가한다.
    //한 번의 전투가 끝날 때마다 아이템의 목록을 새로고침한다. 유저가 특정 상품을 구매할 경우, 솔드아웃이 되어, 더이상 목록에 상품이 생성되지 않는다.

    Dictionary<string, List<ScriptableObject>> sellListShipData = new Dictionary<string, List<ScriptableObject>>();

    [SerializeField] TMP_Dropdown dropdown;
    List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>();
    [SerializeField] Button TempSellectShipPartMenuButton;

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
        Debug.Log(tempListInt);
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

    void ShowShopItem(int itemindex)
    {
        int itemGradeRange = Random.Range(1, (int)Grade.end);
        int itemItemRange = Random.Range(1, 101);

        List<int> items = new List<int> { 0, 1, 2, 3, 4, 5 };

        



        switch (tempListInt)
        {
            case 0:
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;


            case 1:
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;


            case 2:
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;


            case 3:
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;

            case 4:
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;

            case 5:
                Debug.Log($"아이템 등급은 {itemGradeRange}, 아이템 범위는 {itemItemRange}입니다.");
                break;

        }
    }



}
