using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRigid;
    private bool isMove;
    private bool isDash;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {                

        Move();
        Flip();
        Dash();

    }

    private void Dash()
    {

        if (Input.GetMouseButtonDown(1) && isDash == false)
        {

            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            isDash = true;
            transform.position = Vector2.MoveTowards(transform.position, mousePos, 3);
            StartCoroutine(DelayCo());

        }

    }

    private void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float rawX = Input.GetAxisRaw("Horizontal");
        float rawY = Input.GetAxisRaw("Vertical");

        if (rawX != 0 || rawY != 0) isMove = true;
        else isMove = false;

        animator.SetBool("Run", isMove);

        float slow = isMove ? 1.0f : 0.5f;
        Vector2 dir = new Vector2(x, y);

        playerRigid.velocity = dir * speed * slow;

    }

    private void Flip()
    {

        Vector2 pointerInput = Input.mousePosition;
        pointerInput = cam.ScreenToWorldPoint(pointerInput);
        Vector3 dir = (Vector3)pointerInput - transform.position;
        Vector3 result = Vector3.Cross(Vector2.up, dir);

        spriteRenderer.flipX = result.z > 0;

    }

    IEnumerator DelayCo()
    {

        yield return new WaitForSeconds(1f);
        isDash = false;

    }

}
