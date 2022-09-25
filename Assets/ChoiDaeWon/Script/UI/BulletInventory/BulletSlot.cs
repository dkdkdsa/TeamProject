using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BulletSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private GameObject weaponSlotParent;
    [SerializeField] private BulletDataSO bullet;
    [SerializeField] private Image itemImage;

    private DragSlot dragSlot;
    
    private void Awake()
    {

        //юс╫ц
        Set(bullet);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        dragSlot.Set(bullet);
        dragSlot.ItemImage.color = new Color(255, 255, 255, 1);

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        dragSlot.transform.position = eventData.position;

    }

    public void Set(BulletDataSO bullet)
    {

        itemImage = GetComponentsInChildren<Image>()[1];
        dragSlot = FindObjectOfType<DragSlot>();
        this.bullet = bullet;
        itemImage.sprite = bullet.bulletSprite;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        dragSlot.transform.localPosition = Vector3.zero;
        dragSlot.ItemImage.color = new Color(0, 0, 0, 0);

    }
}
