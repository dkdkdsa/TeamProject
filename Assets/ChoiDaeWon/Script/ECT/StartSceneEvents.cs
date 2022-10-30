using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartSceneEvents : MonoBehaviour
{

    [SerializeField] private Image helpImage;
    [SerializeField] private Image fadeImage;

    public void Fade()
    {

        fadeImage.DOFade(1, 0.3f)
        .OnComplete(() =>
        {

            SceneManager.LoadScene("MainScenes");

        });

    }

    public void HelpImage(bool value)
    {

        if (value)
        {

            helpImage.transform.DOScaleY(1, 0.3f);

        }
        else
        {

            helpImage.transform.DOScaleY(0, 0.3f);

        }

    }

}
