using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAI : MonoBehaviour
{

    [SerializeField] private RangeCircle rangeCircle;

    private Enemy thisEnemy;
    private bool isHeal;
    private string summoningEnemy;

    private void Update()
    {

        if (rangeCircle.DetectRange() && isHeal == false)
        {

            StartCoroutine("HealCo");

        }
        else
        {

            isHeal = false;
            StopCoroutine("HealCo");

        }

        if(thisEnemy.hp <= 0)
        {

            DeSpawn();

        }

    }

    public void Spawn(Enemy target, Vector2 pos)
    {

        rangeCircle.Target = target.transform;
        transform.position = pos;
        StartCoroutine("SummonCo");

    }

    public void DeSpawn()
    {

        PoolManager.instance.Add(gameObject);
        StopCoroutine("SummonCo");

    }

    IEnumerator HealCo()
    {

        isHeal = true;
        while (true)
        {

            Enemy enemy = rangeCircle.Target.gameObject.GetComponent<Enemy>();
            if(enemy.hp > 0)
            {

                enemy.hp += 3;
                yield return null;

            }
            yield return new WaitForSeconds(1f);

        }

    }

    IEnumerator SummonCo()
    {

        yield return new WaitForSeconds(5f);

        while (true)
        {

            for(int i = 0; i < 3; i++)
            {

                PoolManager.instance.Remove(summoningEnemy, transform.position, Quaternion.identity);
                yield return null;

            }

            yield return new WaitForSeconds(25f);

        }

    }

}
