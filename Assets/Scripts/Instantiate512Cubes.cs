using System.Collections;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {

    public GameObject sampleCubePrefab;
    GameObject[] sampleCubes = new GameObject[512];

    public float maxScale;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 512; i++) {
            GameObject instanceOfCube = (GameObject)Instantiate(sampleCubePrefab);
            instanceOfCube.transform.position = this.transform.position;
            instanceOfCube.transform.parent = this.transform;
            instanceOfCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceOfCube.transform.position = Vector3.forward * 100;

            sampleCubes[i] = instanceOfCube;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 512; i++) {
            if (sampleCubes[i] != null) {
                sampleCubes[i].transform.localScale = new Vector3(10, (AudioCalculator.samplesLeft[i] * maxScale) + 2, 10);
            }
        }
	}
}
