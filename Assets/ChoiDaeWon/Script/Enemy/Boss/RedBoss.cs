using EnumTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedBoss : Boss
{

    [SerializeField] private RangeCircle walkRange;
    [SerializeField] private RangeCircle attackRange;
    [SerializeField] private Enemy thisEnemy;
    [SerializeField] private float speed;
    [field:SerializeField]protected override Animator animator { get; set; }
    [field:SerializeField] protected override SpriteRenderer bossRenderer { get; set; }

    private bool attackCool;
    private bool isAttack;

    protected override UnityEvent DieEvent { get; set; }
    protected override BossState CurrentState { get; set; }

    private void Update()
    {

        if (CurrentState == BossState.Die) return;

        Flip();

        StateChanger();
        StateManager();

    }

    private void StateChanger()
    {

        if(walkRange.DetectRange() && CurrentState != BossState.Attack && (!attackRange.DetectRange() || isAttack == true))
        {

            ChangeState(BossState.Walk);

        }
        else if(attackRange.DetectRange() && CurrentState != BossState.Attack && attackCool == false && isAttack == false)
        {

            ChangeState(BossState.Attack);
            

        }
        else if(!attackRange.DetectRange() && !walkRange.DetectRange())
        {

            ChangeState(BossState.Idle);

        }

        if(thisEnemy.hp <= 0)
        {

            ChangeState(BossState.Die);

        }

    }

    private void Flip()
    {

        if (walkRange.DetectRange() == true)
        {

            bossRenderer.flipX = walkRange.Target.transform.position switch
            {

                { x: var X } when X > transform.position.x => false,
                { x: var X } when X < transform.position.x => true,
                _ => bossRenderer.flipX

            };

        }

    }

    protected override void StateManager()
    {

        Action action = CurrentState switch
        {

            BossState.Idle => Idle,
            BossState.Walk => Walk,
            BossState.Attack => Attack,
            BossState.Die => Die,
            _ => Idle

        };

        action();

    }

    protected override void Attack()
    {

        if (isAttack) return;
        isAttack = true;
        animator.SetTrigger(AttackHash);

    }

    protected override void Die()
    {

        animator.SetTrigger(DieHash);

    }

    protected override void Idle()
    {

        animator.SetBool(WalkHash, false);

    }


    protected override void Walk()
    {

        animator.SetBool(WalkHash, true);

        Vector2 dir = walkRange.Target.position - transform.position;

        dir = Vector2.ClampMagnitude(dir, 1);

        transform.Translate(dir * speed * Time.deltaTime);

    }

    public override void ChangeState(BossState state)
    {

        CurrentState = state;

    }

    public void EndDashEvent()
    {

        StartCoroutine(DashCoolDown());
        ChangeState(BossState.Walk);
        isAttack = false;

    }

    public void DieEvnet()
    {

        PoolManager.instance.Add(gameObject);

    }

    IEnumerator DashCoolDown()
    {

        attackCool = true;
        yield return new WaitForSeconds(4f);
        attackCool = false;

    }

}
