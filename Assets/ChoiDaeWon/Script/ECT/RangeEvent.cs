using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeEvent : MonoBehaviour
{

    [SerializeField] private RangeCircle range;
    [SerializeField] private UnityEvent events;

    private bool isInvorked;

    private void Update()
    {

        //Debug.Log(isInvorked);

        if(range.DetectRange() == true && isInvorked == false)
        {

            isInvorked = true;
            events.Invoke();

        }
        else if (range.DetectRange() == false)
        {

            isInvorked = false;

        }

    }

}
