using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DamageText : MonoBehaviour
{

    private TextMeshPro text;

    private void Start()
    {

        text = GetComponent<TextMeshPro>();
        Show(10);

    }

    public void Show(int damage)
    {

        text.text = damage.ToString();
        transform.DOJump(new Vector2(transform.position.x, transform.position.y + 0.5f), 1, 1, 1.5f).SetEase(Ease.OutBounce);


    }

}
