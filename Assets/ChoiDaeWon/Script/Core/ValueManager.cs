using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{

    public static ValueManager instance;
    public float attackPower;

    private void Awake()
    {
        
        instance = this;

    }

    public float PlayerDamage(float extraDamage)
    {

        float value = attackPower;
        value += value * (extraDamage / 100);

        Debug.Log(value);

        return value;

    }

}
