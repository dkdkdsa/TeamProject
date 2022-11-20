using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Image image;

    private ShopCore s_Core;

    public string itemName;

    private void Awake()
    {

        s_Core = FindObjectOfType<ShopCore>();

    }

    private void Update()
    {

        if (itemName == "") return;
        
        if(s_Core.FindItems(itemName).itemType == EnumTypes.ItemType.Bullet)
        {

            priceText.text = (s_Core.FindItems(itemName).itemPrice + s_Core.items[s_Core.FindItem(itemName)].upgradeExtraPrice[Upgrader.instance.FindUpGradeCount(s_Core.FindItems(itemName).bulletDataSO.bulletType)]).ToString();
            image.sprite = s_Core.FindItems(itemName).itemSprite[Upgrader.instance.FindUpGradeCount(s_Core.FindItems(itemName).bulletDataSO.bulletType)];

        }
        else
        {

            priceText.text = s_Core.FindItems(itemName).itemPrice.ToString();

        }



    }

    public void OnPointerDown(PointerEventData eventData)
    {

        ShopCore core = FindObjectOfType<ShopCore>();

        core.Buy(itemName);

    }
}
