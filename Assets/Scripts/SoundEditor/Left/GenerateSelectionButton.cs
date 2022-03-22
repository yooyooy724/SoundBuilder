using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IGenerateNum
{
    public int Number();
}
public class GenerateSelectionButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameObject _object;
    public List<GameObject> _objects;
    private int generateNum;

    void Start()
    {
        generateNum = GameObject.Find("SoundInfoContainer").GetComponent<SoundInfoContainer>().soundInfomations.Length; //this.GetComponentInParent<ReflectSelection>();

        for (int i = 0; i < generateNum; i++)
        {
            _object = Instantiate(prefab, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
            _object.name = $"button{i}";
            _object.transform.parent = this.transform;
            _object.GetComponent<SelectionButtonsManager>().SetId(i);
            _objects.Add(_object);
        }
        
    }
}
