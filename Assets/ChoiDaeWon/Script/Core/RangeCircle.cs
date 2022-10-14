using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{

    [SerializeField] private float rangeRadius;
    [SerializeField] private bool isOutter;
    [field:SerializeField] public Transform Target { get; private set; }


    public bool DetectRange()
    {

        float f = Vector2.Distance(Target.position, transform.position);

        if(isOutter == false)
        {

            if (f < rangeRadius)
            {

                return true;

            }
            else
            {

                return false;

            }

        }
        else
        {

            if(f > rangeRadius)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        if (isOutter == false)
        {

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, rangeRadius);

        }
        else
        {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangeRadius);

        }

    }

#endif

}
