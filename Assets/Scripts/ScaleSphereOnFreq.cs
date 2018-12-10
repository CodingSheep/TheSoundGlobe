using System.Collections;
using UnityEngine;

public class ScaleSphereOnFreq : MonoBehaviour
{

    public int band;
    public float startScale, maxScale;

    Material material;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((AudioCalculator.audioBandBuffer[band] * maxScale) + startScale, (AudioCalculator.audioBandBuffer[band] * maxScale) + startScale, (AudioCalculator.audioBandBuffer[band] * maxScale) + startScale);

        Color color;

        if (band == 1)
            color = new Color(AudioCalculator.audioBandBuffer[band] / 2, AudioCalculator.audioBandBuffer[band] / 2, AudioCalculator.audioBandBuffer[band] / 2);
        else
            color = new Color(AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band], AudioCalculator.audioBandBuffer[band]);
        material.SetColor("_EmissionColor", color);
    }
}
