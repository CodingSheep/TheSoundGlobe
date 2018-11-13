using System.Collections;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public int band;
    public float startScale, maxScale;
    public bool useBuffer;

    Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (useBuffer) {
            transform.localScale = new Vector3(transform.localScale.x, (AudioCalculator.audioBandBuffer[band] * maxScale) + startScale, transform.localScale.z);
            Color color = new Color(AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        } else {
            transform.localScale = new Vector3(transform.localScale.x, (AudioCalculator.audioBand[band] * maxScale) + startScale, transform.localScale.z);
            Color color = new Color(AudioCalculator.audioBand[band], AudioCalculator.audioBand[band], AudioCalculator.audioBand[band]);
            material.SetColor("_EmissionColor", color);
        }
	}
}
