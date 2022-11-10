using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMChanger : MonoBehaviour
{

    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();

    private AudioSource audioSource;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();

    }

    public void ChangeBGM(int num)
    {

        audioSource.clip = clips[num];
        audioSource.Play();

    }

}
