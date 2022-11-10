using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private BulletDataSO bulletData;

    private float lifeTime = 5;
    private Rigidbody2D bulletRigid;
    private int enemyLayer;
    private float time;

    private void Awake()
    {
                
        bulletRigid = GetComponent<Rigidbody2D>();
        enemyLayer = LayerMask.NameToLayer("Enemy");
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

    }

    private void Update()
    {

        Move();

    }


    private void Disable()
    {

        PoolManager.instance.Add(gameObject);

    }

    private void Move()
    {

        time += Time.deltaTime;
        bulletRigid.velocity = transform.right * speed;

        if(time >= lifeTime)
        {

            time = 0;
            Disable();

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == enemyLayer)
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeAttack(ValueManager.instance.PlayerDamage(Upgrader.instance.FindExtraDamage(bulletData.bulletType)));
            Upgrader.instance.UpgradeEvent(bulletData.bulletType, enemy);
            Disable();

        }

    }

}
