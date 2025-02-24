using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CallItemNum : MonoBehaviour, IPointerClickHandler
{
    ShipDesign shipDesign;
    string currentSelectItemName;
    int tempnum;
    public GameObject cubePrefab;
    DesignItemPop designItemPop;
    
    void Start()
    {
        shipDesign = GameObject.Find("DesignManager").GetComponent<ShipDesign>();
        designItemPop = GameObject.Find("DesignManager").GetComponent<DesignItemPop>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (shipDesign.isWeaponSetting == true)
        {
            Debug.Log(" isWeaponSetting true가 되었음");

        }
        else
        {
            currentSelectItemName = eventData.pointerCurrentRaycast.gameObject.transform.parent.name;
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.transform.parent.name);
            if (currentSelectItemName == null)
            {
                Debug.Log("비어있어요!!");
            }
            string number = Regex.Replace(currentSelectItemName, @"\D", "");
            tempnum = int.Parse(number);
            Debug.Log(DataManager.Instance.playerInfo.currentSelectDataValue);
            designItemPop.SetBuyPopup(tempnum, DataManager.Instance.playerInfo.currentSelectDataValue);
        }
    }


}
