using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D playerRigid;
    private bool isMove;

    private void Awake()
    {
        
        playerRigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        Move();

    }

    private void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float rawX = Input.GetAxisRaw("Horizontal");
        float rawY = Input.GetAxisRaw("Vertical");

        if (rawX != 0 || rawY != 0) isMove = true;
        else isMove = false;

        float slow = isMove ? 1.0f : 0.5f;

        playerRigid.velocity = new Vector2(x, y) * speed * slow;

    }

}
