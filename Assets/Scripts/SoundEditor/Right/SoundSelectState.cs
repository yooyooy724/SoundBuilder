using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SoundSelectState : MonoBehaviour
{
    public int stateId;
    private SelectionState selectionState;

    void Start()
    {
        selectionState = GameObject.Find("SelectionState").GetComponent<SelectionState>();
        this.ObserveEveryValueChanged(_ => _.selectionState.selectionStateId).Subscribe((_) => stateId = 0); //0‚Å‚Í‚È‚¢
    }

}
