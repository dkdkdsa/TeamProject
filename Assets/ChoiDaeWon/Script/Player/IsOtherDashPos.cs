using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOtherDashPos : MonoBehaviour
{
    
    public bool value { get; private set; }

    public static IsOtherDashPos instance;

    private void Awake()
    {

        instance = this;

    }

    private void Update()
    {

        Debug.Log(value);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        value = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        value = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        value = false;

    }

}
