using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioclipmanager : MonoBehaviour {


    //mettre le script dans un empty GameObject.

	public Sound[] sounds;

	void Awake() 
	{
		foreach (Sound i in sounds) 
		{
			i.source = gameObject.AddComponent<AudioSource> ();

			i.source.clip = i.clip;
			i.source.volume = i.volume;
			i.source.pitch = i.pitch;
			i.source.loop = i.loop;

		}
	
	}

	public void Play(string name)
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);

		if (s != null) {
		
			s.source.Play ();

		
		}

	}

}
