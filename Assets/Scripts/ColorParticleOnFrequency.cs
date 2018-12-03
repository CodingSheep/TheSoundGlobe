using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorParticleOnFrequency : MonoBehaviour {

    public int band;

    ParticleSystem ps;

    void Start () {
        ps = GetComponent<ParticleSystem>();
    }
	
	void Update () {
        // Update Color based on Frequency band
        var col = ps.colorOverLifetime;
        col.enabled = true;
        col.color = new Color(AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band]);
    }
}
