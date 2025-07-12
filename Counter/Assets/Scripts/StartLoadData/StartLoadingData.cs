using System;
using UnityEngine;
using UnityEngine.UI;

public class StartLoadingData : MonoBehaviour
{
    private void Awake()
    {
        VersionControl(GameObject.FindGameObjectWithTag("version").GetComponent<Text>());
    }

    private void VersionControl(Text version)
    {
        version.text ="Version: "  + Application.version;

        if (!PlayerPrefs.HasKey("oldVersion"))
        {
            PlayerPrefs.SetString("oldVersion", Application.version);
        }
        if (!PlayerPrefs.HasKey("vesion") || PlayerPrefs.GetString("vesion") != Application.version)
        {
            PlayerPrefs.SetString("vesion", Application.version);
            /*���*/
        }
    }
}
