using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private BoxCollider2D boxCollider;

    private void TakeAttack()
    {

        Collider2D col = Physics2D.OverlapBox(transform.position, boxCollider.size, 0, LayerMask.GetMask("Bullet"));

        bool value = col;

    } 

}
