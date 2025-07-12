using System.Collections.Generic;

public class CounterData
{
    #region Microphone_Settings

    public float _volume;
    public float _intensity;
    public float _delay;

    #endregion Microphone_Settings

    #region Global_Name

    public string Name;
    public string GroupName;
    public int ID;
    public int IDInMasive;

    #endregion

    #region Data

    public float Value;
    public List<int> st;

    #endregion

    #region Settings

    public float ValueReset;

    #endregion

    public CounterData()
    {
        _volume = 15;
        _intensity = 100;
        _delay = 1.6f;
        ID = 0;
        IDInMasive = 0;
        Value = 0;

        Name = "Counter";
        GroupName = "All Counter";

        st = new List<int>();
    }
}

