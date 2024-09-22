using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;


public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject nameBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text[] options;
    [SerializeField] private TMP_Text[] carots;

    [SerializeField] private GameObject chatSpriteGO;
    [SerializeField] private Animator chatSprite;
    [SerializeField] private Image spriteImage;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private Animator backgroundSprite;

    private string curSprite = "None";
    private string curBackground = "None";

    private string arrowStr = "> ";

    public int curChoice = 0;

    private Color textColor = new Color(0.3962264f, 0f, 00.2545335f, 1.0f);

    private TypewriterEffect TypewriterEffect;

    public bool IsOpen {get; private set;}
    public bool isChoice = false;
    public bool IsNameOpen {get; private set;}
    public int points {get; private set;}

    public bool itemClicked = false;
    public int curQuest = 0; //some way to track conversation ig
    private int historyQuest;
    public bool debug = false;
    // private bool atEnding = false;
    private string playerName = "";
    private int curentChoiceAmount = 3;




    private void Start(){
        historyQuest = curQuest;
        StyleSelect(-1);

        IsNameOpen = false;
        points = 0;

        TypewriterEffect = GetComponent<TypewriterEffect>();
        // Debug.Log("is gonna close from start");

        CloseDialogueBox();

        // Debug.Log("is start being run again")

    }


    void Update() {
        if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && IsOpen && isChoice){
            if (Input.GetKeyDown(KeyCode.DownArrow)) curChoice++;
            else curChoice--;

            if (curChoice < 0) curChoice = curentChoiceAmount - 1;
            curChoice = curChoice % curentChoiceAmount;

            StyleSelect(curChoice);
        }
    }

    public void StyleSelect(int index, bool affectUnseen = true){
        int numOfOptions = affectUnseen ? options.Length : curentChoiceAmount;
        for (int i = 0; i < numOfOptions; i++){
            options[i].color = (i == index) ? textColor : Color.grey;
        }
        for (int i = 0; i < numOfOptions; i++){
            carots[i].text = (i == index) ? arrowStr : "";
        }
    }

    public void ShowDialogue(DialogueObject dialogueObject, EventInfoTypes eventToClear){
        playerName = MasterEventSystem.Instance.getPlayerName();
        // Debug.Log("is running show Dialogue");
        historyQuest = curQuest;

        if (dialogueBox.activeSelf) return;

        // Debug.Log("gets past the activeSelf");

        IsOpen = true;
        dialogueBox.SetActive(true);
        chatSpriteGO.SetActive(true);
        // curChoice = 0;
        points = 0;
        StartCoroutine(StepThroughDialogue(dialogueObject, eventToClear));
    }

    private void SetSprite(string spriteName){

        string[] splitArray =  curSprite.Split(char.Parse("_"));
        string curName = splitArray[0];
        string curEmotion = splitArray.Length == 2 ? splitArray[1] : "";

        // Debug.Log(curName + " " + curEmotion);

        string[] splitArrayNew =  spriteName.Split(char.Parse("_"));
        string newName = splitArrayNew[0];
        string newEmotion = splitArrayNew.Length == 2 ? splitArrayNew[1] : "";

        // Debug.Log(newName + " " + newEmotion);

        if (curSprite != "None"){
            chatSprite.SetBool(curName, false);
            if (curEmotion != "Neutral") chatSprite.SetBool(curEmotion, false);
        }
        if (spriteName != "None"){
            chatSprite.SetBool(newName, true);
            if (newEmotion != "Neutral") chatSprite.SetBool(newEmotion, true);
        }

        curSprite = spriteName;

    }

    private void SetBackground(string spriteName){

        string[] splitArray =  curBackground.Split(char.Parse("_"));
        string curName = splitArray[0];
        string curBlur = splitArray.Length == 2 ? splitArray[1] : "";

        string[] splitArrayNew =  spriteName.Split(char.Parse("_"));
        string newName = splitArrayNew[0];
        string newBlur = splitArrayNew.Length == 2 ? splitArrayNew[1] : "";

        if (curBackground != "None"){
            backgroundSprite.SetBool(curName, false);
            if (curBlur != "Neutral") backgroundSprite.SetBool(curBlur, false);
        }
        if (spriteName != "None"){
            backgroundSprite.SetBool(newName, true);
            if (newBlur != "Neutral") backgroundSprite.SetBool(newBlur, true);
        }

        curBackground = spriteName;

    }



    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject, EventInfoTypes eventToClear){
        int index = 0;

        // var curQuest = 2; //some way to track conversation ig


        while (index < dialogueObject.Dialogue.Length){
        // foreach (DialoguePair dia in dialogueObject.Dialogue){
            var dia = dialogueObject.Dialogue[index];
            // Debug.Log(dia.dialogue + dia.questNum);
            // if ()
            // Debug.Log(dia.questNum);
            if (curQuest > dia.questNumMax || curQuest < dia.questNumMin){ //runs inclusive
                // if (curQuest > 0 && !debug && !atEnding){
                //     atEnding = true;
                //     if (points >= 5) {
                //         curQuest = 10;
                //         // StartCoroutine(AudioController.Instance.musicSource.CrossFade(AudioController.Instance.musicSounds[2]));
                //         // AudioController.Instance.PlayMusic(2);
                //         }
                //     else {
                //         curQuest = 20;
                //         // StartCoroutine(AudioController.Instance.musicSource.CrossFade(AudioController.Instance.musicSounds[3]));
                //         // AudioController.Instance.PlayMusic(3);

                //     }

                //     continue;
                // }
                index++;
                continue;
            }
            if (dia.showName != IsNameOpen){
                nameBox.SetActive(!nameBox.activeSelf);
                IsNameOpen = !IsNameOpen;
            }
            nameLabel.text = dia.name;
            if (dia.chatSprite != "" && dia.chatSprite != curSprite){ //need to make work with emotions better
                SetSprite(dia.chatSprite);
            }
            if (dia.isGrey) spriteImage.color = Color.grey;
            else spriteImage.color = Color.white;
            if (dia.bgSprite != "" && dia.bgSprite != curBackground){ //need to make work with emotions better
                SetBackground(dia.bgSprite);
            }
            yield return TypewriterEffect.Run(dia.dialogue.Replace("{PlayerName}", playerName), textLabel, dia.isBold, dia.isItalic);

            if (dia.choice){
                curentChoiceAmount = dia.choices.Length;
                yield return new WaitForSeconds(0.3f);
                curChoice = 0;

                StyleSelect(0);
                for (int i = 0; i < curentChoiceAmount; i++){
                    // make visually striked through if flag for unEnabled
                    options[i].text = doFormatting(MasterEventSystem.Instance.checkFlag(dia.isDisabled[i]) ? makeStrikeThrough(dia.choices[i]) : dia.choices[i], dia.isBold, dia.isItalic);
                }
                isChoice = true;
            }
            itemClicked = false;
            // Debug.Log("should this press pass: " + (!isChoice || MasterEventSystem.Instance.checkFlag(dia.isDisabled[curChoice])));
            yield return new WaitUntil(() => (Input.GetKeyUp(KeyCode.Space) || itemClicked || (!isChoice && Input.GetMouseButtonUp(0))) && curChoice < curentChoiceAmount && (!isChoice || !MasterEventSystem.Instance.checkFlag(dia.isDisabled[curChoice])));
            itemClicked = false;
            isChoice = false;
            for (int i = 0; i < options.Length; i++){
                options[i].text = "";
            }
            StyleSelect(-1);


            if (dia.stop) break;

            if (dia.advanceQuest) curQuest ++;// advance quest;
            if (debug) Debug.Log("my questVal = " + curQuest);


            if (dia.forceSkipTo != -1) index = dia.forceSkipTo;
            else if (dia.choice){
                // points+= dia.points[curChoice];
                MasterEventSystem.Instance.changePoints(dia.pointsGoTo[curChoice], dia.points[curChoice]);
                index = dia.choiceGoTo[curChoice];
                if (dia.hasFlag) MasterEventSystem.Instance.addFlag(dia.flags[curChoice]);
                curChoice = 0;
            }
            else{
                index++;
            }

        }

        CloseDialogueBox(true);
        Debug.Log("Please clear this event: " + eventToClear);
        if (eventToClear != EventInfoTypes.None) MasterEventSystem.Instance.eventTypeCleared(eventToClear);
    }

    public string makeStrikeThrough(string text) {
        return "<s>" + text + "</s>";
    }

    public string doFormatting(string text, bool isBold = false, bool isItalic = false) {
        string endText = text;
        if (isBold) endText = "<b>" + endText + "</b>";
        if (isItalic) endText = "<i>" + endText + "</i>";
        return endText;
    }

    private void CloseDialogueBox(bool switchScene = false){
        // Debug.Log("close called");
        curQuest = historyQuest;

        // Debug.Log("here are your points: " + points);

        IsOpen = false;
        IsNameOpen = false;
        // chatSprite.SetBool(curSprite, false);
        SetSprite("None");
        dialogueBox.SetActive(false);
        nameBox.SetActive(false);
        chatSpriteGO.SetActive(false);
        curChoice = 0;
        textLabel.text = string.Empty;
        for (int i = 0; i < options.Length; i++){
            options[i].text = string.Empty;
        }
        StyleSelect(-1);

        // if (switchScene) SceneManager.LoadScene(0);
    }

}
