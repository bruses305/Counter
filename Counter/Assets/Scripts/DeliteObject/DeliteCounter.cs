using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeliteCounter : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] ControlData controlData;
    bool[] CountersSelect;
    bool FastSelection = false;
    int[] ID;


    public void SelectCounter(BaseEventData eventData,int IDGlobal)
    {
        int IDInMasive = controlData.counterData[IDGlobal].IDInMasive;

        Debug.Log("DeliteCounter:SelectCounter: " + IDInMasive);
        CountersSelect[IDInMasive] = !CountersSelect[IDInMasive];
        parent.transform.GetChild(IDInMasive).GetChild(0).GetChild(1).gameObject.SetActive(CountersSelect[IDInMasive]);

        if (!FastSelection)
        {
            FastSelection = true;
            //Set Fast Selection
        }
        else if(!Array.Find<bool>(CountersSelect, item => item))
        {
            FastSelection = false;
            //Set Fast Select
        }
    }
    public void SelectCounter(int IDGlobal)
    {
        int IDInMasive = controlData.counterData[IDGlobal].IDInMasive;

        Debug.Log("DeliteCounter:SelectCounter: " + IDInMasive);
        CountersSelect[IDInMasive] = !CountersSelect[IDInMasive];
        parent.transform.GetChild(IDInMasive).GetChild(0).GetChild(1).gameObject.SetActive(CountersSelect[IDInMasive]);

        if (!FastSelection)
        {
            FastSelection = true;
            //Set Fast Selection
        }
        else if (!Array.Find<bool>(CountersSelect, item => item))
        {
            FastSelection = false;
            //Set Fast Select
        }
    }

    public void DeliteCounters()
    {
        controlData.DeliteCounter(CountersSelect);
    }

    public void Update_List(int Count)
    {
        CountersSelect = new bool[Count];
        ID = new int[Count];
    }

    public void OnFastSelect()
    {

    }
}
