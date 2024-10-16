using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    public MiniGame1Manager manager;
    public Image starRating;
    public TextMeshProUGUI submissionsUsed;
    public TextMeshProUGUI submissionsLeft;

    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
        button = FindObjectOfType<ButtonImageSwitch>();
        changeAngle = FindObjectOfType<ChangeAngle>();
        level = MasterEventSystem.Instance.getMinigameLevel();
        starRating.GetComponent<Image>().enabled = false;
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

    public int GetCurrentLevel() //for ascendancy index
    {
        return level;  // Returns the current level the player is on
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

        if(levelData.maxSubmissions != -1)
        {
            submissionsLeft.text = levelData.maxSubmissions.ToString();
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

    public void GenerateFeedback(List<int> incorrectAnglePanels, List<int> incorrectOrientationPanels, List<int> bothWrongPanels)
    {
        string feedback = "";

        // Access the correct solution from the levelData
        PanelSolution[] solution = levelData.correctPanelSettings;

        // General feedback for initial submissions
        if (submissions < levelData.maxSubmissions - 1)
        {
            if (bothWrongPanels.Count > 0)
            {
                feedback += "Panels " + string.Join(", ", bothWrongPanels) + " have both incorrect angle and orientation.\n";
            }
            if (incorrectAnglePanels.Count > 0)
            {
                feedback += "Panels " + string.Join(", ", incorrectAnglePanels) + " have the wrong angle.\n";
            }
            if (incorrectOrientationPanels.Count > 0)
            {
                feedback += "Panels " + string.Join(", ", incorrectOrientationPanels) + " have the wrong orientation.\n";
            }
        }
        // Specific feedback as they approach max submissions
        else
        {
            if (bothWrongPanels.Count > 0)
            {
                foreach (int panelID in bothWrongPanels)
                {
                    feedback += "Panel " + panelID + " needs to be adjusted to the correct angle (" + solution[panelID - 1].correctAngle + " degrees) and orientation (" + solution[panelID - 1].correctOrientation + ").\n";
                }
            }
            if (incorrectAnglePanels.Count > 0)
            {
                foreach (int panelID in incorrectAnglePanels)
                {
                    feedback += "Panel " + panelID + " needs to be adjusted to the correct angle (" + solution[panelID - 1].correctAngle + " degrees).\n";
                }
            }
            if (incorrectOrientationPanels.Count > 0)
            {
                foreach (int panelID in incorrectOrientationPanels)
                {
                    feedback += "Panel " + panelID + " needs to be adjusted to the correct orientation (" + solution[panelID - 1].correctOrientation + ").\n";
                }
            }
        }

        // Send the generated feedback to the UI system (or wherever feedback should be displayed)
        SendFeedbackToDialogue(feedback);
    }



    private void SendFeedbackToDialogue(string feedbackMessage)
    {
        Debug.Log("Sending feedback to dialogue system: " + feedbackMessage);
    }


    public void CheckSolution()
    {
        submissions++;
        submissionsUsed.text = submissions.ToString();

        if(levelData.maxSubmissions != -1)
            submissionsLeft.text = (levelData.maxSubmissions - submissions).ToString();

        bool allCorrect = true;
        List<int> incorrectAnglePanels = new List<int>();
        List<int> incorrectOrientationPanels = new List<int>();
        List<int> bothWrongPanels = new List<int>();

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
                    bool twoWrong = false;
                    allCorrect = false;

                    if(level <= 2)
                    {
                    
                        if (SolarPanels[panel.PanelID].currentAngle != solution[panel.PanelID].correctAngle && SolarPanels[panel.PanelID].currentOrientation != solution[panel.PanelID].correctOrientation)
                        {
                            bothWrongPanels.Add(panel.PanelID + 1);
                            twoWrong = true;
                        }
                        else if (SolarPanels[panel.PanelID].currentAngle != solution[panel.PanelID].correctAngle)
                        {
                            incorrectAnglePanels.Add(panel.PanelID + 1);
                        }
                        else
                        {
                            incorrectOrientationPanels.Add(panel.PanelID + 1);
                        }
                    }

                    if (twoWrong)
                    {
                        panel.GetComponent<Image>().color = Color.red;
                        twoWrong = false;
                    }
                    else
                    {
                        panel.GetComponent<Image>().color = Color.yellow;
                    }

                }
            }
        }
        GenerateFeedback(incorrectAnglePanels, incorrectOrientationPanels, bothWrongPanels);
        if (levelData.maxSubmissions != -1 && submissions >= levelData.maxSubmissions && !allCorrect)
        {
            //If we've run out of submissions and not all correct, disable and complete
            foreach(var panel in panels)
            {
                panel.GetComponent<Button>().interactable = false;
            }
            //starRating.enabled = true;
            starRating.GetComponent<Image>().enabled = true;
            manager.AwardStarRating(false, level, submissions, starRating);
            manager.OnMiniGameComplete();
        }
        else
        {
            if (allCorrect)
            {
                //starRating.enabled = true;
                starRating.GetComponent<Image>().enabled = true;
                manager.AwardStarRating(true, level, submissions, starRating);
                manager.OnMiniGameComplete();
            }
            else
            {
                manager.UpdateSubmissionUI(submissions, levelData.maxSubmissions);
            }
        }
    }
}
