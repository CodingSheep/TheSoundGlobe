using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRingOnFrequency : MonoBehaviour
{

    public int band;

    Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    void Update()
    {
        // Update Color based on Frequency band
        Color color = new Color(AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band]);
        material.SetColor("_EmissionColor", color);
    }
}
