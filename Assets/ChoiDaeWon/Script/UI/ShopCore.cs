using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using TMPro;
using DG.Tweening;

[System.Serializable]
public class Items
{

    public ItemType itemType;
    public PotionType potionType;
    public BulletDataSO bulletDataSO;
    public Sprite[] itemSprite;
    public string itemName;
    public string[] showTexts;
    public int itemPrice;
    public int[] upgradeExtraPrice;

}

public class ShopCore : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI showText;

    public List<Items> items = new List<Items>();    

    public int FindItem(string itemName)
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

    public Items FindItems(string itemName)
    {

        Items n = null;

        for (int i = 0; i < items.Count; i++)
        {

            if (items[i].itemName == itemName)
            {

                n = items[i];
                break;

            }

        }

        return n;


    }

    public void Buy(string itemName)
    {

        if (items[FindItem(itemName)].itemType == ItemType.Bullet)
        {

            BuyBullet(itemName);

        }
        else
        {

            BuyPotion(itemName);

        }

    }

    public void BuyPotion(string itemName)
    {

        if (items[FindItem(itemName)].itemPrice <= GameManager.instance.Money)
        {

            GameManager.instance.Money -= items[FindItem(itemName)].itemPrice;
            Potion potion = FindObjectOfType<Potion>();
            if (items[FindItem(itemName)].potionType == PotionType.Lv1) potion.portionCount_Lv1++;
            else if (items[FindItem(itemName)].potionType == PotionType.Lv2) potion.portionCount_Lv2++;
            else if(items[FindItem(itemName)].potionType == PotionType.Lv3) potion.portionCount_Lv3++;

        }

    }

    public void SetShopSlot(out Sprite sprite, out string itemName)
    {

        int r = Random.Range(0, items.Count);

        itemName = items[r].itemName;
        sprite = items[r].itemSprite[Upgrader.instance.FindUpGradeCount(items[r].bulletDataSO.bulletType)];

    }
    
    public void BuyBullet(string itemName)
    {

        if (Upgrader.instance.ChackMaxUpgrade(items[FindItem(itemName)].bulletDataSO.bulletType) == false)
        {

            bool value = GameManager.instance.Money >= (items[FindItem(itemName)].itemPrice + items[FindItem(itemName)].upgradeExtraPrice[Upgrader.instance.FindUpGradeCount(items[FindItem(itemName)].bulletDataSO.bulletType)]);

            if (value)
            {

                GameManager.instance.Money -= (items[FindItem(itemName)].itemPrice + items[FindItem(itemName)].upgradeExtraPrice[Upgrader.instance.FindUpGradeCount(items[FindItem(itemName)].bulletDataSO.bulletType)]);
                Upgrader.instance.UpGrade(items[FindItem(itemName)].bulletDataSO.bulletType);
                showText.DOKill();
                showText.text = items[FindItem(itemName)].showTexts[Upgrader.instance.FindUpGradeCount(FindItems(itemName).bulletDataSO.bulletType)];
                showText.color = new Color(0, 0, 0, 1);
                showText.DOFade(0, 0.7f);


            }
            else
            {

                showText.DOKill();
                showText.text = "돈이 부족합니다";
                showText.color = new Color(0, 0, 0, 1);
                showText.DOFade(0, 0.7f);

            }

        }
        else
        {

            Debug.Log("이미 전부 강화된 상품입니다.");
            showText.DOKill();
            showText.text = "이미 전부 강화된 상품입니다.";
            showText.color = new Color(0, 0, 0, 1);
            showText.DOFade(0, 0.7f);
        }


    }


}
