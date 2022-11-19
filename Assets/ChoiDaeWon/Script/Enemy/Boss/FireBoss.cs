using EnumTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireBoss : Boss
{

    [SerializeField] private float speed;
    [SerializeField] private Transform skillPos;
    [SerializeField] private RangeCircle attackRange;
    [SerializeField] private RangeCircle walkRange;
    [field:SerializeField] protected override Animator animator { get; set; }
    [field:SerializeField] protected override UnityEvent<Transform> SkillEvent { get; set; }
    [field:SerializeField] protected override UnityEvent DieEvent { get; set; }


    private bool isAttackCool;
    private bool isAnimationPlayed;

    protected override BossState CurrentState { get; set; } = BossState.Idle;
    protected override SpriteRenderer bossRenderer { get; set; }

    private void Start()
    {

        CurrentState = BossState.Idle;

    }

    private void Update()
    {

        StateManager();
        Flip();

        if(enemy.hp >= 0)
        {
            Die();

        }

    }

    protected override void StateManager()
    {

        if (attackRange.DetectRange() == true && isAttackCool == false) ChangeState(BossState.Attack);
        else if(walkRange.DetectRange() && attackRange.DetectRange() == false && isAnimationPlayed == false) ChangeState(BossState.Walk);
        else ChangeState(BossState.Idle);

        #region Action
        Action action = CurrentState switch
        {

            BossState.Idle => Idle,
            BossState.Walk => Walk,
            BossState.Attack => Attack,
            BossState.Die => Die,
            _ => Idle,

        };

        action();

        #endregion

    }

    private void Flip()
    {

        if(walkRange.DetectRange() == true && CurrentState != BossState.Attack)
        {

            transform.localScale = walkRange.Target.transform.position switch
            {

                { x:var X } when X > transform.position.x => new Vector3(-1, 1 , 1),
                { x: var X } when X < transform.position.x => new Vector3(1, 1, 1),
                _ => transform.localScale

            };

        }

    }

    protected override void Attack()
    {

        if (isAttackCool) return;

        isAttackCool = true;

        StartCoroutine(AttackCoolCo());
        StartCoroutine(SkillCo());
        
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

        if (CurrentState == BossState.Die) return;

        CurrentState = state;

    }

    public void DieEvnet()
    {

        PoolManager.instance.Add(gameObject);

    }

    IEnumerator AttackCoolCo()
    {

        isAttackCool = true;

        yield return new WaitForSeconds(4f);

        isAttackCool = false;

    }

    IEnumerator SkillCo()
    {

        isAnimationPlayed = true;
        yield return new WaitForSeconds(1.04f);
        isAnimationPlayed = false;
        SkillEvent?.Invoke(skillPos);

    }

}
