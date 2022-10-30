using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CustonCol : MonoBehaviour
{

    private BoxCollider2D col;

    private void Awake()
    {
        
        col = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {

        Collider2D collider = Physics2D.OverlapBox(col.offset, col.size, 0, LayerMask.GetMask("Player"));

        if(collider == true)
        {

                

        }

    }

}
