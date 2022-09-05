using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBox : MonoBehaviour, IPointerDownHandler
{

    private Conversation conversation;

    public void Set(Conversation value)
    {

        conversation = value;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        conversation.Click();

    }

}
