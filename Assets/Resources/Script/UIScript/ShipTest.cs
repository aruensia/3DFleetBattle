using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipTest : MonoBehaviour
{
    public Image itemImage;
    bool isOn = false;


    private void Update()
    {
        if (isOn == true)
        {
            itemImage.rectTransform.position = Input.mousePosition;
        }
    }

    public void GetItemImage()
    {
        isOn = true;
        transform.GetChild(0).gameObject.SetActive(true);

    }
}
