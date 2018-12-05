using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MixerLevels : MonoBehaviour
{

    public AudioMixer MasterMixer;
    public GameObject currentSelected;
    float pitch = 1f;
    float Lowpass = 22000;
    // Use this for initialization
    void Start()
    {
        MasterMixer.SetFloat("MasterVolume", AudioCalculator.Volume);
        MasterMixer.SetFloat("LowpassFreq", Lowpass);
        MasterMixer.SetFloat("Pitch", pitch);
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if ((Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Dial"))
        {
            //Debug.Log("Highlighted!");
            if (Input.GetMouseButton(0))
            {
                //add collider reference otherwise you can't access gameObject!
                //hit.collider.gameObject.transform.parent = transform;
                currentSelected = hit.collider.gameObject;
                if (currentSelected.name == "Volume")
                {
                    Debug.Log(currentSelected.name);
                    pitch = ValueEditor("Pitch", pitch /*AudioCalculator.Volume*/, 0.1f, currentSelected);
                }
                if (currentSelected.name == "Lowpass")
                {
                    Debug.Log(currentSelected.name);
                    Lowpass = ValueEditor("LowpassFreq", Lowpass, 100, currentSelected);
                }
            }
            else
            {
                currentSelected = null;
            }
        }
        else
        {
            currentSelected = null;
        }
    }

    //This will take a name of the value you are planning to change, and it will take the values to change and return the overarching value
    float ValueEditor(string Value, float ValueChanged, float Increment, GameObject currentSelected)
    {
        if (Input.GetKey("q"))
        {
            currentSelected.transform.Rotate(0, 1, 0);
            ValueChanged = ValueChanged - Increment;
        }
        if (Input.GetKey("e"))
        {
            currentSelected.transform.Rotate(0, -1, 0);
            ValueChanged = ValueChanged + Increment;
        }
        
        MasterMixer.SetFloat(Value, ValueChanged);
        return ValueChanged;
    }
}
