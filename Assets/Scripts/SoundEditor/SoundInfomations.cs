using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInfomations : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public float volume = 0.5f;
    public float speed = 0.0f;
    public int soundId = 0;
    public AudioClip GetAudio(int id) => audioClips[id];
    public int GetAudioNum()
    {
        Debug.Log(audioClips.Count);
        return audioClips.Count;
    }
}
