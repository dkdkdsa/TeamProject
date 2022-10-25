using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEnemyAI : EnemyAICore
{
    [field:SerializeField] protected override RangeCircle range { get; set; }
    [field:SerializeField] protected override RangeCircle attackRange { get; set; }
    [field:SerializeField] protected override Enemy enemy { get; set; }

    private bool isAttack;
    private IEnumerator attackCo;

    private void Awake()
    {

        attackCo = AttackCo();

    }

    void Update()
    {

        StateManaging();

    }

    protected override void StateManaging()
    {

        if(enemy.hp <= 0)
        {

            Die();

        }

        if (range.DetectRange() == true && attackRange.DetectRange() == false)
        {

            Chase(enemy.currentSpeed);

        }
        else if (attackRange.DetectRange() == true)
        {

            Attack();

        }
        else if(range.DetectRange() == false && attackRange.DetectRange() == false)
        {

            DontChase();

        }

    }

    protected override void Chase(float speed)
    {

        Vector2 dir = range.Target.position - transform.position;

        dir = Vector2.ClampMagnitude(dir, 1);

        transform.Translate(dir * speed * Time.deltaTime);

    }

    protected override void Attack()
    {

        if(isAttack == false)
        {

            StartCoroutine(AttackCo());

        }

    }

    protected override void DontChase()
    {



    }

    protected override void Die()
    {

        PoolManager.instance.Add(gameObject);

    }

    IEnumerator AttackCo()
    {

        isAttack = true;
        Enemy enemy = GetComponent<Enemy>();
        GameManager.instance.PlayerTakeDamage(enemy.data.attackPower);
        yield return new WaitForSeconds(1f);
        isAttack = false;

    }

}
