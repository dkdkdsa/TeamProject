using EnumTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireBoss : Boss
{

    [SerializeField] private Transform skillPos;
    [SerializeField] private RangeCircle attackRange;
    [SerializeField] private RangeCircle walkRange;
    [field:SerializeField] protected override Animator animator { get; set; }
    [field:SerializeField] protected override UnityEvent<Transform> SkillEvent { get; set; }
    [field:SerializeField] protected override UnityEvent DieEvent { get; set; }


    private bool isAttackCool;

    protected override BossState CurrentState { get; set; } = BossState.Idle;
    protected override SpriteRenderer bossRenderer { get; set; }

    private void Start()
    {

        CurrentState = BossState.Idle;

    }

    private void Update()
    {

        StateManager();

    }

    protected override void StateManager()
    {

        if (attackRange.DetectRange() == true && isAttackCool == false) ChangeState(BossState.Attack);
        else if(walkRange.DetectRange() && attackRange.DetectRange() == false) ChangeState(BossState.Walk);
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



    }

    protected override void Idle()
    {

        animator.SetBool(WalkHash, false);

    }

    protected override void Walk()
    {

        animator.SetBool(WalkHash, true);

    }

    public override void ChangeState(BossState state)
    {

        if (CurrentState == BossState.Die) return;

        CurrentState = state;

    }

    IEnumerator AttackCoolCo()
    {

        isAttackCool = true;

        yield return new WaitForSeconds(4f);

        isAttackCool = false;

    }

    IEnumerator SkillCo()
    {

        yield return new WaitForSeconds(1.04f);

        SkillEvent?.Invoke(skillPos);

    }

}