using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using TMPro;

public class Potion : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI L1Text;
    [SerializeField] private TextMeshProUGUI L2Text;
    [SerializeField] private TextMeshProUGUI L3Text;

    public int portionCount_Lv1 { get; set; }
    public int portionCount_Lv2 { get; set; }
    public int portionCount_Lv3 { get; set; }

    private void Update()
    {
        
        L1Text.text = portionCount_Lv1.ToString();
        L2Text.text = portionCount_Lv2.ToString();
        L3Text.text = portionCount_Lv3.ToString();

    }

    public void BuyPotion(PotionType type)
    {

        if(type == PotionType.Lv1)
        {

            portionCount_Lv1++;

        }
        else if(type == PotionType.Lv2)
        {

            portionCount_Lv2++;

        }
        else if(type == PotionType.Lv3)
        {

            portionCount_Lv3++;

        }

    }

    public void PotionUse(PotionType type)
    {

        if (type == PotionType.Lv1 && portionCount_Lv1 > 0)
        {

            portionCount_Lv1--;
            GameManager.instance.PlayerHP += 25;

        }
        else if (type == PotionType.Lv2 && portionCount_Lv2 > 0)
        {

            portionCount_Lv2--;
            GameManager.instance.PlayerHP += 50;

        }
        else if (type == PotionType.Lv3 && portionCount_Lv3 > 0 )
        {

            portionCount_Lv3--;
            GameManager.instance.PlayerHP += 75;

        }

    }

}
