using UnityEngine;
using UnityEngine.UI;

public class CounterOnMicrophone : MonoBehaviour
{
    public ControlData controlData;
    private CounterData Data;

    public int CounterID = -1;

    [SerializeField] private Text Counter;

    [SerializeField] private AudioLoudnessDetect detector;

    [SerializeField,Range(min:0,max:50)] private float speshialvolumeMicrophone;
    [SerializeField,Range(min:0.1f,max:10f)] private float speshial_timer = 0;

    [SerializeField] private float volumeMicrophone;
    [SerializeField] private float _timer = 0;

    public MicrophoneState microphoneState = MicrophoneState.NoActive;
    [SerializeField] private Sprite[] microphoneVolumeImage;
    [SerializeField] private Image microphoneImage;
    [SerializeField] private Image microphoneImageFullScreen;

    public void Update()
    {
        if (CounterID >= 0 && microphoneState == MicrophoneState.Active)
        {
            volumeMicrophone = Mathf.Abs(detector.GetLoudnessFromMicrophone() * Data._intensity);

            SetImageMicrophone();

            if (volumeMicrophone >= Data._volume && Data._delay <= _timer)
            {
                Data._count++;
                Counter.text = Data._count.ToString();
                _timer = 0f;
                //Debug.Log("CounterOnMicrophone:UpdateDetected");
            }
#if UNITY_EDITOR
            else if (volumeMicrophone >= speshialvolumeMicrophone && speshial_timer <= _timer) // time filecode
            {
                Data._count++;
                Counter.text = Data._count.ToString();
                _timer = 0f;
                //Debug.Log("CounterOnMicrophone:UpdateDetected");
            }
#endif

            _timer += Time.deltaTime;
        }
        else if (CounterID >= 0 && microphoneState == MicrophoneState.NoActive)
        {
            microphoneImage.sprite = microphoneVolumeImage[4];
            microphoneImageFullScreen.sprite = microphoneVolumeImage[4];
        }
    }

    public void UpdateCounterID(int newCounterID)
    {
        //Debug.Log("CounterOnMicrophone:UpdateCounterID");
        CounterID = newCounterID;
        if (newCounterID >= 0) Data = controlData.gameData.counterData[CounterID];
    }

    private void SetImageMicrophone()
    {
        Sprite sprite;
        if (volumeMicrophone <= 0.1) sprite = microphoneVolumeImage[0];
        else if (volumeMicrophone < Data._volume - 5) sprite = microphoneVolumeImage[1];
        else if (volumeMicrophone < Data._volume + 5) sprite = microphoneVolumeImage[2];
        else sprite = microphoneVolumeImage[3];

        microphoneImage.sprite = sprite;
        microphoneImageFullScreen.sprite = sprite;
    }
}

