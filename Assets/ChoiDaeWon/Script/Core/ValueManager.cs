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

        float value;
        value = Random.Range(attackPower - 1, attackPower + 1);
        value += value * (extraDamage / 100);

        return value;

    }

}
