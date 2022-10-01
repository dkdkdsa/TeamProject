using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {

        if(eventData.button == PointerEventData.InputButton.Left)
        {

            Debug.Log(1);

        }

    }
}
