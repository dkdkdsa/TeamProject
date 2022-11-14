using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAI : MonoBehaviour
{

    [SerializeField] private RangeCircle rangeCircle;
    [SerializeField] private string summoningEnemy;

    private Enemy thisEnemy;
    private bool isHeal;

    private void Update()
    {

        if (rangeCircle.DetectRange() && isHeal == false)
        {

            StartCoroutine("HealCo");

        }
        else if(rangeCircle.DetectRange() == false)
        {

            isHeal = false;
            StopCoroutine("HealCo");

        }

        if(thisEnemy.hp <= 0)
        {

            DeSpawn();

        }

       

    }

    public void Spawn(Enemy target)
    {

        rangeCircle.Target = target.transform;
        thisEnemy = GetComponent<Enemy>();
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

                enemy.hp += 10;
                yield return null;

            }
            yield return new WaitForSeconds(3f);

        }

    }

    IEnumerator SummonCo()
    {

        yield return new WaitForSeconds(5f);

        while (true)
        {

            for(int i = 0; i < 3; i++)
            {

                PoolManager.instance.Remove(summoningEnemy, 
                    new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1)
                    , Random.Range(transform.position.y + 1, transform.position.y -1))
                    , Quaternion.identity);
                yield return null;

            }

            yield return new WaitForSeconds(25f);

        }

    }

}
