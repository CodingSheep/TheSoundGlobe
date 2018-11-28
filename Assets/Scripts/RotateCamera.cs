using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public bool useWASD = true;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (useWASD) {
            WASDRotate();
        } else {
            VRRotate();
        }
    }

    //Debuging Visually using WASD controls instead of Headset
    void WASDRotate() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            transform.Rotate(-.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            transform.Rotate(.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, -.5f, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, .5f, 0, Space.World);
        }
    }

    //Rotate camera based on Headset Rotation
    void VRRotate() {

    }
}
