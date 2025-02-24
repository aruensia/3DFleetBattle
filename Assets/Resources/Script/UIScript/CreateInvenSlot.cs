using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateInvenSlot : MonoBehaviour
{
    Dictionary<string, List<ScriptableObject>> shipDataDic = new Dictionary<string, List<ScriptableObject>>();
    List<int> slotPartList = new List<int>();

    PlayerInfo playerInfo;
    ItemPopup invenSlot;
    int inventoryCount;
    public GameObject partSlot;
    public GameObject itemSlot;
    public Transform userInven;

    private void OnEnable()
    {
        GetForManagerShipData();
        //CreatePartSlot();
        //CreateItemSlot();
    }


    private void Start()
    {
        playerInfo = GameObject.Find("DataManager").GetComponent<PlayerInfo>();
        invenSlot = GameObject.Find("CurrentItemPopup").GetComponent<ItemPopup>();
        //GetForManagerShipData();
        CreatePartSlot();
        CreateItemSlot();
    }

    public void GetForManagerShipData()
    {
        shipDataDic = DataManager.Instance.getNewDataList.AllShipDataDic;
        //메인 데이터에서 불러온 게임 데이터를 판매할 목록에 넣어놓음.
    }

    void CreateItemSlot()
    {
        inventoryCount = DataManager.Instance.playerInfo.inventoryCount;

        if (playerInfo.tempInventorylist.Count == 0)
        {
            for (int i = 0; i < inventoryCount; i++)
            {
                var inventory = Instantiate(itemSlot, userInven.transform.GetChild(1));
                inventory.name = "inventory" + i;
                playerInfo.tempInventorylist.Add(inventory);
            }
        }
        else
        {
            for (int i = 0; i < inventoryCount; i++)
            {
                var inventory = Instantiate(itemSlot, userInven.transform.GetChild(1));
                inventory.name = "inventory" + i;
                playerInfo.tempInventorylist[i] = inventory;
            }
        }
    }

    void CreatePartSlot() //인벤토리에서 아이템 탭을 만드는 함수.
    {
        List<string> slots = new List<string>();

        foreach (var inventory in shipDataDic)
        {
            slots.Add(inventory.Key);
        }

        for (int i = 0; i < shipDataDic.Count; i++)
        {
            var temppartslot = Instantiate(partSlot, userInven.transform.GetChild(0));
            temppartslot.name = "PartSlot" + i;

            temppartslot.GetComponent<Button>().onClick.AddListener(() => invenSlot.SetItemChange(temppartslot)); //각 탭을 누를 경우 해당 정보를 출력하는 함수.

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
}
