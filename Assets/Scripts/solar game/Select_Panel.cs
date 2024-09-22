using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Select_Panel : MonoBehaviour
{

    public int PanelID = -1;
    public SolarGameController gameController;
    public Sprite North;
    public Sprite East;
    public Sprite South;
    public Sprite West;
    public Sprite Empty;
    private int direction;
    public Image panelImage;
    // Start is called before the first frame update
    private Select_Panel[] panels;

    void Start()
    {
        if (!gameController) gameController = GetComponent<SolarGameController>();
        panels = FindObjectsOfType<Select_Panel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void panelClicked()
    {
        if (!gameController)
        {
            gameController = GetComponent<SolarGameController>();
        }

        //set new selected panel
        gameController.setSelectedPanel(PanelID);
        setPanelSelectedColor();
    }

    public void unSelect()
    {
        GetComponent<Image>().color = Color.white;
    }

    private void setPanelSelectedColor()
    {

        GetComponent<Image>().color = Color.magenta;
    }
    public void switchImage()
    {
        direction = (direction + 1) % 4;

        var componetThing = panelImage;

        switch (direction)
        {
            case 0:
                componetThing.sprite = South;
                //gameController.SetSolarPanelOrientation(SolarPanel.PanelOrientation.South, PanelID);
                break;
            case 1:
                componetThing.sprite = East;
                //gameController.SetSolarPanelOrientation(SolarPanel.PanelOrientation.East, PanelID);
                break;
            case 2:
                componetThing.sprite = North;
               // gameController.SetSolarPanelOrientation(SolarPanel.PanelOrientation.North, PanelID);
                break;
            case 3:
                componetThing.sprite = West;
                //gameController.SetSolarPanelOrientation(SolarPanel.PanelOrientation.West, PanelID);
                break;
            default:
                componetThing.sprite = Empty;
                break;
        }
    }


}
