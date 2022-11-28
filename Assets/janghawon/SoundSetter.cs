using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetter : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        float value = PlayerPrefs.GetFloat("Volume");
        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach(var i in audioSource)
        {
            i.volume = value;

        }

    }
}
