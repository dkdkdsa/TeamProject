using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private RangeCircle range;
    [SerializeField] private string stageName;

    private void Update()
    {
        
        Chack();

    }

    private void Chack()
    {

        if(range.DetectRange() == true)
        {

            StageLoder.instance.LoadStage(stageName);

        }

    }

}
