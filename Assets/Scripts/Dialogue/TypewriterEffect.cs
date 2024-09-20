using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{

    [SerializeField] private float typewriterSpeed = 50f;

    // Responsible for running co-routine
    public Coroutine Run(string textToType, TMP_Text textLabel, bool isBold = false, bool isItalic = false){
        return StartCoroutine(TypeText(textToType, textLabel, isBold, isItalic));
    }

    // Responsible for typing text
    private IEnumerator TypeText(string textToType, TMP_Text textLabel, bool isBold = false, bool isItalic = false){

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) && t!= 0) {
                charIndex = textToType.Length;
                yield return null;
                continue;

            }

            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            string tempText = textToType.Substring(0, charIndex);
            if (isBold) tempText = "<b>" + tempText + "</b";
            if (isItalic) tempText = "<i>" + tempText + "</i>";
            textLabel.text = tempText;

            yield return null;

        }
        string endText = textToType;
        if (isBold) endText = "<b>" + endText + "</b";
        if (isItalic) endText = "<i>" + endText + "</i>";
        textLabel.text = endText;
    }
}
