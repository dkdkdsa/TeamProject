using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextMove : MonoBehaviour
{
    [SerializeField] List<string> text = new List<string>();
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] GameObject txtbutton;
    [SerializeField] GameObject button;

    int i = 0;
    bool isScene = true;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = text[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (isScene == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Start");
            }
        }
    }

    public void MouceClick()
    {
        if (i < 12)
        {
            txt.text = text[i+1];
            i++;
        }
        else if(i >= 12)
        {
            txtbutton.SetActive(false);
            txt.text = null;
            isScene = false;
        }

            float randomX = Random.Range(-650, 0);
        float randomY = Random.Range(-400, 400);
        button.transform.localPosition = new Vector3(randomX, randomY, 0);
    }
}
