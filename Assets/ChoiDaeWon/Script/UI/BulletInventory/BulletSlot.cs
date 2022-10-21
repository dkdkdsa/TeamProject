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
    [SerializeField] private bool isBuying;

    private DragSlot dragSlot;

    [field:SerializeField] public bool isAble { get; set; }
    public BulletDataSO BulletData => bullet;

    private void Awake()
    {

        dragSlot = FindObjectOfType<DragSlot>();
        if (isBuying == false) return;
        //юс╫ц
        if(bullet != null) Set(bullet);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isBuying == false) return;
        dragSlot.Set(bullet);
        dragSlot.ItemImage.color = new Color(255, 255, 255, 1);

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isBuying == false) return;
        dragSlot.transform.position = eventData.position;

    }

    public void Set(BulletDataSO bullet)
    {

        itemImage = GetComponentsInChildren<Image>()[1];
        this.bullet = bullet;
        itemImage.sprite = bullet.bulletSprite;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isBuying == false) return;
        dragSlot.transform.localPosition = Vector3.zero;
        dragSlot.ItemImage.color = new Color(0, 0, 0, 0);

    }

    public void SetIsBuying(bool value)
    {

        Debug.Log(bullet);
        isBuying = value;
        Set(bullet);

    }

}
