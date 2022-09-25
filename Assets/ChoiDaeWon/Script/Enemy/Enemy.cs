using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject hpBar;
    [SerializeField] private EnemyDataSO data;

    private float hp;
    private BoxCollider2D boxCollider;
    private bool isDie;

    private void Awake()
    {

        hp = data.maxHP;

    }

    private void Update()
    {

        hp = Mathf.Clamp(hp, 0, data.maxHP);
        DOTween.Kill(hpBar);
        hpBar.transform.DOScaleX(hp / data.maxHP, 0.1f);
        //hpBar.transform.localScale = new Vector2(hp / data.maxHP, hpBar.transform.localScale.y);

    }

    public void TakeAttack(float damage)
    {

        hp -= damage;

    } 

}
