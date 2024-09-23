using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RelationshipManager : MonoBehaviour
{
	
	public static RelationshipManager Instance; //Single instance for easy access
	
	//Relationship values for each character
	public int captainHawthornRelationship = 0;
	public int drAspenBonnieRelationship = 0;
	public int garyPineRelationship = 0;

	//UI text for each character status
	public TextMeshProUGUI captainHawthornStatusText;
	public TextMeshProUGUI drAspenBonnieStatusText;
	public TextMeshProUGUI garyPineStatusText;

	//refernces to UI in Unity for Directory
	public GameObject directoryBG;
	public GameObject directoryButton;
	public GameObject backButton;

	//Ascendancy index
	public int ascendancyIndex = 0;
	
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); // Keep the relationship manager between scenes

        }
		else
		{
			Destroy(gameObject);
		}
	}

	public void OpenDirectory()
	{
		// hide home screen and show the directory
		directoryButton.SetActive(false); //hide home screen button
		directoryBG.SetActive(true); //show the directory
		backButton.SetActive(true); //show the back button

        //shoe the relationship statuses
        captainHawthornStatusText.gameObject.SetActive(true);
        drAspenBonnieStatusText.gameObject.SetActive(true);
        garyPineStatusText.gameObject.SetActive(true);

        UpdateJournalUI();

		MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.OpenDirectory);

		Debug.Log("Directory opened, displaying relationship statuses.");
	}

    public void BackToHome()
    {
        // Hide the Directory UI and show the home screen
        directoryBG.SetActive(false);  // Hide the Directory background
        backButton.SetActive(false);  // Hide the back button
        directoryButton.SetActive(true);  // Show the home screen button

        //hide the directory again
        captainHawthornStatusText.gameObject.SetActive(false);
        drAspenBonnieStatusText.gameObject.SetActive(false);
        garyPineStatusText.gameObject.SetActive(false);

        Debug.Log("Returned to home screen.");
    }

    public void UpdateRelationship(string characterName, int changeValue)
	{
		switch (characterName)
		{
			case "CaptainHawthorn":
				captainHawthornRelationship += changeValue;
				break;
			case "DrAspenBonnie":
				drAspenBonnieRelationship += changeValue; 
				break;
			case "GaryPine":
				garyPineRelationship += changeValue; 
				break;
		}

        // Ensure the relationship value stays within range
        captainHawthornRelationship = Mathf.Clamp(captainHawthornRelationship, -11, 11);
        drAspenBonnieRelationship = Mathf.Clamp(drAspenBonnieRelationship, -10, 10);
        garyPineRelationship = Mathf.Clamp(garyPineRelationship, -12, 12);

		//Uodate the Ascendancy Index based on the relationship change
		AscendancyIndexManager.Instance.UpdateAscendancyBasedOnRelationships(captainHawthornRelationship, drAspenBonnieRelationship, garyPineRelationship);

    }

    public string GetRelationshipStatus(string characterName)
	{
		switch (characterName)
		{
			case "CaptainHawthorn":
				return GetCaptainHawthornStatus();
			case "DrAspenBonnie":
				return GetDrAspenBonnieStatus();
			case "GaryPine":
				return GetGaryPineStatus();
			default:
				return "Unknown";
		}
	}

	private string GetCaptainHawthornStatus()
	{
        if (captainHawthornRelationship >= 7)
            return "Right-Hand Crew Member\n" +
                "Captain Hawthorn sees you as his right-hand, always ready to step up and lead when needed.\r\n";
        else if (captainHawthornRelationship >= 1)
            return "Dependable Inhabitant\n" +
                "You’re reliable and competent, and Captain Hawthorn knows he can count on you to get the job done.\r\n";
        else if (captainHawthornRelationship >= -6)
            return "Unreliable Cadet\n" +
                "Captain Hawthorn isn’t sure he can trust you— your unpredictability makes working together tense.\r\n";
        else
            return "Loose Cannon\n" +
                "Captain Hawthorn sees you as unpredictable and a danger to the station’s stability.";
    }

    private string GetDrAspenBonnieStatus()
    {
        if (drAspenBonnieRelationship >= 7)
            return "Research Partner\n" +
                "Dr. Aspen Bonnie considers you an invaluable collaborator, someone she can rely on for breakthrough discoveries.\r\n";
        else if (drAspenBonnieRelationship >= 1)
            return "Valued Colleague\n" +
                "Dr. Bonnie respects your input, but you’re not yet fully in her circle of trusted confidants.\r\n";
        else if (drAspenBonnieRelationship >= -6)
            return "Persistent Nuisance\n" +
                "Dr. Bonnie considers you an ongoing annoyance, someone she has to tolerate but would rather not deal with.\r\n";
        else
            return "Scientific Deadweight\n" +
                "Dr. Bonnie sees you as a hindrance to progress, preferring to work without your involvement entirely.\r\n";
    }

    private string GetGaryPineStatus()
    {
        if (garyPineRelationship >= 7)
            return "Partner in Crime\n" +
                "You and Gary Pine make a perfect team, always seen together and finding shortcuts to your tasks.\r\n";
        else if (garyPineRelationship >= 1)
            return "Budding Ally\n" +
                "Gary Pine likes working with you, but he’s still figuring out if he can fully trust you.\r\n";
        else if (garyPineRelationship >= -6)
            return "Rival\n" +
                "There’s tension between you and Gary Pine, and he’s not above trying to outmaneuver you.\r\n";
        else
            return "Arch Nemesis\n" +
                "You and Gary Pine are locked in a fierce competition, constantly trying to outsmart each other.\r\n";
    }

	public void UpdateJournalUI()
	{
		captainHawthornStatusText.text = GetRelationshipStatus("CaptainHawthorn");
		drAspenBonnieStatusText.text = GetRelationshipStatus("DrAspenBonnie");
		garyPineStatusText.text = GetRelationshipStatus("GaryPine");
	}
}
