using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MixerLevels : MonoBehaviour {

    public AudioMixer MasterMixer;

	// Use this for initialization
	void Start () {
        MasterMixer.SetFloat("MasterVolume", -10);
        MasterMixer.SetFloat("LowpassFreq", 1000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
