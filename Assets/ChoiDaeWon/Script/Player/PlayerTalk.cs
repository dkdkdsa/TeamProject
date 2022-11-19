using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTalk : MonoBehaviour
{

    [SerializeField] private TextBox textBox;
    [SerializeField] private TextMeshPro textMesh;

    private void Update()
    {


        Talk();


    }

    private void Talk()
    {

        Collider2D value = Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 1.5f), 0, LayerMask.GetMask("NPC"));

        if (value)
        {

            textMesh.text = "E키를 눌러 대화";

        }
        else
        {

            textMesh.text = "";

        }

        if (Input.GetKeyDown(KeyCode.E) && value == true)
        {

            Conversation conversation = value.GetComponent<Conversation>();
            textBox.gameObject.SetActive(true);
            textBox.Set(conversation);
            conversation.Init();
            conversation.Click();

        }


    }

    public void Talk(Conversation conversation)
    {

        textBox.gameObject.SetActive(true);
        textBox.Set(conversation);
        conversation.Init();
        conversation.Click();

    }

}
