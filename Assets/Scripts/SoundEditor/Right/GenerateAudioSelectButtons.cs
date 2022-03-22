using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GenerateAudioSelectButtons : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameObject _object;
    public List<GameObject> _objects;
    private SelectionState selectionState;
    private SoundInfoContainer soundInfoContainer;
    private int generateNum;

    void Start()
    {
        selectionState = GameObject.Find("SelectionState").GetComponent<SelectionState>();
        soundInfoContainer = GameObject.Find("SoundInfoContainer").GetComponent<SoundInfoContainer>();
        this.ObserveEveryValueChanged(_ => _.selectionState.selectionStateId).Subscribe((_) =>
        {
            generateNum = soundInfoContainer.soundInfomations[_].GetAudioNum();
        });

        this.ObserveEveryValueChanged(_ => _.generateNum).Subscribe((_) =>
        {
            Generate(_);
        });

    }

    private void Generate(int generateNum)
    {
        if(_objects.Count > 0)
        {
            _objects.Clear();
            var children = transform.GetComponentsInChildren<SoundSelectButtonsManager>();
            foreach (var child in children)
            {
                Destroy(child.gameObject);
            }
            //Debug.Log(generateNum);
        }
        
        for (int i = 0; i < generateNum; i++)
        {
            _object = Instantiate(prefab, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
            _object.name = $"button{i}";
            _object.transform.parent = this.transform;
            _object.GetComponent<SoundSelectButtonsManager>().SetId(i);
            _objects.Add(_object);
            //Debug.Log("Generated");
        }
    }
}
