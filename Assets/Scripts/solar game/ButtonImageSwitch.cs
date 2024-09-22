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

        foreach (Select_Panel panel in panels)
        {
            if (panel.PanelID == selectedPanel) 
            {
                curImage = panel.GetComponentsInChildren<Image>()[1];
            }
        }

        var imageComponent = panelImage;

        switch (curImage.sprite.name)
        {
            case "Panel_Front":
                imageComponent.sprite = South;
                break;
            case "Panel_Left":
                imageComponent.sprite = West;
                break;
            case "Panel_Back":
                imageComponent.sprite = North;
                break;
            case "Panel_Right":
                imageComponent.sprite = East;
                break;
        }

    }
}