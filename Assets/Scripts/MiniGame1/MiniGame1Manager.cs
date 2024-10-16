using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MiniGame1Manager : MonoBehaviour
{
    // List to store all solar panels in the grid
    public List<SolarPanel> panels; // Reference to the solar panels in the scene
	public MiniGame1LevelData currentLevelData; //Data for the current level
    public Sprite Zero;
    public Sprite One;
    public Sprite Two;
    public Sprite Three;

    public int starRating;

    private int submissionCount = 0; //Track how many times the player submits

	public void LoadLevelData()
	{
		Debug.Log("Loading level data: " + currentLevelData.levelNumber);
		//Initialize the panels with level-specific data
		foreach (SolarPanel panel in panels)
		{
            PanelSolution solution = GetPanelSolution(panel.PanelID);
			panel.availableAngles = currentLevelData.availableAngles;
			panel.availableOrientation = currentLevelData.availableOrientation;
		}
	}

	// Method to adjust the angle of a specific panel based on its PanelID
	public void AdjustPanelAngle(int panelID, SolarPanel.PanelAngle newAngle)
	{
		SolarPanel panel = panels.Find(p => p.PanelID == panelID);
		if (panel != null)
		{
			panel.SetAngle(newAngle);
		}
	}

    // Method to adjust the orientation of a specific panel based on its PanelID
    public void AdjustPanelOrientation(int panelID, SolarPanel.PanelOrientation newOrientation)
	{
		SolarPanel panel = panels.Find(panel => panel.PanelID == panelID);
        if (panel != null)
        {
			panel.SetOrientation(newOrientation);
        }
    }

	// Check if all panels are correctly set
	public bool AreAllPanelsCorrect()
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

    public void AwardStarRating(bool completed, int level, int submissions, Image image)
    {


        if (completed)
        {
            if (level == 0)
            {
                if (submissions <= 3) { starRating  = 3; }
                else if (submissions <= 6 && submissions > 3) { starRating = 2; }
                else { starRating = 1; }
            }
            if (level == 1)
            {
                if (submissions <= 2) { starRating = 3; }
                else if (submissionCount == 3 || submissions == 4) { starRating = 2; }
                else { starRating = 1; }
            }
            if (level == 2)
            {
                if (submissions <= 2) { starRating = 3; }
                else if (submissions == 3) { starRating = 2; }
                else { starRating = 1; }
            }
            if (level == 3)
            {
                if (submissions <= 2) { starRating = 3; }
                else if (submissions == 3) { starRating = 2; }
                else { starRating = 1; }
            }
            if (level == 4)
            {
                if (submissions == 1) { starRating = 3; }
                else if (submissions == 2) { starRating = 2; }
                else { starRating = 1; }
            }
        }
        else
        {
            starRating = 0;
        }

        Debug.Log("Awarded " + starRating + " star(s) for this level.");
        UpdateStarRatingUI(starRating, image);
    }

    public int GetStarRating() //for ascendancy index
    {
        return starRating;  // Returns the  star rating  the player ecieved
    }

    private void GiveFeedback()
    {
        foreach (SolarPanel panel in panels)
        {
            PanelSolution solution = GetPanelSolution(panel.PanelID);

            if (panel.IsCorrect(solution))
            {
                Debug.Log("Panel: " + panel.PanelID + " is correct.");
                // change panel outline or overlay color to green (handled in Unity)
            }
            else
            {
                bool angleCorrect = panel.currentAngle == solution.correctAngle;
                bool orientationCorrect = panel.currentOrientation == solution.correctOrientation;

                if(!angleCorrect && !orientationCorrect)
                {
                    Debug.Log("Panel " + panel.PanelID + ": Both angle and orientation are incorrect (Red).");
                    // change panel outline or overlay color to red (handled in Unity)
                }
                else if (!angleCorrect || !orientationCorrect)
                {
                    Debug.Log("Panel " + panel.PanelID + ": Either angle or orientation are incorrect (Yellow).");
                    // change panel outline or overlay color to Yellow (handled in Unity)
                }

                //For levels 0-2, send feedback for Lumina to dialogue system
                if (currentLevelData.levelNumber <= 2)
                {
                    string feedbackMessage = GetFeedbackMessage(panel, angleCorrect, orientationCorrect);
                    SendFeedbackToDialogue(feedbackMessage);

                }
            }
            }
        }


    private string GetFeedbackMessage(SolarPanel panel, bool angleCorrect, bool orientationCorrect)
    {
        if (!angleCorrect && !orientationCorrect)
        {
            return " ";
        }
        else if (!angleCorrect)
        {
            return " ";
        }
        else if (!orientationCorrect)
        {
            return " ";
        }
        return " ";
    }

    public void SendFeedbackToDialogue(string feedbackMessage)
    {
        Debug.Log("Sending feedback to dialogue system: " + feedbackMessage);
    }

    private void UpdateStarRatingUI(int stars, Image image)
    {
        //Display star ratinsg popup
        Debug.Log("Displaying " + stars + " star(s) on the UI.");
        var imageComponent = image;

        //Trigger the pop-up in the UI
        //UIPopupManager.Instance.ShowStarRating(stars);
        switch (stars)
        {
            case 0:
                imageComponent.sprite = Zero;
                break;
            case 1:
                imageComponent.sprite = One;
                break;
            case 2:
                imageComponent.sprite = Two;
                break;
            case 3:
                imageComponent.sprite = Three;
                break;
            default:
                break;
        }

    }

	//Call this method when the player submits their configuration
	public void OnSubmit()
	{
		submissionCount++;
        if (currentLevelData.maxSubmissions != -1 && submissionCount > currentLevelData.maxSubmissions)
        {
            Debug.Log("Submission limit reached.");
            // Handle lockout or failure logic here
            //AwardStarRating(false); //Award player 0 stars for incomplete
        }
        else if (AreAllPanelsCorrect())
        {
            Debug.Log("All panels are correct! Level complete.");
            OnMiniGameComplete(); //Notify event system
            //AwardStarRating(true); //After mini-game completed, award stars based on performance
        }
        else
        {
            Debug.Log("Some panels are incorrect. Try again.");
            GiveFeedback();
        }
		//UpdateSubmissionUI(); //Update screen with submission count
    }

    public void UpdateSubmissionUI(int submissions, int maxSubmissions)
    {
        // This will update the UI to display the current submission count and remaining submissions
        Debug.Log("Submissions: " + submissions);
        if (maxSubmissions != -1)
        {
            Debug.Log("Submissions left: " + (maxSubmissions - submissions));
        }
    }
    //Notify EventSystem that mini-game is complete
    public void OnMiniGameComplete()
	{
        // Notify event system
        MasterEventSystem.Instance.removeFlag(Flags.Minigame1Start);
        MasterEventSystem.Instance.removeFlag(Flags.MG1F1);
        MasterEventSystem.Instance.removeFlag(Flags.MG1F2);
        MasterEventSystem.Instance.removeFlag(Flags.MG1F3);
        MasterEventSystem.Instance.removeFlag(Flags.MG1F4);
        MasterEventSystem.Instance.removeFlag(Flags.MG1F5);
        MasterEventSystem.Instance.removeFlag(Flags.MG1F6);
        MasterEventSystem.Instance.addFlag(Flags.MG1Complete);
        MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.EngineeringBay);
        // MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.Lumina);
		Debug.Log("Notified EventSystem that the mini-game is complete.");
	}
}
