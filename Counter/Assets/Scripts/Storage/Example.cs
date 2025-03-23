using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private Storage storage;
    private GameData gameData;
    private object Data;
    private void Awake()
    {
        storage = new Storage();
        Load();
    }
    public void Save(object gameData)
    {
        storage.Save(gameData);
        //Debug.Log("Data Saved !");
    }

    public object Load()
    {
        gameData = (GameData)storage.Load(new GameData());
        //Debug.Log("Data Loading");
        return gameData;
    }
}
