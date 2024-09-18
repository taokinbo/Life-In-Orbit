using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    // [SerializeField] private DialogueObject dialogueObject;
    // private DialogueUI OpalDia;
    // private DialogueUI AsterDia;
    // private DialogueUI AmosDia;
    // private DialogueUI MikaDia;
    private DialogueUI diaUI;
    [SerializeField] private DialogueObject[] dialogueObjects;
    [SerializeField] private int matchingSceneList;


    bool wait1Frame = false;
    bool hasCalledStart = false;


    void Start(){
        diaUI = FindObjectOfType<DialogueUI>();

        // if (dialogueObject != null) Interact();

        // Debug.Log(GameManager.Instance.dateChosen);
    }

    // public void Interact(int dia){
    //     Debug.Log("shown");
    //     diaUI.ShowDialogue(dialogueObject);
    // }

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
