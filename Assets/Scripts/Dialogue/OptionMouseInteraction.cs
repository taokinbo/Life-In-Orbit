using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionMouseInteraction : MonoBehaviour,IPointerEnterHandler, IPointerClickHandler//,IPointerExitHandler
{

    private DialogueUI dialogueUI;
    // bool isHover = false;
    public int index;
    public bool isEnabled = true;
    private bool justClicked = false;


    // Start is called before the first frame update
    void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (justClicked) {
            justClicked = false;
            StartCoroutine( switchClickBack() );
        }
    }

    private IEnumerator switchClickBack()
{
        yield return new WaitForSeconds( 0.01f );
        dialogueUI.itemClicked = false;
    }

    // public void OnMouseOver()
    // {
    //     Debug.Log("hovering on :" + index);
    //     if (!isHover){
    //         isHover = true;
    //         if (DialogueUI) {
    //             DialogueUI.curChoice = 0;
    //             DialogueUI.StyleSelect(index);
    //         }
    //     }
    // }

    // public void OnMouseExit()
    // {
    //     if (DialogueUI) {
    //         isHover = false;
    //     }
    // }

    // public void OnMouseDown()
    // {
    //     if (DialogueUI) {
    //         DialogueUI.itemClicked = true;
    //     }
    // }

    public void OnPointerClick(PointerEventData data)
    {
        if (dialogueUI && dialogueUI.isChoice) {
            dialogueUI.itemClicked = true;
            justClicked = true;
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        // Debug.Log("hovering on :" + index);
        if (dialogueUI && dialogueUI.isChoice) {
            // Debug.Log("has dia");
            dialogueUI.curChoice = index;
            dialogueUI.StyleSelect(index);
        }
    }

    public void enableOption() {
        isEnabled = true;
    }
}
