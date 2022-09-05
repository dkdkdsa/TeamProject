using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlotShow : MonoBehaviour
{

    private RectTransform rectTransform;

    private void Awake()
    {

        rectTransform = GetComponent<RectTransform>();
        Show();

    }

    public void Show()
    {


        transform.localScale = new Vector2(0.1f, 0.1f);
        Sequence sequence = DOTween.Sequence();
        sequence
        .Append(rectTransform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 720)), 3))
        .Join(transform.DOScale(new Vector2(1.3f, 1.3f), 3));

    }

}
