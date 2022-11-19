using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlice : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private float time;

    private void Update()
    {

        time += Time.deltaTime;

        Move();

        if (time >= 3)
        {

            time = 0;
            PoolManager.instance.Add(gameObject);

        }

    }

    private void Move()
    {

        transform.Translate(transform.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            GameManager.instance.PlayerTakeDamage(damage);
            PoolManager.instance.Add(gameObject);

        }

    }

    private void OnDisable()
    {        
    }

}
