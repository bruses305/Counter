using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetect : MonoBehaviour
{
    private int sampleWindow = 64;
    public AudioClip microphoneAudioClip;

    private void Start()
    {
        StartMicrophoneToRecorder();
    }

    private void StartMicrophoneToRecorder()
    {
        string microphoneName = Microphone.devices[0];

        microphoneAudioClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone() {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneAudioClip);
            }
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip) {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for(int i = 0;i<sampleWindow ;i++)
        {
            totalLoudness += waveData[i];
        }

        return totalLoudness / sampleWindow;
    }
}
