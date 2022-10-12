using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject dashPos;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRigid;
    private Vector2 currentDir;
    private bool isMove;
    private bool moveAble;
    private bool dashCoolDown;
    private bool isDash;

    public bool MoveAble { get { return moveAble; } set { moveAble = value; } }

    private void Awake()
    {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigid = GetComponent<Rigidbody2D>();
        moveAble = true;

    }

    private void Update()
    {

        if (moveAble == true) 
        { 

            Move();
            Flip();
            Dash();
        
        } 

    }

    private void Dash()
    {

        if (Input.GetKeyDown(KeyCode.Space) && dashCoolDown == false)
        {

            //currentDir = cam.ScreenToWorldPoint(Input.mousePosition);
            animator.SetBool("Dash", true);
            currentDir = dashPos.transform.position;
            Debug.Log(currentDir);
            dashCoolDown = true;
            isDash = true;
            moveAble = false;
            StartCoroutine(DelayCo());

        }

        if(isDash == true) transform.position = Vector2.MoveTowards(transform.position, currentDir, speed * Time.deltaTime * 10);

        if((Vector3)currentDir == transform.position)
        {

            animator.SetBool("Dash", false);
            isDash = false;
            moveAble = true;

        }

    }


    private void Move()
    {


        if (Input.GetMouseButtonDown(1))
        {

            currentDir = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        if (transform.position != (Vector3)currentDir) animator.SetBool("Run", true);
        else animator.SetBool("Run", false);


        transform.position = Vector2.MoveTowards(transform.position, currentDir, speed * Time.deltaTime);

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
        dashCoolDown = false;

    }

}
