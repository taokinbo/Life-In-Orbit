using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems; // 1


public class DialogueActivator : MonoBehaviour
{
    public bool removeLocationCheck = false; // keep true for easy testing of lumina

    public DialogueUI diaUI;
    [SerializeField] private EventInfoTypes Character;
    [SerializeField] private DialogueObject[] dialogueObjects;
    [SerializeField] private Events[] matchingSceneList;
    [SerializeField] private bool[] OnSceneLoad;
    [SerializeField] private Flags[] flags;

    // STUFF FOR LUMINA
    [SerializeField] private Scenes[] PlayOnlyAtLocation; // Start menu scene will be default none
    [SerializeField] private bool[] dontMarkCharacterDone;
    [SerializeField] private int altDiaBoxUsed;

    [SerializeField] private DialogueObject backupDialogue;

    public int curIndex = 0;
    public Events currentEvent;



    bool wait1Frame = false;
    bool hasCalledStart = false;
    bool playOnSceneDia = false;






    // void Start(){
    void Start(){
        diaUI = FindObjectOfType<DialogueUI>();
        setCurrentEvent(MasterEventSystem.Instance.getCurrentEvent());
        MasterEventSystem.Instance.OnEventInfoChnaged += OnEventInfoChnaged;

        // if upcoming dialogue should play upon entering scene, start dialogue
        if (matchingSceneList[curIndex] == currentEvent && OnSceneLoad[curIndex]) {
            Debug.Log("is upcoming dia");
            playOnSceneDia = true;
            // playDialogue();
        }
        else {
            Debug.Log("NOT MATHCING");
            Debug.Log(matchingSceneList[curIndex] + " " + currentEvent + " " + OnSceneLoad[curIndex]);

        }

        // MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.None);
    }

    void OnDestroy(){
        MasterEventSystem.Instance.OnEventInfoChnaged -= OnEventInfoChnaged;
    }

    private void OnEventInfoChnaged(Events newEvent) {
        Debug.Log("i have reciveved news of new curent info: " + currentEvent + " -> " + newEvent);
        setCurrentEvent(newEvent);
    }

    private void setCurrentEvent(Events newEvent) {
        while (curIndex < matchingSceneList.Length - 1 && matchingSceneList[curIndex] < newEvent) {
            curIndex++;
        }
        currentEvent = newEvent;
        Debug.Log("current Index: " + curIndex);
        if (OnSceneLoad[curIndex]) playDialogue(false);
    }

    private void playDialogue(bool playBackup = true) {
        if (PlayOnlyAtLocation[curIndex] != Scenes.StartMenu) playBackup = false;
        Debug.Log("playing log");
        Debug.Log("diaUI is missing check");
        Debug.Log(diaUI);
        if (!diaUI) {
            Debug.Log("Dia UI didnt exist");
            // diaUI = FindObjectOfType<DialogueUI>();
            // setCurrentEvent(MasterEventSystem.Instance.getCurrentEvent());
        }
        if (diaUI.IsOpen) return;
        if (matchingSceneList[curIndex] == currentEvent && canSpeakNow() && inCorrectLocation()) {
            var tempCurIndex = curIndex;
            Debug.Log("temp cur index is: " + tempCurIndex + "while curentIndex is: " + curIndex);
            while(flags[tempCurIndex] != Flags.None &&  !MasterEventSystem.Instance.checkFlag(flags[tempCurIndex]) ){
                tempCurIndex++;
                if (tempCurIndex >= matchingSceneList.Length || matchingSceneList[tempCurIndex] != currentEvent) {
                    if (playBackup) diaUI.ShowDialogue(backupDialogue, EventInfoTypes.None);
                    return;
                }
            }
            diaUI.ShowDialogue(dialogueObjects[tempCurIndex], dontMarkCharacterDone[tempCurIndex] ? EventInfoTypes.None : Character);
        }
        else {
            if (playBackup) diaUI.ShowDialogue(backupDialogue, EventInfoTypes.None);
        }
    }

    public bool canSpeakNow() {
        var unspokenPeople = MasterEventSystem.Instance.getPeopleForEvent(true);
        bool characterFound = false;
        foreach (var person in unspokenPeople) {
            if (person == Character) characterFound = true;
        }
        return characterFound;
    }

    public bool inCorrectLocation() {
        if (removeLocationCheck) return true;
        if (PlayOnlyAtLocation[curIndex] == Scenes.StartMenu) return true;
        var currentLocation = MasterEventSystem.Instance.getLocation();
        if (PlayOnlyAtLocation[curIndex] == currentLocation) return true;
        if ((currentLocation == Scenes.EngineeringBay || currentLocation == Scenes.Biodome) &&
            (PlayOnlyAtLocation[curIndex] == Scenes.EngineeringBay || PlayOnlyAtLocation[curIndex] == Scenes.Biodome)) return true;
        return false;
    }

    public void Interacted(){
        Debug.Log("button clicked");

        playDialogue();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        ps.haveRiffle = true;
        ps.haveGun = false;
        ps.haveBat = false;
        ps.haveFlamethrower = false;
       // ps.haveKnife = false;
        */
        Debug.Log("Click DETECTED ON RIFFLE IMAGE");

    }

    void Update(){
        if (!wait1Frame) wait1Frame = true;
        if (wait1Frame && !hasCalledStart) {
            if (!diaUI) {
                Debug.Log("Dia UI didnt exist");
                diaUI = FindObjectOfType<DialogueUI>();
            }
            else Debug.Log("dia ui found");
            hasCalledStart = true;
            if (playOnSceneDia) playDialogue();
            playOnSceneDia = false;

            // StartCoroutine(AudioController.Instance.musicSource.CrossFade(AudioController.Instance.musicSounds[1]));
            // AudioController.Instance.PlayMusic(1);
            // diaUI.ShowDialogue(dialogueObjects[0]);
        }


        // if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
        //     Debug.Log("space pressed");
        //     Interact();
        // }
    }
}



/*

 - Each character will have their own dialogue activator. ! script but placed on object for each character
 - Dialogue activators will all connect to the same chat UI, but dia UI can be prefab added to each scene.
 - activators are what determine if chat starts walk upon room or upon item click -> will use MasterEventSystem for that
 - activators will have a feedable dictionary pairing eventScenes with dialogObjects


 */
