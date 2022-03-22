using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public enum SelectionButtonsState
{
    unselected,
    selected,
    unselectable,
}
public class SelectionButtonsManager : MonoBehaviour
{
    private int thisId;
    public void SetId(int id) => thisId = id;
    private SelectionButtonsState state;
    // public void SetState(SelectionButtonsState state) => this.state = state;
    [SerializeField] Button button;
    [SerializeField] Button button_outline;
    private SelectionState reflector;

    void Start()
    {
        reflector = GameObject.Find("SelectionState").GetComponent<SelectionState>(); //this.GetComponentInParent<ReflectSelection>();
        button.transform.GetChild(0).GetComponent<Text>().text = (thisId+1).ToString();
        button_outline.transform.GetChild(0).GetComponent<Text>().text = (thisId + 1).ToString();

        this.ObserveEveryValueChanged(_ => _.reflector.selectionStateId).Subscribe((_) => 
        {
            if (_ == thisId)
                ReflectState(SelectionButtonsState.selected);
            else
                ReflectState(SelectionButtonsState.unselected);
        });

        button_outline.onClick.AddListener(() => reflector.selectionStateId = thisId);
    }

    private void ReflectState(SelectionButtonsState state)
    {
        switch (state)
        {
            case SelectionButtonsState.unselected:
                button.gameObject.SetActive(false);
                button_outline.gameObject.SetActive(true);
                break;
            case SelectionButtonsState.selected:
                button.gameObject.SetActive(true);
                button_outline.gameObject.SetActive(false);
                break;
            case SelectionButtonsState.unselectable:
                button.gameObject.SetActive(false);
                button_outline.gameObject.SetActive(false);
                break;
        }
    }
}
