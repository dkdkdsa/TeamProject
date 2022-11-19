using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[System.Serializable]
public class Map
{

    public GameObject[] cameraPos;

}

public class StageCameraSetter : MonoBehaviour
{

    [SerializeField] private List<Map> maps = new List<Map>();
    [SerializeField] private CinemachineVirtualCamera cvcam;

    private int stageNum;


    public void Set(int num)
    {

        stageNum = num;
        cvcam.Follow = maps[stageNum].cameraPos[0].transform;

    }

    public void Next(int i)
    {

        cvcam.Follow = maps[stageNum].cameraPos[i].transform;

    }

    public void Player()
    {

        cvcam.Follow = GameManager.instance.Player;

    }

    public void Re()
    {

        stageNum = 0;

    }

}
