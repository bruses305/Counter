using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public List<CounterData> counterData;
    public List<string> groupName;

    public GameData()
    {
        counterData = new List<CounterData>();
        groupName = new List<string>() {"All Counter"};
    }
}
