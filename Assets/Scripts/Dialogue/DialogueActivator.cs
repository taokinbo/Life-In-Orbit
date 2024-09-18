using UnityEngine;

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
    void Awake(){
        diaUI = FindObjectOfType<DialogueUI>();
        setCurrentEvent(MasterEventSystem.Instance.getCurrentEvent());
        MasterEventSystem.Instance.OnEventInfoChnaged += OnEventInfoChnaged;

        // if upcoming dialogue should play upon entering scene, start dialogue
        if (matchingSceneList[curIndex] == currentEvent && OnSceneLoad[curIndex]) {
            playDialogue();
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
        while (curIndex < matchingSceneList.Length && matchingSceneList[curIndex] < newEvent) {
            curIndex++;
        }
        currentEvent = newEvent;
        Debug.Log("current Index: " + curIndex);
    }

    private void playDialogue() {
        diaUI.ShowDialogue(dialogueObjects[curIndex], Character);
    }

    public void Interacted(){
        Debug.Log("button clicked");
        if (matchingSceneList[curIndex] == currentEvent) {
            playDialogue();
        }
    }

    void Update(){
        if (!wait1Frame) wait1Frame = true;
        if (wait1Frame && !hasCalledStart) {
            hasCalledStart = true;
            // StartCoroutine(AudioController.Instance.musicSource.CrossFade(AudioController.Instance.musicSounds[1]));
            // AudioController.Instance.PlayMusic(1);
            diaUI.ShowDialogue(dialogueObjects[0]);
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
