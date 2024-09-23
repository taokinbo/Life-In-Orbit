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
    private MiniGame1LevelData levelData;
    private int level;
    private int submissions;

    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
        button = FindObjectOfType<ButtonImageSwitch>();
        changeAngle = FindObjectOfType<ChangeAngle>();
        level = MasterEventSystem.Instance.getMinigameLevel();
        setUpLevel();
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
    
    private void setUpLevel()
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
                SolarPanel solarPanel = panel.GetComponent<SolarPanel>();
                solarPanel.SetAngle(SolarPanel.PanelAngle.Angle0);
                solarPanel.SetOrientation(SolarPanel.PanelOrientation.South);
                SolarPanels[panel.PanelID] = solarPanel;
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
        //Debug.Log(angle.ToString());
    }

    public void SetSolarPanelOrientation(SolarPanel.PanelOrientation orientation, int panelID)
    {
        SolarPanels[panelID].SetOrientation(orientation);
        //Debug.Log(orientation.ToString());
    }

    public void CheckSolution()
    {
        submissions++;

        switch (level)
        {
            case 0:
                levelData = ScriptableObject.CreateInstance<MG1Level0Data>();
                break;
            case 1:
                levelData = ScriptableObject.CreateInstance<MG1Level1Data>();
                break;
            case 2:
                levelData = ScriptableObject.CreateInstance<MG1Level2Data>();
                break;
            case 3:
                levelData = ScriptableObject.CreateInstance<MG1Level3Data>();
                break;
            case 4:
                levelData = ScriptableObject.CreateInstance<MG1Level4Data>();
                break;
            default:
                break;
        }

        bool allCorrect = true;
        foreach (var panel in panels)
        {
            if (panel.GetComponent<Button>().IsInteractable())
            {
                //Debug.Log("Panel Number " + panel.PanelID + "Panel Direction: " + SolarPanels[panel.PanelID].GetOrientation() + "Panel Angle: " + SolarPanels[panel.PanelID].GetAngle());
                
                PanelSolution[] solution = levelData.correctPanelSettings;
                bool v = SolarPanels[panel.PanelID].IsCorrect(solution[panel.PanelID]);
                if (v)
                {
                    panel.GetComponent<Button>().interactable = false;
                    panel.GetComponent<Image>().color = Color.green;
                }
                else
                {
                    panel.GetComponent<Image>().color = Color.red;
                    allCorrect = false;
                }
            }
        }

        if(submissions >= levelData.maxSubmissions)
        {
            if (!allCorrect)
            {
                foreach(var panel in panels)
                {
                    panel.GetComponent<Button>().interactable = false;
                }

            }
        }
    }
}
