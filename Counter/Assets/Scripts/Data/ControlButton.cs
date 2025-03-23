using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private ControlData controlData;
    [SerializeField] private Setting setting;
    [SerializeField] private CounterOnMicrophone Microphone;
    [SerializeField] private GameObject Counter;
    [SerializeField] private Text CounterFullScreen;
    private Animator counterAnimator;
    [SerializeField] private Animator editAnimator;
    [SerializeField] private Animator menuAnimator;

    public int ID_Total_Global = 0;

    private Text CounterName;
    private Text CounterGroupName;
    private Text CounterMending;


    #region Menu_Button

    private void Start()
    {
        counterAnimator = controlData.transform.parent.GetChild(3).gameObject.GetComponent<Animator>();
        CounterMending = Counter.transform.GetChild(0).GetComponent<Text>();
        CounterName = Counter.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        CounterGroupName = Counter.transform.GetChild(1).GetChild(1).GetComponent<Text>();
    }
    public void PlusCounter(int idGlobal)
    {
        controlData.gameData.counterData[idGlobal]._count++;
        controlData.UpdateCouter(idGlobal);

        //Debug.Log("ControlButton:PlusCounter");
    }
    public void MinusCounter(int idGlobal)
    {
        controlData.gameData.counterData[idGlobal]._count--;
        controlData.UpdateCouter(idGlobal);

        //Debug.Log("ControlButton:MinusCounter");
    }
    public void OpenCounter(int idGlobal)
    {
        UpdateGlobalID(idGlobal);
        SetAnimation(counterAnimator);
        UpdateCount();
        Microphone.UpdateCounterID(idGlobal);

        //Debug.Log("ControlButton:OpenCounter");
    }


    public void CreateFormActive(GameObject Form)
    {
        Form.SetActive(!Form.activeInHierarchy);

        //Debug.Log("ControlButton:CreateFormActive");
    }
    public void CreateCounter(GameObject Form)
    {
        controlData.CreateCounter(Form, 1);
        Form.SetActive(false);

        //Debug.Log("ControlButton:CreateCounter");
    }
    public void OpenMenu()
    {
        SetAnimation(menuAnimator);

        //Debug.Log("ControlButton:OpenMenu");
    }

    #endregion


    #region Counter_Button

    public void Quit()
    {
        SetAnimation(counterAnimator);
        Microphone.UpdateCounterID(-1);
        controlData.SaveGameData();
        controlData.UpdateCouter(ID_Total_Global);

        //Debug.Log("ControlButton:Quit");
    }
    public void ActivateMicrophone()
    {
        if (Microphone.microphoneState == MicrophoneState.Active) Microphone.microphoneState = MicrophoneState.NoActive;
        else Microphone.microphoneState = MicrophoneState.Active;

        //Debug.Log("ControlButton:ActivateMicrophone");
    }
    public void FullScreen(Animator fullScreenAnimator)
    {
        SetAnimation(fullScreenAnimator);

        //Debug.Log("ControlButton:FullScreen");
    }
    public void Edit()
    {
        setting.LoadSettings();
        SetAnimation(editAnimator);

        //Debug.Log("ControlButton:Edit");
    }
    public void Etc(Animator etcAnimator)
    {
        SetAnimation(etcAnimator);

        //Debug.Log("ControlButton:Etc");
    }


    public void PlusCount()
    {
        controlData.gameData.counterData[ID_Total_Global]._count++;
        UpdateCount();

        //Debug.Log("ControlButton:PlusCount");
    }
    public void MinusCount()
    {
        controlData.gameData.counterData[ID_Total_Global]._count--;
        UpdateCount();

        //Debug.Log("ControlButton:Minus");
    }
    public void Reset_Count()
    {
        controlData.gameData.counterData[ID_Total_Global]._count = 0;
        UpdateCount();

        //Debug.Log("ControlButton:Reset_Count");
    }

    #endregion

    #region Methods

    private void SetAnimation(Animator animator)
    {
        animator.SetBool("isOpen",!animator.GetBool("isOpen"));
    }

    public void UpdateCount()
    {
        CounterMending.text = controlData.gameData.counterData[ID_Total_Global]._count.ToString();
        CounterFullScreen.text = controlData.gameData.counterData[ID_Total_Global]._count.ToString();
        controlData.SaveGameData();
        //Debug.Log("ControlButton:UpdateCount");
    }

    private void UpdateGlobalID(int idGlobal)
    {
        ID_Total_Global = idGlobal;
        CounterName.text = controlData.gameData.counterData[idGlobal]._name;
        CounterGroupName.text = controlData.gameData.counterData[idGlobal]._groupName;
        //Debug.Log("ControlButton:UpdateGlobalID");
    }
    public void UpdateGlobalID()
    {
        CounterName.text = controlData.gameData.counterData[ID_Total_Global]._name;
        CounterGroupName.text = controlData.gameData.counterData[ID_Total_Global]._groupName;

        //Debug.Log("ControlButton:UpdateGlobalID");
    }

    public void DeliteCounter()
    {
        controlData.DeliteCounter(ID_Total_Global);

        SetAnimation(counterAnimator);
        SetAnimation(editAnimator);

        //Debug.Log("ControlButton:DeliteCounter");

    }

    #endregion
}
