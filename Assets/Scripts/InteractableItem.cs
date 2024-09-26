using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color endColor = Color.magenta;
    public float outlineSize = 15.0f;
    private float speed = 0.50f;

    [SerializeField] private GameObject[] needsToBeInactive;

    [SerializeField] private Outline _spriteOutline;

    public Outline spriteOutline
    {
        get
        {
            if (_spriteOutline == null)
            {
                _spriteOutline = GetComponent<Outline>();
            }
            return _spriteOutline;
        }
    }

    [SerializeField] private DialogueUI _diaUI;
    public DialogueUI diaUI
    {
        get
        {
            if (_diaUI == null)
            {
                _diaUI = FindObjectOfType<DialogueUI>();
            }
            return _diaUI;
        }
    }

    private bool diaIsOpen = true;

    // [SerializeField] private Image _spriteImage;
    // public Image spriteImage{
    // 	get{
    // 		if(_spriteImage == null){
    // 			_spriteImage = GetComponent<Image>();
    // 		}
    // 		return _spriteImage;
    // 	}
    // }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (diaIsOpen && !diaUI.IsOpen && allGameObjectsInactive())
        { // if dialog was previosuly open but isnt anymore
            diaIsOpen = false;
            StartCoroutine(ChangeEngineColour());
        }
    }

    private IEnumerator ChangeEngineColour()
    {
        float tick = 0f;
        spriteOutline.effectColor = Color.magenta;
        while (!diaUI.IsOpen)
        {
            tick += Time.deltaTime * speed;
            // engineBodyRenderer.material.color = Color.Lerp(startColor, endColor, tick);
            // spriteImage.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));
            // spriteImage.material.color = Color.white;
            spriteOutline.effectDistance = Vector2.Lerp(Vector2.zero, Vector2.one * outlineSize, Mathf.PingPong(Time.time * speed, 1));
            yield return null;
        }
        diaIsOpen = true;
        spriteOutline.effectDistance = Vector2.zero;
        spriteOutline.effectColor = Color.white;
    }

    private bool allGameObjectsInactive() {
        bool isInactive = true;
        if (needsToBeInactive == null || needsToBeInactive.Length == 0) return isInactive;
        foreach (GameObject go in needsToBeInactive) {
            isInactive = isInactive && !go.activeSelf;
        }

        return isInactive;
    }
}
