using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int HP;

    private GameObject hpBar;
    private BoxCollider2D boxCollider;
    private bool isDie;

    private void Update()
    {
        


    }

    public void TakeAttack(int damage)
    {

        DamageText text = PoolManager.instance.Remove("DamageText", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity).GetComponent<DamageText>();

        text.Show(damage);

    } 

}
