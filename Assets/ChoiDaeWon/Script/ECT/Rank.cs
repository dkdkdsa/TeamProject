using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{

    [SerializeField] private Image rankImage;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI goldText;


    private float lastPlayerHP;


    public void SetRank()
    {

        rankImage.gameObject.SetActive(true);
        GameManager.instance.SetPlayerMoveAble(false);
        GameManager.instance.SetPlayerGunAble(false);

        lastPlayerHP = GameManager.instance.PlayerHP;

        if (lastPlayerHP >= 90)
        {

            rankText.text = "Rank : S";
            goldText.text = "50";
            GameManager.instance.Money += 50;

        }
        else if (lastPlayerHP >= 75)
        {

            rankText.text = "Rank : A";
            goldText.text = "40";
            GameManager.instance.Money += 40;

        }
        else if (lastPlayerHP >= 50)
        {

            rankText.text = "Rank : B";
            goldText.text = "30";
            GameManager.instance.Money += 30;

        }
        else if (lastPlayerHP >= 15)
        {

            rankText.text = "Rank : C";
            goldText.text = "20";
            GameManager.instance.Money += 20;

        }
        else if (lastPlayerHP >= 10)
        {

            rankText.text = "Rank : D";
            goldText.text = "10";
            GameManager.instance.Money += 10;

        }
        else
        {

            rankText.text = "Rank : F";
            goldText.text = "0";

        }

    }

}
