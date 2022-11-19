using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEnemyAI : EnemyAICore
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject baseobj;
    [field:SerializeField] protected override RangeCircle range { get; set; }
    [field:SerializeField] protected override RangeCircle attackRange { get; set; }
    [field:SerializeField] protected override Enemy enemy { get; set; }

    private bool isAttack;
    private bool isDie;

    private void Awake()
    {



    }

    void Update()
    {

        StateManaging();

    }

    protected override void StateManaging()
    {

        if(enemy.hp <= 0 && isDie == false)
        {

            isDie = true;
            animator.SetTrigger("Die");

        }

        if (range.DetectRange() == true && attackRange.DetectRange() == false && isDie == false)
        {

            Chase(enemy.currentSpeed);
            Filp();

        }
        else if (attackRange.DetectRange() == true && isDie == false)
        {

            animator.SetBool("Walk", false);
            Attack();

        }
        else if(range.DetectRange() == false && attackRange.DetectRange() == false && isDie == false)
        {

            DontChase();

        }

    }

    protected override void Chase(float speed)
    {

        animator.SetBool("Walk", true);

        Vector2 dir = range.Target.position - baseobj.transform.position;

        dir = Vector2.ClampMagnitude(dir, 1);

        baseobj.transform.Translate(dir * speed * Time.deltaTime);

    }

    protected override void Attack()
    {

        if(isAttack == false)
        {

            isAttack = true;
            animator.SetTrigger("Attack");

        }

    }

    protected override void DontChase()
    {

        animator.SetBool("Walk", false);

    }

    protected override void Die()
    {

        baseobj.gameObject.SetActive(false);

    }

    public void TakeDamage()
    {

        if(attackRange.DetectRange() == true)
        {

            GameManager.instance.PlayerTakeDamage(enemy.data.attackPower);

        }

        StartCoroutine(AttDelCO());

    }

    private void Filp()
    {

        if(GameManager.instance.Player.position.x > baseobj.transform.position.x)
        {

            baseobj.transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {

            baseobj.transform.localScale = new Vector3(1, 1, 1);

        }

    }

    IEnumerator AttDelCO()
    {

        yield return new WaitForSeconds(1f);
        isAttack = false;

    }

    private void OnDisable()
    {

        isDie = false;

    }

}
