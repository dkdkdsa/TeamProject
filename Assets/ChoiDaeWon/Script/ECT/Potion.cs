using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class Potion : MonoBehaviour
{

    private int portionCount_Lv1;
    private int portionCount_Lv2;
    private int portionCount_Lv3;

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



    }

}
