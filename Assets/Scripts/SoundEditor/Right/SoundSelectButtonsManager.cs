using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public enum SoundSelectButtonsState
{
    unselected,
    selected
}
public class SoundSelectButtonsManager : MonoBehaviour
{
    private int thisId;
    public void SetId(int id) => thisId = id;
    private SelectionButtonsState state;
    [SerializeField] Button button;
    [SerializeField] Button button_outline;
    private SoundSelectState soundSelectState;

    void Start()
    {
        soundSelectState = GameObject.Find("SoundSelectState").GetComponent<SoundSelectState>();

        button.transform.GetChild(0).GetComponent<Text>().text = (thisId + 1).ToString();
        button_outline.transform.GetChild(0).GetComponent<Text>().text = (thisId + 1).ToString();

        this.ObserveEveryValueChanged(_ => _.soundSelectState.stateId).Subscribe((_) =>
        {
            if (_ == thisId)
                ReflectState(SoundSelectButtonsState.selected);
            else
                ReflectState(SoundSelectButtonsState.unselected);
        });

        button_outline.onClick.AddListener(() => soundSelectState.stateId = thisId);
    }

    private void ReflectState(SoundSelectButtonsState state)
    {
        switch (state)
        {
            case SoundSelectButtonsState.unselected:
                button.gameObject.SetActive(false);
                button_outline.gameObject.SetActive(true);
                break;
            case SoundSelectButtonsState.selected:
                button.gameObject.SetActive(true);
                button_outline.gameObject.SetActive(false);
                break;
        }
    }
}
