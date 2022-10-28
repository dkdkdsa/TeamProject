using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEvents : MonoBehaviour
{

    [SerializeField] private Image fadeImage;

    public void Fade()
    {

        Sequence sequence = DOTween.Sequence();
        sequence
        .OnStart(() =>
        {

            GameManager.instance.SetPlayerGunAble(false);
            GameManager.instance.SetPlayerMoveAble(false);

        })
        .Append(fadeImage.DOFade(1, 0.3f))
        .AppendInterval(0.3f)
        .Append(fadeImage.DOFade(0, 0.3f))
        .OnComplete(() =>
        {

            GameManager.instance.SetPlayerGunAble(true);
            GameManager.instance.SetPlayerMoveAble(true);

        });
        

    }

}
