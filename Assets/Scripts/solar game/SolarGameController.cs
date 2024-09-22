using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class SolarGameController : MonoBehaviour
{
    private Select_Panel[] panels;
    public int selectedPanel = -1;
    private ButtonImageSwitch button;
    private ChangeAngle changeAngle;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
        button = FindObjectOfType<ButtonImageSwitch>();
        changeAngle = FindObjectOfType<ChangeAngle>();
        level = MasterEventSystem.Instance.getMinigameLevel();
        setUpLevel(level);
        //int level = MasterEventSystem.Instance.getMinigameLevel();
        //setUpLevel(level);
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

    /*
    private void setUpLevel(int level)
    {
        if(level < 1)
        {
            for(int i = 3; i < panels.Length; i++)
            {
                panels[i].GetComponent<Button>().interactable = false;
            }
        }
        else if (level < 2)
        {
            for(int i = 6; i < panels.Length; i++)
            {
                panels[i].GetComponent<Button>().interactable = false;
            }
        }
    }*/
}
