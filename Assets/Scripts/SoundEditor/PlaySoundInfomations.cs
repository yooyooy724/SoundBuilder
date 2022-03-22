using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlaySoundInfomations : MonoBehaviour
{
    public float volume;
    public float speed;
    public AudioClip sound;

    private SelectionState selectionState;
    private SoundSelectState soundSelectState;
    private SoundInfoContainer soundInfoContainer;

    private void Start()
    {
        selectionState = GameObject.Find("SelectionState").GetComponent<SelectionState>();
        soundSelectState = GameObject.Find("SoundSelectState").GetComponent<SoundSelectState>();
        soundInfoContainer = GameObject.Find("SoundInfoContainer").GetComponent<SoundInfoContainer>();

        for (int i = 0; i < soundInfoContainer.soundInfomations.Length; i++)
        {
            int count = i;
            this.ObserveEveryValueChanged(_ => _.soundInfoContainer.soundInfomations[count].volume).Subscribe(_ => volume = _);
            this.ObserveEveryValueChanged(_ => _.soundInfoContainer.soundInfomations[count].speed).Subscribe(_ => speed = _);
        }

        this.ObserveEveryValueChanged(_ => _.selectionState.selectionStateId).Subscribe((_) =>
        {
            sound = soundInfoContainer.soundInfomations[_].GetAudio(soundSelectState.stateId);

            volume = soundInfoContainer.soundInfomations[_].volume;
            speed = soundInfoContainer.soundInfomations[_].speed;
        });
        this.ObserveEveryValueChanged(_ => _.soundSelectState.stateId).Subscribe((_) =>
        {
            sound = soundInfoContainer.soundInfomations[selectionState.selectionStateId].GetAudio(_);
        });

    }
}
