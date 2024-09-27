using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGameManager : MonoBehaviour
{
    public GameObject lockScreen;
    public UIController uiController;
    public bool gameShouldClose = false;
    [SerializeField] private DialogueUI _diaUI;
    public DialogueUI diaUI
    {
        get
        {
            if (_diaUI == null)
            {
                _diaUI = FindObjectOfType<DialogueUI>();
            }
            return _diaUI;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!MasterEventSystem.Instance.getIfMinigameUnlocked()) {
            lockScreen.SetActive(true);
            gameShouldClose = true;
        }
        else {
            lockScreen.SetActive(false);
            gameShouldClose = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameShouldClose) {
            if (!diaUI.IsOpen) {
                uiController.ChangeSceneToHallway();
            }
        }
    }

    public void leaveGame() {
        uiController.ChangeSceneToHallway();
    }
}
