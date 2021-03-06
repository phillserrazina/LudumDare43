using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	private bool menuAudio = false;
	private bool levelAudio = false;
	private bool finalSceneAudio = false;

	void Awake()
	{
		if (instance != null)
			Destroy(gameObject);
		
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	private void Update()
	{
		if (!menuAudio && SceneManager.GetActiveScene().name == "MainMenu") 
		{
			StopAll ();
			Play ("MenuTheme");
			menuAudio = true;
			levelAudio = false;
			finalSceneAudio = false;
		}

		else if (!levelAudio && SceneManager.GetActiveScene().name == "Tutorial")
		{
			StopAll ();
			Play ("LevelTheme");
			menuAudio = false;
			levelAudio = true;
			finalSceneAudio = false;
		}

		else if (!finalSceneAudio && SceneManager.GetActiveScene().name == "FinalScene")
		{
			StopAll ();
			Play ("FinalTheme");
			menuAudio = false;
			levelAudio = false;
			finalSceneAudio = true;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	public void StopAll()
	{
		foreach (Sound s in sounds) {
			s.source.Stop ();
		}
	}
}
