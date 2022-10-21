using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerDownHandler
{

    public string itemName;

    public void OnPointerDown(PointerEventData eventData)
    {

        ShopCore core = FindObjectOfType<ShopCore>();

        core.BuyBullet(itemName);

    }
}
