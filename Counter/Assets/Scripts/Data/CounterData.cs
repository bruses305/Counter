using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterData
{
    #region Microphone_Settings

    public float _volume;
    public float _intensity;
    public float _delay;

    #endregion Microphone_Settings

    #region Global_Name

    public string _name;
    public string _groupName;
    public int ID;
    public int IDInMasive;

    #endregion

    #region Data

    public float _count;
    public List<int> st;

    #endregion

    #region Settings

    public float _countReset;

    #endregion

    public CounterData()
    {
        _volume = 15;
        _intensity = 100;
        _delay = 1.6f;
        ID = 0;
        IDInMasive = 0;
        _count = 0;

        _name = "Counter";
        _groupName = "All Counter";

        st = new List<int>();
    }
}

