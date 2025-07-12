using System;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] InputField Name, Meaning, MeaningForReset, Group, Volume, Delay;

    [SerializeField] ControlData controlData;
    [SerializeField] ControlButton controlButton;

    private CounterData counter;

    public void SaveSettings()
    {
        UpdateCounter();
        counter.Name = Name.text;
        try
        {
            counter.Value = Convert.ToInt32(Meaning.text);
            counter.ValueReset = Convert.ToInt32(MeaningForReset.text);
        }
        catch
        {
            Debug.LogError("Count Or CountReset: Failed Convert To Int32");
            counter.Value = 0;
            counter.ValueReset = 0;
        }

        try
        {
            counter._volume = (float)Convert.ToDouble(Volume.text);
            counter._delay = (float)Convert.ToDouble(Delay.text);
        }
        catch { Debug.LogError("Volume Or Delay: Failed Convert To Float"); }


        string old_group = counter.GroupName;

        if (Group.text == "")
        {
            counter.GroupName = "All Counter";
        }
        else
        {
            counter.GroupName = Group.text;
        }
        controlData.GroupExists(Group.text);

        //Debug.Log(old_group);
        controlData.GropRemove(old_group);


        controlData.SaveGameData();
        controlButton.UpdateGlobalID();
        controlButton.UpdateCount();
        controlData.UpdateCouterName(controlButton.ID_Total_Global);
        controlButton.Edit();

        //Debug.Log("Setting:SaveSettings");
    }

    public void LoadSettings()
    {
        UpdateCounter();
        Name.text = counter.Name;
        Group.text = counter.GroupName;
        Meaning.text = counter.Value.ToString();
        MeaningForReset.text = counter.ValueReset.ToString();
        Volume.text = counter._volume.ToString();
        Delay.text = counter._delay.ToString();

        //Debug.Log("Setting:LoadSettings");
    }

    private void UpdateCounter()
    {
        counter = controlData.gameData.counterData[controlButton.ID_Total_Global];

        //Debug.Log("Setting:UpdateCounter");
    }
}
