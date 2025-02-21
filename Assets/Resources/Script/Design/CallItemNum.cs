using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class CallItemNum : MonoBehaviour, IPointerClickHandler
{
    string currentSelectItemName;
    int tempnum;
    DesignItemPop designItemPop;
    
    void Start()
    {
        designItemPop = GameObject.Find("DesignManager").GetComponent<DesignItemPop>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentSelectItemName = eventData.pointerCurrentRaycast.gameObject.transform.parent.name;
        string number = Regex.Replace(currentSelectItemName, @"\D", "");
        tempnum = int.Parse(number);
        designItemPop.SetBuyPopup(tempnum, DataManager.Instance.playerInfo.currentSelectDataValue);
        Debug.Log(tempnum);
        Debug.Log(DataManager.Instance.playerInfo.currentSelectDataValue);
    }
}
