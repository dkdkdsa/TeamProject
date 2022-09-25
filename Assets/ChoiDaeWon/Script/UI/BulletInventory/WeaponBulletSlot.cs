using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponBulletSlot : MonoBehaviour, IDropHandler
{

    private Image slotImage;
    private DragSlot dragSlot;

    public BulletDataSO bullet;

    private void Awake()
    {
        
        dragSlot = FindObjectOfType<DragSlot>();
        slotImage = GetComponentsInChildren<Image>()[1];
        
    }

    public void Set()
    {

        bullet = dragSlot.Bullet;
        slotImage.sprite = dragSlot.Bullet.bulletSprite;

    }

    public void Set(BulletDataSO bullet)
    {

        this.bullet = bullet;
        slotImage.sprite = bullet.bulletSprite;

    }

    public void OnDrop(PointerEventData eventData)
    {

        Set();
        dragSlot.transform.localPosition = Vector3.zero;
        
    }

}
