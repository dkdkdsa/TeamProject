using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rank : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI goldText;

    private int clearCount = 0;
    private float lastPlayerHP;

    public void AddClearCount()
    {

        clearCount++;

    }

    public void SetRank()
    {

        if (clearCount == 4 && lastPlayerHP >= 90)
        {

            rankText.text = "S";
            goldText.text = "50";

        }
        else if (clearCount == 3 && lastPlayerHP >= 75)
        {

            rankText.text = "A";
            goldText.text = "40";

        }
        else if (clearCount == 2 && lastPlayerHP >= 50)
        {

            rankText.text = "B";
            goldText.text = "30";

        }
        else if (clearCount == 1 || lastPlayerHP >= 15)
        {

            rankText.text = "C";
            goldText.text = "20";

        }
        else if (clearCount > 0 || lastPlayerHP >= 10)
        {

            rankText.text = "D";
            goldText.text = "10";

        }
        else
        {

            rankText.text = "F";
            goldText.text = "0";

        }

    }

}
