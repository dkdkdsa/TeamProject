using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObjectRenderSetter : MonoBehaviour
{

    [SerializeField] private GameObject basepos;
    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        
        spriterenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        
        if(basepos.transform.position.y > GameManager.instance.Player.position.y)
        {

            spriterenderer.sortingOrder = -10;

        }
        else
        {

            spriterenderer.sortingOrder = 10;

        }

    }

}
