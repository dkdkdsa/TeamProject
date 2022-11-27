using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Clips
{

    public string clipName;
    public AudioClip clip;
    public float volume;
    public float pitch;

}

[CreateAssetMenu(menuName = "SO/AudioManager/ClipData")]
public class AudioDataSO : ScriptableObject
{

    public List<Clips> clips;

}
