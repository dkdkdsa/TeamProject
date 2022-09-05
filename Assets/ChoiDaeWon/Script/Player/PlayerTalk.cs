using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{

    [SerializeField] private TextBox textBox;

    private void Update()
    {

        Collider2D value = Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 1.5f), 0, LayerMask.GetMask("NPC"));

        if (Input.GetKeyDown(KeyCode.E))
        {

            textBox.gameObject.SetActive(true);
            textBox.Set(value.GetComponent<Conversation>());

        }

    }

}