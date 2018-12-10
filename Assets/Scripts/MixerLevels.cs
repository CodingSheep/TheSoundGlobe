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
    float Highpass = 10;
    // Use this for initialization
    void Start()
    {
        MasterMixer.SetFloat("MasterVolume", AudioCalculator.Volume);
        MasterMixer.SetFloat("LowpassFreq", Lowpass);
        MasterMixer.SetFloat("HighpassFreq", Lowpass);
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
                    AudioCalculator.Volume = ValueEditor("MasterVolume", AudioCalculator.Volume, 0.5f, currentSelected);
                    if (AudioCalculator.Volume > 40)
                    {
                        AudioCalculator.Volume = 40;
                    }
                    if (AudioCalculator.Volume < -80)
                    {
                        AudioCalculator.Volume = -80;
                    }
                }
                if (currentSelected.name == "Pitch")
                {
                    Debug.Log(currentSelected.name);
                    pitch = ValueEditor("Pitch", pitch, 0.01f, currentSelected);
                    if (pitch > 5)
                    {
                        pitch = 5;
                    }
                    if (pitch < 1)
                    {
                        pitch = 1;
                    }
                }
                if (currentSelected.name == "Lowpass")
                {
                    Debug.Log(currentSelected.name);
                    Lowpass = ValueEditor("LowpassFreq", Lowpass, 100, currentSelected);
                    if (Lowpass > 22000)
                    {
                        Lowpass = 22000;
                    }
                    if (Lowpass < 10)
                    {
                        Lowpass = 10;
                    }
                }
                if (currentSelected.name == "Highpass")
                {
                    Debug.Log(currentSelected.name);
                    Lowpass = ValueEditor("HighpassFreq", Highpass, 100, currentSelected);
                    if (Highpass > 22000)
                    {
                        Highpass = 22000;
                    }
                    if (Highpass < 10)
                    {
                        Highpass = 10;
                    }
                }
                if (currentSelected.name == "Reset")
                {

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
            currentSelected.transform.Rotate(0, -1, 0);
            ValueChanged = ValueChanged - Increment;
        }
        if (Input.GetKey("e"))
        {
            currentSelected.transform.Rotate(0, 1, 0);
            ValueChanged = ValueChanged + Increment;
        }
        
        MasterMixer.SetFloat(Value, ValueChanged);
        return ValueChanged;
    }
}
