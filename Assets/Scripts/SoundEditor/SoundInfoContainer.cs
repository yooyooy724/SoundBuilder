using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInfoContainer : MonoBehaviour
{
    public SoundInfomations[] soundInfomations;
    void Awake()
    {
        soundInfomations = transform.GetComponentsInChildren<SoundInfomations>();
    }
}
