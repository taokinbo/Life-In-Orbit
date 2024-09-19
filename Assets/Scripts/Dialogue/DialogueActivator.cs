using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems; // 1


public class DialogueActivator : MonoBehaviour
{
    // [SerializeField] private DialogueObject dialogueObject;
    // private DialogueUI OpalDia;
    // private DialogueUI AsterDia;
    // private DialogueUI AmosDia;
    // private DialogueUI MikaDia;
    private DialogueUI diaUI;
    [SerializeField] private EventInfoTypes Character;
    [SerializeField] private DialogueObject[] dialogueObjects;
    [SerializeField] private Events[] matchingSceneList;
    [SerializeField] private bool[] OnSceneLoad;
    [SerializeField] private DialogueObject backupDialogue;

    private int curIndex = 0;
    private Events currentEvent;



    bool wait1Frame = false;
    bool hasCalledStart = false;




    // void Start(){
    void Start(){
        diaUI = FindObjectOfType<DialogueUI>();
        setCurrentEvent(MasterEventSystem.Instance.getCurrentEvent());
        MasterEventSystem.Instance.OnEventInfoChnaged += OnEventInfoChnaged;

        // if upcoming dialogue should play upon entering scene, start dialogue
        if (matchingSceneList[curIndex] == currentEvent && OnSceneLoad[curIndex]) {
            Debug.Log("is upcoming dia");
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
    }

    private void playDialogue() {
        Debug.Log("playing log");
        if (diaUI.IsOpen) return;
        if (matchingSceneList[curIndex] == currentEvent && canSpeakNow()) {
            diaUI.ShowDialogue(dialogueObjects[curIndex], Character);
        }
        else {
            diaUI.ShowDialogue(backupDialogue, EventInfoTypes.None);
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
            hasCalledStart = true;
            playDialogue();

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
