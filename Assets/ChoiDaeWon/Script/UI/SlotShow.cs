using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotShow : MonoBehaviour
{

    private Image image;

    private void Awake()
    {

        image = GetComponent<Image>();

    }

    public void Show()
    {

        image.color = new Color(255, 255, 255, 0);
        transform.localScale = new Vector2(0.1f, 0.1f);
        Sequence sequence = DOTween.Sequence();
        sequence
        .Append(transform.DOScale(new Vector2(1.3f, 1.3f), 0.5f).SetEase(Ease.InExpo))
        .OnComplete(() =>
        {

            Sequence sequence1 = DOTween.Sequence();
            sequence1
            .Append(transform.DOScale(new Vector2(0.9f, 0.9f), 0.3f).SetEase(Ease.InOutBounce))
            .Append(transform.DOScale(Vector2.one, 0.1f)).SetEase(Ease.OutBounce);
            
        })
        .Join(image.DOFade(1, 0.5f));
        

    }

    public void UIReset()
    {
        
        Sequence seq = DOTween.Sequence();
        seq
        .Append(transform.DOScale(Vector2.zero, 0.1f)).SetEase(Ease.InExpo)
        .Join(image.DOFade(0, 0.1f));


    }

}
