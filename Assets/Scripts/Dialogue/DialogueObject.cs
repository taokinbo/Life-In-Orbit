using UnityEngine;
using System.Linq;


[System.Serializable]
public class DialoguePair{
    public string dialogue;
    public int questNumMin;
    public int questNumMax;
    public bool stop = false;
    public int forceSkipTo = -1;
    public bool choice = false;
    public string[] choices;
    public int[] choiceGoTo;
    // public int correctChoice = -1;
    public int[] points;
    public EventInfoTypes[] pointsGoTo;
    public bool hasFlag = false;
    public Flags[] flags;
    public Flags[] isDisabled;
    public bool advanceQuest = false;
    public string chatSprite = "";
    public CharSprites charSprites = CharSprites.None;
    public AudioBits soundBit = AudioBits.None;
    public string bgSprite = "";
    public bool showName = false;
    public string name = "";
    public bool isGrey = false;
    public bool isBold = false;
    public bool isItalic = false;
    public bool shake = false;
}

// Creating special dialogue asset
[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    // Giving our dialogue asset text fields
    [SerializeField] DialoguePair[] dialogue;


    // Getter
    public DialoguePair[] Dialogue => dialogue;
}
