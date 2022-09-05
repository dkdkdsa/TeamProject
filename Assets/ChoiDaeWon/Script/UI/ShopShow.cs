using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopShow : MonoBehaviour
{

    private void Awake()
    {

        Show();

    }

    public void Show()
    {

        transform.DOLocalMove(Vector2.zero, 1).SetEase(Ease.OutBounce)
        .SetDelay(0.5f)
        .OnComplete(() => 
        {
        


        });

    }

}
