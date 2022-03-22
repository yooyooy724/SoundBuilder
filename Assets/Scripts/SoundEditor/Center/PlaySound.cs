using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlaySound : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
    [SerializeField] Button button;
	private PlaySoundInfomations SoundInfo;


    private void Start()
    {
		SoundInfo = gameObject.GetComponent<PlaySoundInfomations>();

		//this.ObserveEveryValueChanged(_ => _.SoundInfo.sound).Subscribe(_ => this.sound = _);
		this.ObserveEveryValueChanged(_ => _.SoundInfo.volume).Subscribe(_ => audioSource.volume = _);
		this.ObserveEveryValueChanged(_ => _.SoundInfo.speed).Subscribe(_ => audioSource.pitch = Mathf.Pow(10, _));

		button.onClick.AddListener(() =>
		{
			audioSource.PlayOneShot(SoundInfo.sound);
			//Debug.Log("sound played");
		});

		//HighPass
		//LowPass
		//Delay
		//Revarb

		//“ú–{Œê

		//icon snare hi-hat kick
    }
}
