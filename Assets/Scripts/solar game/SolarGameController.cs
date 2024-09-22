using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        int level = MasterEventSystem.Instance.getMinigameLevel();
        setUpLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelectedPanel(int panel)
    {
        selectedPanel = panel;
        changeAngle.setAngleImageDirection();
        foreach (var curPanel in panels)
        {
            if (curPanel.PanelID != selectedPanel) curPanel.unSelect();
        }

    }

    public int getSelectedPanel()
    {
        return selectedPanel;
    }

    public void changePanelImage()
    {
        if (selectedPanel == -1) return;
        foreach (var panel in panels)
        {
            if (panel.PanelID == selectedPanel) panel.switchImage();
        }
    }

    public void changeButtonImage()
    {
        button.changeButtonImage();
    }

    
    private void setUpLevel(int level)
    {
        if(level < 1)
        {
            foreach(var panel in panels)
            {
                if(panel.PanelID > 2)
                {
                    panel.GetComponent<Button>().interactable = false;
                }
            }
        }
        else if (level < 2)
        {
            foreach (var panel in panels)
            {
                if (panel.PanelID > 5)
                {
                    panel.GetComponent<Button>().interactable = false;
                }
            }
        }
    }
}
