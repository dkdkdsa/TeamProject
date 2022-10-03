using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

[System.Serializable]
public class Items
{

    public ItemType itemType;
    public BulletDataSO bulletDataSO;
    public string itemName;
    public int itemPrice;
    public int[] upgradeExtraPrice;

}

public class ShopCore : MonoBehaviour
{
    
    [SerializeField] private List<Items> items = new List<Items>();    

    private int FindItem(string itemName)
    {

        int n = 0;

        for(int i = 0; i < items.Count; i++)
        {

            if(items[i].itemName == itemName)
            {

                n = i;
                break;

            }

        }

        return n;

    }

    public void SetShopSlot(out Sprite sprite, out string itemName)
    {

        int r = Random.Range(0, items.Count);

        sprite = items[r].bulletDataSO.bulletSprite;
        itemName = items[r].itemName;

    }

    public void BuyBullet(string itemName)
    {

        if (Upgrader.instance.ChackMaxUpgrade(items[FindItem(itemName)].bulletDataSO.bulletType) == false)
        {

            bool value = GameManager.instance.Money >= items[FindItem(itemName)].itemPrice + items[FindItem(itemName)].upgradeExtraPrice[Upgrader.instance.FindUpGradeCount(items[FindItem(itemName)].bulletDataSO.bulletType)];

            if (value)
            {

                GameManager.instance.Money -= items[FindItem(itemName)].itemPrice + items[FindItem(itemName)].upgradeExtraPrice[Upgrader.instance.FindUpGradeCount(items[FindItem(itemName)].bulletDataSO.bulletType)];
                Upgrader.instance.UpGrade(items[FindItem(itemName)].bulletDataSO.bulletType);

            }

        }
        else
        {

            //나중에 추가

        }


    }


}
