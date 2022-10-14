using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{

    public string name;
    public float textSpeed;
    [TextArea] public string dialoug;
    public UnityEvent endEnent;
    public UnityEvent clickEvent;
    public Sprite sprite;

}

public class Conversation : MonoBehaviour
{
    
    [SerializeField] private List<Dialogue> dialogueList = new List<Dialogue>();
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject textBox;

    private int count;
    private bool isTalking;

    public void Click()
    {

        if(isTalking == false && dialogueList.Count > count) Talk();
        else if(dialogueList.Count <= count)
        {

            textBox.gameObject.SetActive(false);
            GameManager.instance.SetPlayerGunAble(true);
            GameManager.instance.SetPlayerMoveAble(true);

        }

    }

    public void Init()
    {

        count = 0;

    }

    public void Skip()
    {
        
        DOTween.Kill(this);
        text.text = dialogueList[count].dialoug; 
        count++;
        isTalking = false;

    }

    private void Talk()
    {

        text.text = null;
        isTalking = true;
        dialogueList[count].clickEvent?.Invoke();
        text.DOText(dialogueList[count].dialoug, dialogueList[count].textSpeed)
        .OnComplete(() =>
        {

            dialogueList[count].endEnent?.Invoke();
            isTalking = false;
            count++;

        });

    }


}
