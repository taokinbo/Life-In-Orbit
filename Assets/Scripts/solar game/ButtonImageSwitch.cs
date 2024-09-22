using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageSwitch : MonoBehaviour
{
    public SolarGameController gameController;
    public Sprite North;
    public Sprite East;
    public Sprite South;
    public Sprite West;
    public Sprite Empty;
    private int direction;
    public Image panelImage;
    private Select_Panel[] panels;

    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeButtonImage()
    {
        int selectedPanel = gameController.getSelectedPanel();
        Image curImage = panels[panels.Length - 1 - selectedPanel].GetComponentsInChildren<Image>()[1];

        var imageComponent = panelImage;

        switch(curImage.sprite.name)
        {
            case "Panel_Front":
                Debug.Log("Panel front");
                imageComponent.sprite = South;
                break;
            case "Panel_Left":
                Debug.Log("Panel left");
                imageComponent.sprite = West;
                break;
            case "Panel_Back":
                Debug.Log("Panel back");
                imageComponent.sprite = North;
                break;
            case "Panel_Right":
                Debug.Log("Panel right");
                imageComponent.sprite = East;
                break;
         }

    }
}
