using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

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
    [SerializeField] private Image fadeImage;

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

                GameManager.instance.SetPlayerGunAble(false);
                GameManager.instance.SetPlayerMoveAble(false);
                stages[i].loadEvent?.Invoke();
                Sequence sequence = DOTween.Sequence();
                Sequence sequence2 = DOTween.Sequence();
                sequence
                .Append(fadeImage.DOFade(1, 0.3f))
                .OnComplete(() =>
                {


                    GameManager.instance.Player.position = stages[i].startPos.position;
                    GameManager.instance.Cam.transform.position = stages[i].startPos.position + new Vector3(0, 0, -10);
                    Movement movement = FindObjectOfType<Movement>();
                    movement.currentDir = stages[i].startPos.position;


                 });


                sequence2
                .AppendInterval(0.5f)
                .Append(fadeImage.DOFade(0, 0.3f))
                .OnComplete(() =>
                {


                    GameManager.instance.SetPlayerGunAble(true);
                    GameManager.instance.SetPlayerMoveAble(true);

                });



                break;

            }

        }

    }     

    public void StageClear()
    {

        

    }

}