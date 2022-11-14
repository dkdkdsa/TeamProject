using EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueBoss : Boss
{

    [SerializeField] private RangeCircle skillRange;
    [SerializeField] private RangeCircle walkRange;
    [field:SerializeField] protected new UnityEvent SkillEvent { get; set; }
    [field: SerializeField] protected override Animator animator { get; set; }
    [field: SerializeField] protected override SpriteRenderer bossRenderer { get; set; }
    protected override UnityEvent DieEvent { get; set; }
    protected override BossState CurrentState { get; set; }

    private bool skillCool;

    protected override void Attack()
    {

        if (CurrentState == BossState.Attack && skillCool == false) return;

        SkillEvent?.Invoke();

        StartCoroutine(SkillDelCo());

    }

    protected override void Die()
    {

    }

    protected override void Idle()
    {

    }

    protected override void StateManager()
    {

    }

    protected override void Walk()
    {

    }

    public override void ChangeState(BossState state)
    {

    }

    IEnumerator SkillReady()
    {

        yield return null;

    }

    IEnumerator SkillDelCo()
    {

        skillCool = true;
        CurrentState = BossState.Attack;
        yield return new WaitForSeconds(6f);

        CurrentState = BossState.Idle;

        yield return new WaitForSeconds(5f);

        skillCool = false;

    }

}
