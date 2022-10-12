using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private BulletDataSO bulletData;
    
    private Rigidbody2D bulletRigid;
    private int enemyLayer;

    private void Awake()
    {
        
        bulletRigid = GetComponent<Rigidbody2D>();
        enemyLayer = LayerMask.NameToLayer("Enemy");

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
        
        bulletRigid.velocity = transform.right * speed;

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
