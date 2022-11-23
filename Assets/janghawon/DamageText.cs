using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageText : MonoBehaviour
{

    private TextMeshPro text;

    private void Awake()
    {

        text = GetComponent<TextMeshPro>();

    }

    public void Show(float text)
    {

        this.text.text = text.ToString();

        transform.DOMoveY(transform.position.y + 3, 0.3f)
        .OnComplete(() =>
        {

            PoolManager.instance.Add(gameObject);

        });

    }

}
