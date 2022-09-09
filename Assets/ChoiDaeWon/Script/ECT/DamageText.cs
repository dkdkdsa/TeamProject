using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DamageText : MonoBehaviour
{

    private TextMeshPro text;

    private void Awake()
    {

        text = GetComponent<TextMeshPro>();

    }

    public void Show(int damage)
    {

        text.text = damage.ToString();
        transform.DOJump(new Vector2(transform.position.x, transform.position.y + 0.5f), 1, 1, 0.5f).SetEase(Ease.OutBounce);


    }

}
