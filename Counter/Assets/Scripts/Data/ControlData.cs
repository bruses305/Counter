using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlData : MonoBehaviour
{
    [SerializeField]private ControlButton controlButton;
    [SerializeField]private GameObject Counter;
    [SerializeField]private GameObject Group, Settings;

    public GameData gameData = new();
    public Example example;
    public List<CounterData> counterData;


    [SerializeField] private Vector2 anchoreMin_1;
    private Vector2 anchoreMax_1;
    [SerializeField] private Vector2 anchoreDiff;

    [SerializeField] private Vector2 anchoreMin_2;
    private Vector2 anchoreMax_2;

    [SerializeField] private Vector2 change;


    [SerializeField] private Vector2 anchoreMin_3;
    [SerializeField] private Vector2 anchoreMax_3;

    [SerializeField] private float changeGroup;



    private GameObject Counter_Now;
    private GameObject Group_Now;
    private RectTransform rectTransform;
    private RectTransform rectTransformGroup;
    private GameObject parent;
    bool isGroup = false;
    [SerializeField]private GameObject parentGroup;

    #region Class

    [SerializeField] private DeliteCounter deliteCounter;

    #endregion

    private void Update()
    {
        //gameData.counterData.ForEach(item => Debug.Log(item.IDInMasive));
    }

    private void Start()
    {
        anchoreMax_1 = Diff(anchoreMin_1,anchoreDiff);
        anchoreMax_2 = Diff(anchoreMin_2,anchoreDiff);

        parent = gameObject.transform.GetChild(0).gameObject;

        gameData = (GameData)example.Load();
        counterData = gameData.counterData;

        LoadingCounter();
        LoadingAllGroup();
    }


    public void LoadingCounter(string groupName)
    {
        DestroyChildObject(parent);

        gameData = (GameData)example.Load();
        counterData = gameData.counterData;

        int countObj = counterData.Count;
        int idInMasive = 0;
        for (int idGlobal = 0; idGlobal < countObj; idGlobal++)
        {
            if (counterData[idGlobal].GroupName == groupName)
            {
                Counter_Now = Instantiate(Counter, Vector3.zero, Quaternion.identity);
                Counter_Now.transform.SetParent(parent.transform);

                counterData[idGlobal].IDInMasive = idInMasive;

                SettingsButtonToCounter(Counter_Now, idGlobal);

                Counter_Now.transform.GetChild(2).gameObject.GetComponent<Text>().text = gameData.counterData[idGlobal].Value.ToString();
                Counter_Now.transform.GetChild(3).gameObject.GetComponent<Text>().text = gameData.counterData[idGlobal].Name;

                rectTransform = Counter_Now.GetComponent<RectTransform>();
                if (idInMasive % 2 == 0)
                {
                    int y = (idInMasive / 2);
                    rectTransform.anchorMin = new Vector2(anchoreMin_1.x, anchoreMin_1.y - change.x * y);
                    rectTransform.anchorMax = new Vector2(anchoreMax_1.x, anchoreMax_1.y - change.y * y);
                }
                else
                {
                    int y = ((idInMasive - 1) / 2);
                    rectTransform.anchorMin = new Vector2(anchoreMin_2.x, anchoreMin_2.y - change.x * y);
                    rectTransform.anchorMax = new Vector2(anchoreMax_2.x, anchoreMax_2.y - change.y * y);
                }

                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.anchoredPosition3D = Vector3.zero;

                Counter_Now.transform.localScale = new Vector3(1, 1, 1);

                idInMasive++;

                //Debug.Log("ControlData:LoadingCounter(groupName)");
            }
            else
            {
                counterData[idGlobal].IDInMasive = -1;
            }
        }
        deliteCounter.Update_List(idInMasive);
        gameData.counterData = counterData;
        SaveGameData();
        isGroup = true;
    }
    public void LoadingCounter()
    {
        DestroyChildObject(parent);

        gameData = (GameData)example.Load();
        counterData = gameData.counterData;

        int countObj = counterData.Count;
        for (int idGlobal = 0; idGlobal < countObj; idGlobal++)
        {
            Counter_Now = Instantiate(Counter);
            Counter_Now.transform.SetParent(parent.transform);

            gameData.counterData[idGlobal].IDInMasive = idGlobal;
            //Debug.Log(gameData.counterData[idGlobal].IDInMasive);

            SettingsButtonToCounter(Counter_Now,idGlobal);

            Counter_Now.transform.GetChild(2).gameObject.GetComponent<Text>().text = gameData.counterData[idGlobal].Value.ToString();
            Counter_Now.transform.GetChild(3).gameObject.GetComponent<Text>().text = gameData.counterData[idGlobal].Name;

            rectTransform = Counter_Now.GetComponent<RectTransform>();
            if (idGlobal % 2 == 0)
            {
                int y = idGlobal / 2;
                rectTransform.anchorMin = new Vector2(anchoreMin_1.x, anchoreMin_1.y - change.x * y);
                rectTransform.anchorMax = new Vector2(anchoreMax_1.x, anchoreMax_1.y - change.y * y);
            }
            else
            {
                int y = (idGlobal - 1) / 2;
                rectTransform.anchorMin = new Vector2(anchoreMin_2.x, anchoreMin_2.y - change.x * y);
                rectTransform.anchorMax = new Vector2(anchoreMax_2.x, anchoreMax_2.y - change.y * y);
            }

            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.anchoredPosition3D = Vector3.zero;

            Counter_Now.transform.localScale = new Vector3(1, 1, 1);

            //Debug.Log("ControlData:LoadingCounter");
        }
        deliteCounter.Update_List(countObj);
        gameData.counterData = counterData;
        SaveGameData();
        isGroup = false;
    }

    public void UpdateCouter(int idGlobal)
    {
        parent.transform.GetChild(gameData.counterData[idGlobal].IDInMasive).GetChild(2).GetComponent<Text>().text = gameData.counterData[idGlobal].Value.ToString();
        SaveGameData();
        //Debug.Log("ControlData:UpdateCounter " + idGlobal + " " + gameData.counterData[idGlobal].IDInMasive + " " + parent.transform.GetChild(gameData.counterData[idGlobal].IDInMasive).GetChild(2).GetComponent<Text>().text);
    }
    public void UpdateCouterName(int idGlobal)
    {
        Counter_Now.transform.GetChild(2).gameObject.GetComponent<Text>().text = gameData.counterData[idGlobal].Value.ToString();
        Counter_Now.transform.GetChild(3).gameObject.GetComponent<Text>().text = gameData.counterData[idGlobal].Name;
        SaveGameData();
        //Debug.Log("ControlData:UpdateCounter " + idGlobal + " " + gameData.counterData[idGlobal].IDInMasive + " " + parent.transform.GetChild(gameData.counterData[idGlobal].IDInMasive).GetChild(2).GetComponent<Text>().text);
    }


    public void LoadingAllGroup()
    {
        DestroyChildObject(parentGroup);

        try
        {
            gameData = (GameData)example.Load();
        }
        catch
        {
            return;
        }

        int GroupCount = gameData.groupName.Count;

        for (int i = 0; i < GroupCount; i++)
        {

            Group_Now = Instantiate(Group);
            Group_Now.transform.SetParent(parentGroup.transform);


            string u = gameData.groupName[i];
            if (u == "All Counter")
            { Group_Now.GetComponent<Button>().onClick.AddListener(delegate { LoadingCounter(); });
            }
            else{ Group_Now.GetComponent<Button>().onClick.AddListener(delegate { LoadingCounter(u); });
            }
            Group_Now.GetComponent<Button>().onClick.AddListener(controlButton.OpenMenu);

            Group_Now.transform.GetChild(1).gameObject.GetComponent<Text>().text = gameData.groupName[i];

            rectTransformGroup = Group_Now.GetComponent<RectTransform>();

            rectTransformGroup.anchorMin = new Vector2(anchoreMin_3.x, anchoreMin_3.y - changeGroup * i);
            rectTransformGroup.anchorMax = new Vector2(anchoreMax_3.x, anchoreMax_3.y - changeGroup * i);

            rectTransformGroup.anchoredPosition = Vector2.zero;

            Group_Now.transform.localScale = new Vector3(1, 1, 1);
        }

        //Debug.Log("ControlData:LoadingAllGroup");
    }

    public void CreateCounter(GameObject StartDataCounter)
    {
        bool IsGroop = false;
        string groupName = StartDataCounter.transform.GetChild(0).gameObject.GetComponent<InputField>().text;
        string name = StartDataCounter.transform.GetChild(1).gameObject.GetComponent<InputField>().text;

        CounterData newCounter = new CounterData();
        if (name != "") newCounter.Name = name;

        GroupExists(groupName);

        if (groupName != "")
        {
            newCounter.GroupName = groupName;
            IsGroop = true;
        }

        newCounter.ID = gameData.counterData.Count;

        gameData.counterData.Add(newCounter);
        SaveGameData();
        if (IsGroop)  LoadingCounter(groupName);
        else LoadingCounter();

        //Debug.Log("ControlData:CreateCounter");

    }
    public void CreateCounter(GameObject StartDataCounter,int IdObj)
    {
        bool IsGroop = false;
        string groupName = StartDataCounter.transform.GetChild(0+IdObj).gameObject.GetComponent<InputField>().text;
        string name = StartDataCounter.transform.GetChild(1+IdObj).gameObject.GetComponent<InputField>().text;

        CounterData newCounter = new CounterData();
        if (name != "") newCounter.Name = name;

        GroupExists(groupName);

        if (groupName != "")
        {
            newCounter.GroupName = groupName;
            IsGroop = true;
        }

        newCounter.ID = gameData.counterData.Count;

        gameData.counterData.Add(newCounter);
        SaveGameData();
        if (IsGroop) LoadingCounter(groupName);
        else LoadingCounter();

        //Debug.Log("ControlData:CreateCounter");

    }

    public void DeliteCounter(int ID)
    {
        string grouNameToID = gameData.counterData[ID].GroupName;

        gameData.counterData.RemoveAt(ID);

        ResetIDCounter();

        SaveGameData();

        if (!isGroup) LoadingCounter();
        else LoadingCounter(grouNameToID);

        GropRemove(grouNameToID);

        //Debug.Log("ControlData:DeliteCounter");
    }
    public void DeliteCounter(bool[] CounterSelect)
    {

        if (isGroup)
        {
            string groupname = "";
            for (int ID = 0; ID < gameData.counterData.Count; ID++)
            {
                if (gameData.counterData[ID].IDInMasive >= 0)
                {
                    if (CounterSelect[gameData.counterData[ID].IDInMasive])
                    {
                        gameData.counterData.RemoveAt(ID);

                        groupname = gameData.counterData[ID].GroupName;
                    }
                }
            }

            ResetIDCounter();

            SaveGameData();

            LoadingCounter(groupname);

        }
        else
        {
            for (int ID= 0; ID < CounterSelect.Length; ID++)
            {
                if (CounterSelect[ID])
                {
                    gameData.counterData.RemoveAt(ID);
                }
            }
            ResetIDCounter();

            SaveGameData();

            LoadingCounter();
        }
    }

    public void SaveGameData()
    {
        example.Save(gameData);
    }


    #region Metods

    private Vector3 Diff(Vector3 now, Vector3 diff)
    {
        return new Vector3(now.x + diff.x, now.y + diff.y, now.z + diff.z);
    }

    private void count(BaseEventData eventData)
    {
        Debug.Log("Select");
    }
    private void SettingsButtonToCounter(GameObject gameObject, int idGlobal)
    {
        Transform ButtonParent = gameObject.transform.GetChild(5);

        gameObject.transform.GetChild(6).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { deliteCounter.SelectCounter(idGlobal); });

        #region EventTrigerAdd
        EventTrigger eventTrigger = gameObject.transform.GetChild(4).GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        {
            entry.eventID = EventTriggerType.Select;
        }
        entry.callback.AddListener(data => deliteCounter.SelectCounter(data, idGlobal));
        eventTrigger.triggers.Add(entry);
        #endregion

        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate { controlButton.OpenCounter(idGlobal); });


        ButtonParent.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { controlButton.PlusCounter(idGlobal); });
        ButtonParent.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { controlButton.MinusCounter(idGlobal); });

        //Debug.Log("ControlData:SettingsButtonToCounter");

    }

    private void DestroyChildObject(GameObject parent)
    {
        for (int j = parent.transform.childCount - 1; j >= 0; j--)
        {
            Destroy(parent.transform.GetChild(j).gameObject);
        }

        //Debug.Log("ControlData:DestroyChildObject");

    }

    public bool GroupExists(string groupName)
    {
        //Debug.Log("ControlData:GroupExists");

        if (groupName != "" && !gameData.groupName.Contains(groupName))
        {
            gameData.groupName.Add(groupName);
            SaveGameData();
            LoadingAllGroup();
            return false;
        }
        return true;
    }

    public bool GropRemove(string groupNameToID)
    {
        //Debug.Log("ControlData:GroupRemove");

        if (groupNameToID != "All Counter")
        {
            foreach (CounterData counter in gameData.counterData)
            {
                if (counter.GroupName == groupNameToID)
                {
                    return false;
                }
            }

            Debug.Log(groupNameToID + " Remove");
            gameData.groupName.Remove(groupNameToID);
            gameData.groupName.ForEach(Debug.Log);

            SaveGameData();

            LoadingCounter();
            LoadingAllGroup();
            return true;

        }
        return false;
    }

    private void ResetIDCounter()
    {
        //Debug.Log("ControlData:ResetIDCounter");

        int _count = gameData.counterData.Count;
        for (int idGlobal = 0; idGlobal < _count; idGlobal++) { gameData.counterData[idGlobal].ID = idGlobal; }
    }

    #endregion

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

}
