using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAICore : MonoBehaviour
{

    protected abstract RangeCircle attackRange { get; set; }
    protected abstract RangeCircle range { get; set; }
    protected abstract Enemy enemy { get; set; }
    protected abstract void Die();
    protected abstract void StateManaging();
    protected abstract void Chase(float speed);
    protected abstract void DontChase();
    protected abstract void Attack();

}
