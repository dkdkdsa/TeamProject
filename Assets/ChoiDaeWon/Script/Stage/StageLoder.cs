using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StageDataClass
{

    public string stageName;
    public Transform startPos;
    public UnityEvent loadEvent;

}

public class StageLoder : MonoBehaviour
{

    [SerializeField] private List<StageDataClass> stages = new List<StageDataClass>();

    public static StageLoder instance;

    private void Awake()
    {

        instance = this;

    }

    public void LoadStage(string name)
    {

        for(int i = 0; i < stages.Count; i++)
        {

            if (stages[i].stageName == name)
            {

                stages[i].loadEvent?.Invoke();
                GameManager.instance.Player.position = stages[i].startPos.position;
                GameManager.instance.Cam.transform.position = stages[i].startPos.position + new Vector3(0, 0, -10);
                break;

            }

        }

    }     

    public void StageClear()
    {

        

    }

}