using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CallItemNum : MonoBehaviour, IPointerClickHandler
{
    string currentSelectItemName;
    int tempnum;
    public GameObject cubePrefab;
    DesignItemPop designItemPop;
    
    void Start()
    {
        designItemPop = GameObject.Find("DesignManager").GetComponent<DesignItemPop>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentSelectItemName = eventData.pointerCurrentRaycast.gameObject.transform.parent.name;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.transform.parent.name);
        if ( currentSelectItemName == null)
        {
            Debug.Log("비어있어요!!");
        }
        string number = Regex.Replace(currentSelectItemName, @"\D", "");
        tempnum = int.Parse(number);
        Debug.Log(DataManager.Instance.playerInfo.currentSelectDataValue);
        designItemPop.SetBuyPopup(tempnum, DataManager.Instance.playerInfo.currentSelectDataValue);
    }


}
