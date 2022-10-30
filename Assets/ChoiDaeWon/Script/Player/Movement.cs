using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject dashPos;
    [SerializeField] private GameObject rootObj;
    [SerializeField] private bool moveAble;
    [SerializeField] private Animator animator;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRigid;
    private bool isDie;
    private bool dashCoolDown;
    private bool isDash;

    public Vector2 currentDir;
    public bool MoveAble { get { return moveAble; } set { moveAble = value; } }

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigid = GetComponent<Rigidbody2D>();
        moveAble = true;

    }

    private void Update()
    {

        if(GameManager.instance.able == false || isDie == true) return;

        if (moveAble == true) 
        { 

            Move();
            Flip();
        
        }
        
        if(IsOtherDashPos.instance.value == false) Dash();

    }

    private void Dash()
    {

        if (Input.GetKeyDown(KeyCode.Space) && dashCoolDown == false && moveAble == true && IsOtherDashPos.instance.value == false)
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


        if (Input.GetMouseButton(1))
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
        bool value = result.z > 0;

        spriteRenderer.flipX = result.z > 0;

        rootObj.transform.localScale = value switch
        {

            true => new Vector3(2, 2, 1),
            false => new Vector3(-2, 2, 1),

        };

    }

    public void Die()
    {

        if (isDie == true) return;

        isDie = true;
        animator.SetTrigger("Die");

    }

    IEnumerator DelayCo()
    {

        yield return new WaitForSeconds(1f);
        dashCoolDown = false;

    }

}
