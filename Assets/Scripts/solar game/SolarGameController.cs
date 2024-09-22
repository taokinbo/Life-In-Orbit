using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGameController : MonoBehaviour
{
    private Select_Panel[] panels;
    public int selectedPanel = -1;
    private ButtonImageSwitch button;
    private ChangeAngle changeAngle;
    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
        button = FindObjectOfType<ButtonImageSwitch>();
        changeAngle = FindObjectOfType<ChangeAngle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelectedPanel(int panel)
    {
        selectedPanel = panel;
        changeAngle.setAngleImageDirection();
    }

    public int getSelectedPanel()
    {
        return selectedPanel;
    }

    public void changePanelImage()
    {
        if (selectedPanel == -1) return;
        panels[panels.Length - 1 - selectedPanel].switchImage();
    }

    public void changeButtonImage()
    {
        button.changeButtonImage();
    }
}
