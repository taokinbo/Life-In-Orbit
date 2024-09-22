using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum charSprites
{
    None, Empty,
    Alien_neutral, Alien_laugh, Alien_suprise,
    Captain_neutral, Captain_speak, Captain_angry, Captain_dissapointed, Captain_happy, Captain_suprise,
    Doc_neutral, Doc_speak, Doc_angry, Doc_dissapointed, Doc_happy, Doc_suprise,
    Rival_neutral, Rival_speak, Rival_angry, Rival_dissapointed, Rival_happy, Rival_suprise,
}
public class CharSpriteController : MonoBehaviour
{

    [SerializeField] private Sprite Empty;
    [SerializeField] private Sprite Alien_neutral;
    [SerializeField] private Sprite Alien_laugh;
    [SerializeField] private Sprite Alien_suprise;
    [SerializeField] private Sprite Captain_neutral;
    [SerializeField] private Sprite Captain_speak;
    [SerializeField] private Sprite Captain_angry;
    [SerializeField] private Sprite Captain_dissapointed;
    [SerializeField] private Sprite Captain_happy;
    [SerializeField] private Sprite Captain_suprise;
    [SerializeField] private Sprite Doc_neutral;
    [SerializeField] private Sprite Doc_speak;
    [SerializeField] private Sprite Doc_angry;
    [SerializeField] private Sprite Doc_dissapointed;
    [SerializeField] private Sprite Doc_happy;
    [SerializeField] private Sprite Doc_suprise;
    [SerializeField] private Sprite Rival_neutral;
    [SerializeField] private Sprite Rival_speak;
    [SerializeField] private Sprite Rival_angry;
    [SerializeField] private Sprite Rival_dissapointed;
    [SerializeField] private Sprite Rival_happy;
    [SerializeField] private Sprite Rival_suprise;

    private Image spriteImage;


    // Start is called before the first frame update
    void Start()
    {
        spriteImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchImage(charSprites newImage)
    {
        Sprite sprite = Empty;

        switch (newImage)
        {
            case charSprites.None:
                return;
            case charSprites.Empty:
                sprite = Empty;
                break;
            case charSprites.Alien_neutral:
                sprite = Alien_neutral;
                break;
            case charSprites.Alien_laugh:
                sprite = Alien_laugh;
                break;
            case charSprites.Alien_suprise:
                sprite = Alien_suprise;
                break;
            case charSprites.Captain_neutral:
                sprite = Captain_neutral;
                break;
            case charSprites.Captain_speak:
                sprite = Captain_speak;
                break;
            case charSprites.Captain_angry:
                sprite = Captain_angry;
                break;
            case charSprites.Captain_dissapointed:
                sprite = Captain_dissapointed;
                break;
            case charSprites.Captain_happy:
                sprite = Captain_happy;
                break;
            case charSprites.Captain_suprise:
                sprite = Captain_suprise;
                break;
            case charSprites.Doc_neutral:
                sprite = Doc_neutral;
                break;
            case charSprites.Doc_speak:
                sprite = Doc_speak;
                break;
            case charSprites.Doc_angry:
                sprite = Doc_angry;
                break;
            case charSprites.Doc_dissapointed:
                sprite = Doc_dissapointed;
                break;
            case charSprites.Doc_happy:
                sprite = Doc_happy;
                break;
            case charSprites.Doc_suprise:
                sprite = Doc_suprise;
                break;
            case charSprites.Rival_neutral:
                sprite = Rival_neutral;
                break;
            case charSprites.Rival_speak:
                sprite = Rival_speak;
                break;
            case charSprites.Rival_angry:
                sprite = Rival_angry;
                break;
            case charSprites.Rival_dissapointed:
                sprite = Rival_dissapointed;
                break;
            case charSprites.Rival_happy:
                sprite = Rival_happy;
                break;
            case charSprites.Rival_suprise:
                sprite = Rival_suprise;
                break;
        }
        spriteImage.sprite = sprite;

    }
}
