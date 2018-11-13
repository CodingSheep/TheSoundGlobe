using System.Collections;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour {

    public float startScale, maxScale;
    public bool useBuffer;

    Material material;

    public float red, green, blue;

	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (!useBuffer) {
            transform.localScale = new Vector3((AudioCalculator.amplitude * maxScale) + startScale, (AudioCalculator.amplitude * maxScale) + startScale, (AudioCalculator.amplitude * maxScale) + startScale);
            Color color = new Color(red * AudioCalculator.amplitude, green * AudioCalculator.amplitude, blue * AudioCalculator.amplitude);
            material.SetColor("_EmissionColor", color);
        } else {
            transform.localScale = new Vector3((AudioCalculator.amplitudeBuffer * maxScale) + startScale, (AudioCalculator.amplitudeBuffer * maxScale) + startScale, (AudioCalculator.amplitudeBuffer * maxScale) + startScale);
            Color color = new Color(red * AudioCalculator.amplitudeBuffer, green * AudioCalculator.amplitudeBuffer, blue * AudioCalculator.amplitudeBuffer);
            material.SetColor("_EmissionColor", color);
        }
	}
}
