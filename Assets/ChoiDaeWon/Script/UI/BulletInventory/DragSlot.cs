using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{

    private BulletDataSO bullet;
    private Image itemImage;

    public Image ItemImage { get { return itemImage; } set { itemImage = value; } }
    public BulletDataSO Bullet { get { return bullet; } }

    private void Awake()
    {
        
        itemImage = GetComponent<Image>();

    }

    public void Set(BulletDataSO bullet)
    {

        this.bullet = bullet;
        itemImage.sprite = bullet.bulletSprite;

    }


}
