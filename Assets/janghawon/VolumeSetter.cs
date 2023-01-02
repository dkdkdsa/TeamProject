using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{

    [SerializeField] private Slider slider;

    private void Awake()
    {
        
        if(PlayerPrefs.GetInt("Start") == 0)
        {

            slider.value = 1;
            PlayerPrefs.SetInt("Start", 1);

        }
        else
        {

            slider.value = PlayerPrefs.GetFloat("Volume");

        }

    }

    private void Update()
    {

        PlayerPrefs.SetFloat("Volume", slider.value);

    }

}
