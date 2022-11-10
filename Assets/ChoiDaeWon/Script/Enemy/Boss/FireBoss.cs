using EnumTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireBoss : Boss
{
    [field:SerializeField] protected override Animator animator { get; set; }
    [field:SerializeField] protected override UnityEvent<Transform> SkillEvent { get; set; }
    [field:SerializeField] protected override UnityEvent DieEvent { get; set; }

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

        Action action = CurrentState switch
        {

            BossState.Idle => Idle,
            BossState.Walk => Walk,
            BossState.Attack => Attack,
            BossState.Die => Die,
            _ => Idle,

        };

    }

    protected override void Attack()
    {

        

    }

    protected override void Die()
    {



    }

    protected override void Idle()
    {



    }

    protected override void Walk()
    {

        

    }

    public override void ChangeState(BossState state)
    {

        if (CurrentState == BossState.Die) return;

        CurrentState = state;

    }

}
