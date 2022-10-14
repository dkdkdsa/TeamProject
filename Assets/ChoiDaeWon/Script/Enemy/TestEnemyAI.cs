using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAI : EnemyAICore
{
    [field:SerializeField] public override RangeCircle range { get; set; }
    [field:SerializeField] public override Enemy enemy { get; set; }


    void Update()
    {

        StateManaging();

    }

    public override void StateManaging()
    {

        if(range.DetectRange() == true)
        {

            Chase(enemy.currentSpeed);

        }
        else
        {

            DontChase();

        }

    }

    public override void Chase(float speed)
    {

        Vector2 dir = range.Target.position - transform.position;

        transform.Translate(dir * speed * Time.deltaTime);

    }

    public override void DontChase()
    {



    }

}
