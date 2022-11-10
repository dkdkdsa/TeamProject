using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{

    private Dictionary<string, Clips> clips = new Dictionary<string, Clips>();
    private AudioSource audioSource;

    public static AudioManager instance;

    public AudioManager(AudioDataSO data, GameObject obj)
    {

        instance = this;

        audioSource = obj.GetComponent<AudioSource>();

        if(audioSource == null)
        {

            obj.AddComponent<AudioSource>();

        }

        audioSource.playOnAwake = false;

        for(int i = 0; i < data.clips.Count; i++)
        {

            clips.Add(data.clips[i].clipName, data.clips[i]);

        }

    }

    private void SetAudioSource(Clips clips)
    {

        audioSource.clip = clips.clip;
        audioSource.volume = clips.volume;
        audioSource.pitch = clips.pitch;

    }

    private void ChackKey(string name)
    {

        if(clips.ContainsKey(name) == false)
        {

            Debug.LogError($"{name} 이라는 이름의 오디오 클립이 존재하지 않습니다");

        }

    }

    public void Play(string name)
    {

        ChackKey(name);

        Clips clips = this.clips[name];

        SetAudioSource(clips);

        audioSource.Play();

    }

    public void Stop()
    {

        audioSource.Stop();

    }

    public void SetVolume(string name, float value)
    {

        clips[name].volume = value;

    }

    public void SetVolumeAndPitch(string name, float volume, float pitch)
    {

        clips[name].volume = volume;
        clips[name].pitch = pitch;

    }

}
