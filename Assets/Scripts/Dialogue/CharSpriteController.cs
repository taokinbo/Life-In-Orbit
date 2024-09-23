using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharSprites
{
    None, Empty,
    Alien_neutral, Alien_laugh, Alien_suprise,
    Captain_neutral, Captain_speak, Captain_angry, Captain_dissapointed, Captain_happy, Captain_suprise,
    Doc_neutral, Doc_speak, Doc_angry, Doc_dissapointed, Doc_happy, Doc_suprise,
    Rival_neutral, Rival_speak, Rival_angry, Rival_dissapointed, Rival_happy, Rival_suprise,
}

public enum AudioBits
{
    None,
    Lumina_Alright, Lumina_FYI, Lumina_Talk, Lumina_Think, Lumina_ImLumina, Lumina_Welcome, Lumina_Wow, Lumina_Congrats, Lumina_UseThis, Lumina_How, Lumina_Excellent, Lumina_Oh, Lumina_Wait, Lumina_Almost, Lumina_Hmm, Lumina_OhNo, Lumina_AccessDenied,
    Captain_Welcome, Captain_Hmm, Captain_Simply, Captain_Listen, Captain_OnThatNote, Captain_Great, Captain_YouCan, Captain_KeepUp, Captain_Well, Captain_Hey, Captain_DamnIt,
    Doc_Hello, Doc_Hmm, Doc_Heh, Doc_Now, Doc_About, Doc_Exactly, Doc_Thanks, Doc_Really, Doc_Oh, Doc_Ehh, Doc_Ugh,
    Rival_HeyThere, Rival_WellThen, Rival_Hmmm, Rival_Fair, Rival_Ha, Rival_Yeah, Rival_Later, Rival_Yes, Rival_Lets, Rival_Oh, Rival_YouAgain,
}
public class CharSpriteController : MonoBehaviour
{

    [SerializeField]
    private Sprite Empty,
    Alien_neutral, Alien_laugh, Alien_suprise,
    Captain_neutral, Captain_speak, Captain_angry, Captain_dissapointed, Captain_happy, Captain_suprise,
    Doc_neutral, Doc_speak, Doc_angry, Doc_dissapointed, Doc_happy, Doc_suprise,
    Rival_neutral, Rival_speak, Rival_angry, Rival_dissapointed, Rival_happy, Rival_suprise;

    public Image spriteImage;
    public AudioSource audioSource;

    [SerializeField]
    private AudioClip Lumina_Alright, Lumina_FYI, Lumina_Talk, Lumina_Think, Lumina_ImLumina, Lumina_Welcome, Lumina_Wow, Lumina_Congrats, Lumina_UseThis, Lumina_How, Lumina_Excellent, Lumina_Oh, Lumina_Wait, Lumina_Almost, Lumina_Hmm, Lumina_OhNo, Lumina_AccessDenied,
    Captain_Welcome, Captain_Hmm, Captain_Simply, Captain_Listen, Captain_OnThatNote, Captain_Great, Captain_YouCan, Captain_KeepUp, Captain_Well, Captain_Hey, Captain_DamnIt,
    Doc_Hello, Doc_Hmm, Doc_Heh, Doc_Now, Doc_About, Doc_Exactly, Doc_Thanks, Doc_Really, Doc_Oh, Doc_Ehh, Doc_Ugh,
    Rival_HeyThere, Rival_WellThen, Rival_Hmmm, Rival_Fair, Rival_Ha, Rival_Yeah, Rival_Later, Rival_Yes, Rival_Lets, Rival_Oh, Rival_YouAgain;

    // Start is called before the first frame update
    void Start()
    {
        spriteImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchImage(CharSprites newImage)
    {
        Sprite sprite = Empty;

        switch (newImage)
        {
            case CharSprites.None:
                return;
            case CharSprites.Empty:
                sprite = Empty;
                break;
            case CharSprites.Alien_neutral:
                sprite = Alien_neutral;
                break;
            case CharSprites.Alien_laugh:
                sprite = Alien_laugh;
                break;
            case CharSprites.Alien_suprise:
                sprite = Alien_suprise;
                break;
            case CharSprites.Captain_neutral:
                sprite = Captain_neutral;
                break;
            case CharSprites.Captain_speak:
                sprite = Captain_speak;
                break;
            case CharSprites.Captain_angry:
                sprite = Captain_angry;
                break;
            case CharSprites.Captain_dissapointed:
                sprite = Captain_dissapointed;
                break;
            case CharSprites.Captain_happy:
                sprite = Captain_happy;
                break;
            case CharSprites.Captain_suprise:
                sprite = Captain_suprise;
                break;
            case CharSprites.Doc_neutral:
                sprite = Doc_neutral;
                break;
            case CharSprites.Doc_speak:
                sprite = Doc_speak;
                break;
            case CharSprites.Doc_angry:
                sprite = Doc_angry;
                break;
            case CharSprites.Doc_dissapointed:
                sprite = Doc_dissapointed;
                break;
            case CharSprites.Doc_happy:
                sprite = Doc_happy;
                break;
            case CharSprites.Doc_suprise:
                sprite = Doc_suprise;
                break;
            case CharSprites.Rival_neutral:
                sprite = Rival_neutral;
                break;
            case CharSprites.Rival_speak:
                sprite = Rival_speak;
                break;
            case CharSprites.Rival_angry:
                sprite = Rival_angry;
                break;
            case CharSprites.Rival_dissapointed:
                sprite = Rival_dissapointed;
                break;
            case CharSprites.Rival_happy:
                sprite = Rival_happy;
                break;
            case CharSprites.Rival_suprise:
                sprite = Rival_suprise;
                break;
        }
        spriteImage.sprite = sprite;
    }

    public void playVoiceSound(AudioBits soundBit)
    {
        if (soundBit == AudioBits.None) return;
        AudioClip sound = Lumina_Alright;

        switch (soundBit)
        {
            case AudioBits.None:
                break;
            case AudioBits.Lumina_Alright:
                break;
            case AudioBits.Lumina_FYI:
                break;
            case AudioBits.Lumina_Talk:
                break;
            case AudioBits.Lumina_Think:
                break;
            case AudioBits.Lumina_ImLumina:
                break;
            case AudioBits.Lumina_Welcome:
                break;
            case AudioBits.Lumina_Wow:
                break;
            case AudioBits.Lumina_Congrats:
                break;
            case AudioBits.Lumina_UseThis:
                break;
            case AudioBits.Lumina_How:
                break;
            case AudioBits.Lumina_Excellent:
                break;
            case AudioBits.Lumina_Oh:
                break;
            case AudioBits.Lumina_Wait:
                break;
            case AudioBits.Lumina_Almost:
                break;
            case AudioBits.Lumina_Hmm:
                break;
            case AudioBits.Lumina_OhNo:
                break;
            case AudioBits.Lumina_AccessDenied:
                break;
            case AudioBits.Captain_Welcome:
                break;
            case AudioBits.Captain_Hmm:
                break;
            case AudioBits.Captain_Simply:
                break;
            case AudioBits.Captain_Listen:
                break;
            case AudioBits.Captain_OnThatNote:
                break;
            case AudioBits.Captain_Great:
                break;
            case AudioBits.Captain_YouCan:
                break;
            case AudioBits.Captain_KeepUp:
                break;
            case AudioBits.Captain_Well:
                break;
            case AudioBits.Captain_Hey:
                break;
            case AudioBits.Captain_DamnIt:
                break;
            case AudioBits.Doc_Hello:
                break;
            case AudioBits.Doc_Hmm:
                break;
            case AudioBits.Doc_Heh:
                break;
            case AudioBits.Doc_Now:
                break;
            case AudioBits.Doc_About:
                break;
            case AudioBits.Doc_Exactly:
                break;
            case AudioBits.Doc_Thanks:
                break;
            case AudioBits.Doc_Really:
                break;
            case AudioBits.Doc_Oh:
                break;
            case AudioBits.Doc_Ehh:
                break;
            case AudioBits.Doc_Ugh:
                break;
            case AudioBits.Rival_HeyThere:
                break;
            case AudioBits.Rival_WellThen:
                break;
            case AudioBits.Rival_Hmmm:
                break;
            case AudioBits.Rival_Fair:
                break;
            case AudioBits.Rival_Ha:
                break;
            case AudioBits.Rival_Yeah:
                break;
            case AudioBits.Rival_Later:
                break;
            case AudioBits.Rival_Yes:
                break;
            case AudioBits.Rival_Lets:
                break;
            case AudioBits.Rival_Oh:
                break;
            case AudioBits.Rival_YouAgain:
                break;
            default:
                break;
        }
        audioSource.clip = sound;
        audioSource.Play();
    }
}
