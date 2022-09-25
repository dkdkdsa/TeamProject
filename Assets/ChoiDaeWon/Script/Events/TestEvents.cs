using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    
    public void Event(Enemy enemy)
    {

        Debug.Log(enemy.gameObject.name);

    }

}
