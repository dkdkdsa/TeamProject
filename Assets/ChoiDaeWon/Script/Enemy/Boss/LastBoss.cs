using EnumTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LastBoss : Boss
{


    [SerializeField] private RangeCircle walkRange;
    [SerializeField] private RangeCircle attackRange;
    [SerializeField] private Enemy thisEnemy;
    [SerializeField] private GameObject baseObj;
    [SerializeField] private float speed;

    [field:SerializeField] protected new UnityEvent<Animator, SpriteRenderer> SkillEvent { get; set; }
    [field: SerializeField] protected override Animator animator { get; set; }
    [field:SerializeField] protected override SpriteRenderer bossRenderer { get; set; }

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

        if (walkRange.DetectRange() && CurrentState != BossState.Attack && !attackRange.DetectRange() && isAttack == false)
        {

            ChangeState(BossState.Walk);

        }
        else if (attackRange.DetectRange() && CurrentState != BossState.Attack && isAttack == false)
        {

            ChangeState(BossState.Attack);


        }
        else if (!attackRange.DetectRange() && !walkRange.DetectRange())
        {

            ChangeState(BossState.Idle);

        }

        if (thisEnemy.hp <= 0)
        {

            ChangeState(BossState.Die);

        }

    }

    private void Flip()
    {

        if (walkRange.DetectRange() == true && CurrentState != BossState.Attack)
        {

            baseObj.transform.localScale = walkRange.Target.transform.position switch
            {

                { x: var X } when X > transform.parent.parent.position.x => new Vector3(-1, 1, 1),
                { x: var X } when X < transform.parent.parent.position.x => new Vector3(1, 1, 1),
                _ => baseObj.transform.localScale

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
        try
        {

            SkillEvent?.Invoke(animator, bossRenderer);

        }
        catch (Exception)
        {

            Debug.LogWarning("에러발생 확인 바람");

        }

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

        Vector2 dir = walkRange.Target.position - transform.parent.parent.position;

        dir = Vector2.ClampMagnitude(dir, 1);

        transform.parent.parent.Translate(dir * speed * Time.deltaTime);

    }

    public void DieEvnet()
    {

        PoolManager.instance.Add(gameObject);

    }

    public override void ChangeState(BossState state)
    {

        CurrentState = state;

    }

    public void EndAnimeEvent()
    {

        ChangeState(BossState.Walk);
        isAttack = false;

    }

}
