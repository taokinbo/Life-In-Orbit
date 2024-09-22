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
    public Sprite Level0;
    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;
    public Sprite Level4;
    private SolarPanel[] SolarPanels = new SolarPanel[9];

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
        changeButtonImage();
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

        foreach(var panel in panels)
        {
            if (panel.enabled)
            {
                //SolarPanel solarPanel = panel.GetComponent<SolarPanel>();
                //solarPanel.SetAngle(0);
                //solarPanel.SetOrientation(SolarPanel.PanelOrientation.South);
                //SolarPanels[panel.PanelID] = solarPanel;
            }
        }

        var images = GetComponentsInChildren<Image>();
        Debug.Log(images.Length);
        var image = images[0];
        foreach(var i in images)
        {
            if (i.name.Equals("Level Info"))
            {
                image = i;
            }
        }

        switch (level)
        {
            case 0:
                image.sprite = Level0;
                break;
            case 1:
                image.sprite = Level1;
                break;
            case 2:
                image.sprite = Level2;
                break;
            case 3:
                image.sprite = Level3;
                break;
            case 4:
                image.sprite = Level4;
                break;
            default:
                break;
        }
    }

    public SolarPanel[] GetSolarPanels()
    {
        return SolarPanels;
    }

    public void SetSolarPanelAngle(SolarPanel.PanelAngle angle, int panelID)
    {
        SolarPanels[panelID].SetAngle(angle);
    }

    public void SetSolarPanelOrientation(SolarPanel.PanelOrientation orientation, int panelID)
    {
        SolarPanels[panelID].SetOrientation(orientation);
    }
}
