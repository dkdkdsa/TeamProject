using EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueBoss : Boss
{

    [SerializeField] private RangeCircle skillRange;
    [SerializeField] private RangeCircle walkRange;
    [SerializeField] private float speed;
    [field:SerializeField] protected new UnityEvent SkillEvent { get; set; }
    [field: SerializeField] protected override Animator animator { get; set; }
    [field: SerializeField] protected override SpriteRenderer bossRenderer { get; set; }
    protected override UnityEvent DieEvent { get; set; }
    protected override BossState CurrentState { get; set; }

    private bool skillCool;
    private bool isDie;
    private void Update()
    {

        StateManager();
        Flip();

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

    protected override void Attack()
    {

        if (CurrentState == BossState.Attack && skillCool == false) return;

        SkillEvent?.Invoke();

        StartCoroutine(SkillReady());
        StartCoroutine(SkillDelCo());

    }

    protected override void Die()
    {

        if (isDie) return;
        isDie = true;
        animator.SetTrigger(DieHash);

    }

    protected override void Idle()
    {

    }

    public void DieEvnet()
    {

        PoolManager.instance.Add(gameObject);

    }
    protected override void StateManager()
    {

        if(skillRange.DetectRange() == true && skillCool == false)
        {

            Attack();

        }
        else if(skillCool == false && walkRange.DetectRange() == true && CurrentState != BossState.Attack)
        {

            Walk();

        }
        else
        {

            Idle();

        }

        if(enemy.hp <= 0)
        {

            Die();

        }

    }

    protected override void Walk()
    {

        if (walkRange.DetectRange())
        {

            ChangeState(BossState.Walk);

            Vector2 dir = walkRange.Target.position - transform.position;

            dir = Vector2.ClampMagnitude(dir, 1);

            transform.Translate(dir * speed * Time.deltaTime);
            animator.SetBool(WalkHash, true);

        }
        else
        {

            ChangeState(BossState.Idle);
            animator.SetBool(WalkHash, false);
        }

    }

    public override void ChangeState(BossState state)
    {

        CurrentState = state;

    }

    IEnumerator SkillReady()
    {

        animator.SetBool(AttackHash, true);
        yield return new WaitForSeconds(4.66f);
        animator.SetBool(AttackHash, false);

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

    private void OnDisable()
    {

        isDie = false;
        skillCool = false;
        enemy.hp = enemy.data.maxHP;

    }

}
