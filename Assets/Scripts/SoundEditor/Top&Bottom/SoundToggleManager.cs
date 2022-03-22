using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SoundToggleManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider speedSlider;
    private SelectionState selectionState;
    private SoundInfoContainer soundInfoContainer;

    // Start is called before the first frame update
    void Start()
    {
        selectionState = GameObject.Find("SelectionState").GetComponent<SelectionState>();
        soundInfoContainer = GameObject.Find("SoundInfoContainer").GetComponent<SoundInfoContainer>();


        this.ObserveEveryValueChanged(_ => _.selectionState.selectionStateId).Subscribe((_) => 
        {
            volumeSlider.value = soundInfoContainer.soundInfomations[_].volume;
            speedSlider.value = soundInfoContainer.soundInfomations[_].speed;
        });

        volumeSlider.onValueChanged.AddListener((_) =>
        {
            soundInfoContainer.soundInfomations[selectionState.selectionStateId].volume = _;
            Debug.Log("volume changed");

        });

        speedSlider.onValueChanged.AddListener((_) =>
        {
            soundInfoContainer.soundInfomations[selectionState.selectionStateId].speed = _;
            Debug.Log("speed changed");

        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
