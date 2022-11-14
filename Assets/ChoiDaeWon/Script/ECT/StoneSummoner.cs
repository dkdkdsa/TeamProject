using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSummoner : MonoBehaviour
{

    [SerializeField] private Vector2 size;

    [SerializeField]private Enemy target;

    private void Awake()
    {

        target = Physics2D.BoxCast(transform.position, size, 0, Vector2.left, 0, LayerMask.GetMask("Enemy")).transform.gameObject.GetComponent<Enemy>();
        StartCoroutine("SummonCo");

    }


    IEnumerator SummonCo()
    {

        yield return new WaitForSeconds(5f);

        while (target.hp > 0)
        {

            yield return null;

            PoolManager.instance.Remove("Stone", 
                new Vector2(
                Random.Range(transform.position.x - (size.x / 2), transform.position.x + (size.x / 2)),
                Random.Range(transform.position.y - (size.y / 2), transform.position.x + (size.y / 2))
                ), Quaternion.identity).GetComponent<StoneAI>().Spawn(target);

            yield return new WaitForSeconds(30f);

        }

        yield return null;

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireCube(transform.position, size);

    }

#endif

}
