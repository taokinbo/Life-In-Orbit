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

        switch(curImage.name)
        {
            case "Panel_Front":
                break;
            case "Panel_Left":
                break;
            case "Panel_Back":
                break;
            case "Panel_Right":
                break;
         }

    }
}
