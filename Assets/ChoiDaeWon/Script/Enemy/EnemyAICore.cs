using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAICore : MonoBehaviour
{

    public abstract RangeCircle range { get; set; }
    public abstract Enemy enemy { get; set; }
    public abstract void StateManaging();
    public abstract void Chase(float speed);
    public abstract void DontChase();

}
