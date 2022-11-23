using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;

public abstract class Boss : MonoBehaviour
{

    protected readonly int AttackHash = Animator.StringToHash("Attack");
    protected readonly int DieHash = Animator.StringToHash("Die");
    protected readonly int WalkHash = Animator.StringToHash("Walk");

    protected virtual Enemy enemy { get; private set; }

    protected virtual UnityEvent<Transform> SkillEvent { get; set; }
    protected abstract UnityEvent DieEvent { get; set; }
    protected abstract Animator animator { get; set; }
    protected abstract SpriteRenderer bossRenderer { get; set; }
    protected abstract BossState CurrentState { get; set; }
    protected abstract void StateManager();
    protected abstract void Idle();
    protected abstract void Attack();
    protected abstract void Die();
    protected abstract void Walk();

    public abstract void ChangeState(BossState state);

    protected virtual void Awake()
    {

        enemy = GetComponent<Enemy>();

    }

    private void OnEnable()
    {

        try
        {


            enemy = GetComponent<Enemy>();
            enemy.hp = enemy.data.maxHP;

        }
        catch (System.Exception)
        {



        }

    }

}
