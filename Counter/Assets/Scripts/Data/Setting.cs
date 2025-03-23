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
        counter._name = Name.text;
        try
        {
            counter._count = Convert.ToInt32(Meaning.text);
            counter._countReset = Convert.ToInt32(MeaningForReset.text);
        }
        catch
        {
            Debug.LogError("Count Or CountReset: Failed Convert To Int32");
            counter._count = 0;
            counter._countReset = 0;
        }

        try
        {
            counter._volume = (float)Convert.ToDouble(Volume.text);
            counter._delay = (float)Convert.ToDouble(Delay.text);
        }
        catch { Debug.LogError("Volume Or Delay: Failed Convert To Float"); }


        string old_group = counter._groupName;

        if (Group.text == "")
        {
            counter._groupName = "All Counter";
        }
        else
        {
            counter._groupName = Group.text;
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
        Name.text = counter._name;
        Group.text = counter._groupName;
        Meaning.text = counter._count.ToString();
        MeaningForReset.text = counter._countReset.ToString();
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
