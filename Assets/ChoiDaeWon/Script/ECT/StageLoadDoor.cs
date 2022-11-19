using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoadDoor : MonoBehaviour
{

    [SerializeField] private RangeCircle range;
    [SerializeField] private string[] loadStage;

    private int stageNum = 0;

    private void Update()
    {

        if (range.DetectRange())
        {

            Load();

        }

    }

    public void Load()
    {

        StageLoder.instance.LoadStage(loadStage[stageNum]);

    }

    public void AddNum()
    {

        stageNum++;

    }

}
