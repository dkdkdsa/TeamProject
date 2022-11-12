using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource[] sorces;

    public void Play(int index)
    {

        sorces[index].Play();

    }

}
