using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
	List<Sound> sounds = new List<Sound>();

	public static SoundManager Instance;
	
	void Start() {
		Instance = this;

	}
	
	//Given a sound name, start it and register func to be callled when finished
	public void startSound(String name, bool loop, OnFinished onFinished){
		bool present = false;
		foreach (Sound sound in sounds) {
			if (sound.getName () == name) {
				present = true;
				if(loop){
					if(onFinished != null) onFinished() ;
					sound.play (loop, null);
				}
				sound.play (loop, onFinished);
			}
		}
	}

	//Given sound name, interrupt sound
	public void interruptSound(String name){
			foreach (Sound sound in sounds) {
				if (sound.getName () == name) {
				sound.interrupt();
			}
		}
	}

	public void addSound(Sound sound){
		sounds.Add (sound);
	}

	public void Update(){
	    foreach (Sound sound in sounds){
			sound.ifFinishedFinish();
		}
	}


}
