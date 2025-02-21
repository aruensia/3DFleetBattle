using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CallItemNum : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    string currentSelectItemName;
    int tempnum;
    private Transform originalParent;
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentSelectItemName = eventData.pointerCurrentRaycast.gameObject.transform.parent.name;
        string number = Regex.Replace(currentSelectItemName, @"\D", "");
        tempnum = int.Parse(number);
        Transform temp = Instantiate(transform.parent, transform);
        originalParent = temp;
        transform.SetParent(originalParent.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if ( transform.parent == originalParent )
        {
            transform.SetParent(originalParent);
        }
    }
}
