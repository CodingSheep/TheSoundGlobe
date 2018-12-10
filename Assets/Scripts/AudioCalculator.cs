using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioCalculator : MonoBehaviour {
    AudioSource audioSource;

    public static float[] samplesLeft = new float[512];
    public static float[] samplesRight = new float[512];
    float[] freqBands = new float[8];
    float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];

    float[] freqBandHighest = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];

    public static float amplitude, amplitudeBuffer;
    float amplitudeHighest;

    public float audioProfile;
    public static float Volume;
    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
        AudioProfile(audioProfile);
        Volume = 0;
    }

    // Update is called once per frame
    void Update() {
        //Volume
        audioSource.volume = (Volume+80)/120;
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    //Set Minimum Frequency Band Value to avoid thousands of values << 1 from
    //  constantly changing the highest value at the beginning of a song.
    void AudioProfile(float audioProfile) {
        for (int i = 0; i < 8; i++) {
            freqBandHighest[i] = audioProfile;
        }
    }

    //Create our audio bands based on frequency of audio waves
    void CreateAudioBands() {
        for (int i = 0; i < 8; i++) {
            if (freqBands[i] > freqBandHighest[i]) {
                freqBandHighest[i] = freqBands[i];
            }
            audioBand[i] = (freqBands[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    //Calculate the current amplitude of a song based on our audio bands
    void GetAmplitude() {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;

        for (int i = 0; i < 8; i++) {
            currentAmplitude += audioBand[i];
            currentAmplitudeBuffer += audioBandBuffer[i];
        }

        if (currentAmplitude > amplitudeHighest) {
            amplitudeHighest = currentAmplitude;
        }
        amplitude = currentAmplitude / amplitudeHighest;
        amplitudeBuffer = currentAmplitudeBuffer / amplitudeHighest;
    }

    void GetSpectrumAudioSource() {
        audioSource.GetSpectrumData(samplesLeft, 0, FFTWindow.Blackman);
        audioSource.GetSpectrumData(samplesRight, 1, FFTWindow.Blackman);
    }

    void MakeFrequencyBands() {
        int count = 0;

        for (int i = 0; i < 8; i++) {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7) {
                sampleCount += 2;
            }

            float average = 0;
            for (int j = 0; j < sampleCount; j++) {
                average += (samplesLeft[count] + samplesRight[count]) * (count + 1);
                count++;
            }

            average /= count;

            freqBands[i] = average * 10;
        }
    }

    void BandBuffer() {
        for (int g = 0; g < 8; g++) {
            if (freqBands[g] > bandBuffer[g]) {
                bandBuffer[g] = freqBands[g];
                bufferDecrease[g] = 0.005f;
            }

            if (freqBands[g] < bandBuffer[g]) {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.4f;
            }
        }
    }
}
