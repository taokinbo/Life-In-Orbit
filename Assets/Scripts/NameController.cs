using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameController : MonoBehaviour
{
    public Events currentEvent;
    [SerializeField] private GameObject InputGameObject;
    [SerializeField] private GameObject SubmitGameObject;
    [SerializeField] private TMP_InputField inputText;



    // Start is called before the first frame update
    void Start()
    {
        OnEventInfoChnaged(MasterEventSystem.Instance.getCurrentEvent());
        MasterEventSystem.Instance.OnEventInfoChnaged += OnEventInfoChnaged;
    }

    private void OnEventInfoChnaged(Events newEvent) {
        currentEvent = newEvent;

        if (currentEvent == Events.GameStart &&
        MasterEventSystem.Instance.checkFlag(Flags.NameSelection)) {
            InputGameObject.SetActive(true);
            SubmitGameObject.SetActive(true);
        }

    }

    public void OnSubmit(){
        MasterEventSystem.Instance.setPlayerName(inputText.text);
        InputGameObject.SetActive(false);
        SubmitGameObject.SetActive(false);
        // MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.NameSelection);
        MasterEventSystem.Instance.removeFlag(Flags.NameSelection);
        MasterEventSystem.Instance.removeFlag(Flags.NameSelectionStart);
        MasterEventSystem.Instance.addFlag(Flags.NameSelectionFinished);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) && InputGameObject.activeSelf)
        {
            OnSubmit();
        }
        // if (currentEvent == Events.GameStart) {

        // }
    }
}
