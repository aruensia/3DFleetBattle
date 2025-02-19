using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInvenSlot : MonoBehaviour
{
    int inventoryCount;
    public GameObject itemSlot;
    public Transform userInven;
    public List<GameObject> tempInventorylist = new List<GameObject>();


    void CreateItemSlot()
    {
        inventoryCount = DataManager.Instance.playerInfo.inventoryCount;

        for (int i = 0; i < inventoryCount; i++)
        {
            var inventory = Instantiate(itemSlot, userInven.transform.GetChild(1));
            tempInventorylist.Add(inventory);
        }
    }
}
