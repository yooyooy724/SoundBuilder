using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlaySound : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip sound;
	[SerializeField] Button button;


    private void Start()
    {

		

		button.onClick.AddListener(() =>
		{
			audioSource.PlayOneShot(sound);
			Debug.Log("sound played");
		});
    }
}
