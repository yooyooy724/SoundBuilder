using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlaySound : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
	[SerializeField] private AudioClip sound;
    [SerializeField] Button button;
	private PlaySoundInfomations SoundInfo;


    private void Start()
    {
		SoundInfo = gameObject.GetComponent<PlaySoundInfomations>();

		this.ObserveEveryValueChanged(_ => _.SoundInfo.sound).Subscribe(_ => this.sound = _);

		button.onClick.AddListener(() =>
		{
			audioSource.PlayOneShot(sound);
			Debug.Log("sound played");
		});
    }
}
