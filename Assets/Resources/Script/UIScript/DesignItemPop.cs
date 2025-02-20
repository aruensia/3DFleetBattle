using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesignItemPop : MonoBehaviour, IPointerClickHandler
{
    public List<Text> itemDefalutData = new List<Text>();
    public List<Text> head = new List<Text>();
    public List<Text> body = new List<Text>();
    public List<Text> tail = new List<Text>();
    public List<Text> hull = new List<Text>();
    public List<Text> weapon = new List<Text>();
    public List<Text> shild = new List<Text>();
    public List<Text> defence = new List<Text>();
    public List<Text> thruster = new List<Text>();
    public List<Text> reactor = new List<Text>();
    List<ScriptableObject> currentSelectItemPart = new List<ScriptableObject>();

    public GameObject itemButton;

    string currentSelectItemName;
    int tempnum;

    private void OnEnable()
    {
        //itemButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => SetItemPopup(DataManager.Instance.playerInfo.currentSelectDataValue));
    }

    void Start()
    {
        itemButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => SetItemPopup(DataManager.Instance.playerInfo.currentSelectDataValue));
    }
    

    void GetText()
    {
        itemDefalutData[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>();
        itemDefalutData[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>();
        itemDefalutData[2] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Text>();
        hull[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>();
        weapon[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>();
        weapon[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(11).GetComponent<Text>();
        weapon[2] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(12).GetComponent<Text>();
        shild[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>();
        shild[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(13).GetComponent<Text>();
        defence[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>();
        defence[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(13).GetComponent<Text>();
        thruster[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(9).GetComponent<Text>();
        thruster[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(13).GetComponent<Text>();
        reactor[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(10).GetComponent<Text>();
        head[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(14).GetComponent<Text>();
        head[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(15).GetComponent<Text>();
        body[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(14).GetComponent<Text>();
        body[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(15).GetComponent<Text>();
        tail[0] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(14).GetComponent<Text>();
        tail[1] = GameObject.Find("CurrentItemPopup").transform.GetChild(0).GetChild(0).GetChild(15).GetComponent<Text>();

    }

    void FalseText()
    {
        itemDefalutData[0].gameObject.SetActive(false);
        itemDefalutData[1].gameObject.SetActive(false);
        itemDefalutData[2].gameObject.SetActive(false);
        hull[0].gameObject.SetActive(false);
        weapon[0].gameObject.SetActive(false);
        weapon[1].gameObject.SetActive(false);
        weapon[2].gameObject.SetActive(false);
        shild[0].gameObject.SetActive(false);
        shild[1].gameObject.SetActive(false);
        defence[0].gameObject.SetActive(false);
        defence[1].gameObject.SetActive(false);
        thruster[0].gameObject.SetActive(false);
        thruster[1].gameObject.SetActive(false);
        reactor[0].gameObject.SetActive(false);
        head[0].gameObject.SetActive(false);
        head[1].gameObject.SetActive(false);
        body[0].gameObject.SetActive(false);
        body[1].gameObject.SetActive(false);
        tail[0].gameObject.SetActive(false);
        tail[1].gameObject.SetActive(false);
    }

    //void SetBuyPopup(int value, GameObject item)
    //{
    //    FalseText();
    //
    //    itemDefalutData[0].gameObject.SetActive(true);
    //    itemDefalutData[1].gameObject.SetActive(true);
    //    itemDefalutData[2].gameObject.SetActive(true);
    //    currentSelectItem = currentsShopShipDatas[value];
    //
    //    string type = currentSelectItem.GetType().FullName;
    //
    //    switch (type)
    //    {
    //        case "ShipHull":
    //            ShipHull tempHull = (ShipHull)currentSelectItem;
    //            hull[0].gameObject.SetActive(true);
    //            itemDefalutData[0].text = "이     름 : " + tempHull.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempHull.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempHull.DefaultShipPartGrade.ToString();
    //            hull[0].text = "체     력 : " + tempHull.hulltHp.ToString();
    //            break;
    //
    //        case "ShipHead":
    //            head[0].gameObject.SetActive(true);
    //            head[1].gameObject.SetActive(true);
    //            ShipHead tempHead = (ShipHead)currentSelectItem;
    //            itemDefalutData[0].text = "이     름 : " + tempHead.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempHead.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempHead.DefaultShipPartGrade.ToString();
    //            head[0].text = "사용 무기 개수 : " + tempHead.weapons.Count;
    //            head[1].text = "사용 무기 개수 : " + tempHead.utility.Count;
    //
    //            break;
    //
    //        case "ShipBody":
    //            body[0].gameObject.SetActive(true);
    //            body[1].gameObject.SetActive(true);
    //            ShipBody tempBody = (ShipBody)currentSelectItem;
    //            itemDefalutData[0].text = "이     름 : " + tempBody.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempBody.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempBody.DefaultShipPartGrade.ToString();
    //            body[0].text = "사용 무기 개수 : " + tempBody.weapons.Count;
    //            body[1].text = "사용 무기 개수 : " + tempBody.utility.Count;
    //            break;
    //
    //
    //        case "ShipTail":
    //            tail[0].gameObject.SetActive(true);
    //            tail[1].gameObject.SetActive(true);
    //            ShipTail tempTail = (ShipTail)currentSelectItem;
    //            itemDefalutData[0].text = "이     름 : " + tempTail.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempTail.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempTail.DefaultShipPartGrade.ToString();
    //            tail[0].text = "사용 무기 개수 : " + tempTail.weapons.Count;
    //            tail[1].text = "사용 무기 개수 : " + tempTail.utility.Count;
    //            break;
    //
    //
    //        case "Weapon":
    //            Weapon tempWeapon = (Weapon)currentSelectItem;
    //            weapon[0].gameObject.SetActive(true);
    //            weapon[1].gameObject.SetActive(true);
    //            weapon[2].gameObject.SetActive(true);
    //            weapon[3].gameObject.SetActive(true);
    //
    //
    //            itemDefalutData[0].text = "이     름 : " + tempWeapon.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempWeapon.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempWeapon.DefaultShipPartGrade.ToString();
    //            weapon[0].text = "공 격 력 : " + tempWeapon.damage;
    //            weapon[1].text = "공격속도 : " + tempWeapon.attackRange;
    //            weapon[2].text = "공격거리 : " + tempWeapon.attackSpeed;
    //            weapon[3].text = "전력소모 : " + tempWeapon.usePower;
    //            break;
    //
    //        case "UtilityData":
    //            UtilityData tempUtility = (UtilityData)currentSelectItem;
    //            if (Utility.Shields == tempUtility.utility)
    //            {
    //                shild[0].gameObject.SetActive(true);
    //                shild[1].gameObject.SetActive(true);
    //
    //                itemDefalutData[0].text = "이     름 : " + tempUtility.defaultShipPartName;
    //                itemDefalutData[1].text = "함     급 : " + tempUtility.defaultShipPartClass.ToString();
    //                itemDefalutData[2].text = "등     급 : " + tempUtility.DefaultShipPartGrade.ToString();
    //                shild[0].text = "보 호 막 : " + tempUtility.shild;
    //                shild[1].text = "전력소모 : " + tempUtility.usePower;
    //            }
    //            else if (Utility.Armor == tempUtility.utility)
    //            {
    //                defence[0].gameObject.SetActive(true);
    //                defence[1].gameObject.SetActive(true);
    //
    //                itemDefalutData[0].text = "이     름 : " + tempUtility.defaultShipPartName;
    //                itemDefalutData[1].text = "함     급 : " + tempUtility.defaultShipPartClass.ToString();
    //                itemDefalutData[2].text = "등     급 : " + tempUtility.DefaultShipPartGrade.ToString();
    //                defence[0].text = "방어력 : " + tempUtility.defence;
    //                defence[1].text = "방어력 : " + tempUtility.usePower;
    //            }
    //            break;
    //
    //        case "ShipReactor":
    //            reactor[0].gameObject.SetActive(true);
    //
    //            ShipReactor tempReactor = (ShipReactor)currentSelectItem;
    //            itemDefalutData[0].text = "이     름 : " + tempReactor.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempReactor.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempReactor.DefaultShipPartGrade.ToString();
    //            reactor[0].text = "최대전력 : " + tempReactor.reactorPower;
    //            break;
    //
    //        case "ShipThruster":
    //            thruster[0].gameObject.SetActive(true);
    //            thruster[1].gameObject.SetActive(true);
    //
    //            ShipThruster tempThruster = (ShipThruster)currentSelectItem;
    //            itemDefalutData[0].text = "이     름 : " + tempThruster.defaultShipPartName;
    //            itemDefalutData[1].text = "함     급 : " + tempThruster.defaultShipPartClass.ToString();
    //            itemDefalutData[2].text = "등     급 : " + tempThruster.DefaultShipPartGrade.ToString();
    //            thruster[0].text = "이동속도 : " + tempThruster.thrusterSpeed;
    //            thruster[1].text = "최대전력 : " + tempThruster.usePower;
    //            break;
    //    }
    //
    //    activityUIControl[0].SetActive(true);
    //    activityUIControl[3].GetComponent<CanvasGroup>().interactable = false;
    //}

    public void SetItemPopup(string item) 
    {
        Debug.Log(item);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentSelectItemName = eventData.pointerCurrentRaycast.gameObject.transform.parent.name;
        string number = Regex.Replace(currentSelectItemName, @"\D", "");
        tempnum = int.Parse(number);
        Debug.Log(tempnum);
    }
}
