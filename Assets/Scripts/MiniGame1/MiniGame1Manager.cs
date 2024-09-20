using UnityEngine;
using System.Collections.Generic;

public class MiniGame1Manager : MonoBehavior
{
    // List to store all solar panels in the grid
    public List<SolarPanel> panels; // Reference to the solar panels in the scene
	public LevelData currentLevelData; //Data for the current level

	private int submissionCount = 0; //Track how many times the player submits

	public void LoadLevelData()
	{
		Debug.Log("Loading leve data: " + currentLevelData.levelname);
		//Initialize the panels with level-specific data
		foreach (SolarPanel panel in panels)
		{
			panel.availableAngles = currentLevelData.availableAngles;
			panel.availableOrientations = currentLevelData.availableOrientations;
		}
	}

	// Method to adjust the angle of a specific panel based on its PanelID
	public void AdjustPanelAngle(int panelID, SolarPanel.PanelAngle newAngle)
	{
		SolarPanel panel = panels.Find(p => p.PanelID == panelID):
		if (panel != null)
		{
			panel.SetAngle(newAngle)
		}
	}

    // Method to adjust the orientation of a specific panel based on its PanelID
    public void AdjustPanelOrientation(int panelID, SolarPanel.PanelOrientation newOrientation)
	{
		SolarPanel panel = panels.Find(panel => panel.PanelID == panelID);
        if (panel != null)
        {
			panel.SetOrientation(newOrientation) 
        }
    }

	// Check if all panels are correctly set 
	public pool AreAllPanelsCorrect()
	{
        foreach (SolarPanel panel in panels)
        {
            PanelSolution solution = GetPanelSolution(panel.PanelID);
            if (!panel.IsCorrect(solution))
            {
                return false;
            }
        }
        return true;
    }

    private PanelSolution GetPanelSolution(int panelID)
    {
        foreach (PanelSolution solution in currentLevelData.correctPanelSettings)
        {
            if (solution.panelID == panelID)
            {
                return solution;
            }
        }
        return null;
    }

	//Call this method when the player submits their configuration
	public void OnSubmit()
	{
		submissionCount++;
        if (currentLevelData.maxSubmissions != -1 && submissionCount > currentLevelData.maxSubmissions)
        {
            Debug.Log("Submission limit reached.");
            // Handle lockout or failure logic here
        }
        else if (AreAllPanelsCorrect())
        {
            Debug.Log("All panels are correct! Level complete.");
            OnMiniGameComplete();
        }
        else
        {
            Debug.Log("Some panels are incorrect. Try again.");
        }
		UpdateSubmissionUI();
    }

    private void UpdateSubmissionUI()
    {
        // This will update the UI to display the current submission count and remaining submissions
        Debug.Log("Submissions: " + submissionCount);
        if (currentLevelData.maxSubmissions != -1)
        {
            Debug.Log("Submissions left: " + (currentLevelData.maxSubmissions - submissionCount));
        }
    }
    //Notify EventSystem that mini-game is complete
    public void OnMiniGameComplete()
	{
        // Notify event system
        MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.EngineeringBay);
		Debug.Log("Notified EventSystem that the mini-game is complete.")
	}


}
