using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed; 
    private Rigidbody2D bulletRigid;

    private void Awake()
    {
        
        bulletRigid = GetComponent<Rigidbody2D>();

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
}
