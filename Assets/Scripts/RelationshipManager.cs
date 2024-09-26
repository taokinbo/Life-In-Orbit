using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RelationshipManager : MonoBehaviour
{
	
	public static RelationshipManager Instance; //Single instance for easy access
	
	//UI text for each character status
	public TextMeshProUGUI captainHawthornStatusText;
	public TextMeshProUGUI drAspenBonnieStatusText;
	public TextMeshProUGUI garyPineStatusText;

    //refernces to UI in Unity for Directory
    public GameObject directoryPanel;
    public GameObject homePanel;



	public void OpenDirectory()
	{
		// hide home screen and show the directory
		directoryPanel.SetActive(true);

        UpdateJournalUI();

		Debug.Log("Directory opened, displaying relationship statuses.");
	}

    public void BackToHome()
    {
        // Hide the Directory UI and show the home screen
        directoryPanel.SetActive(false); // Show the home screen button
        homePanel.SetActive(true);

        Debug.Log("Returned to home screen.");
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
        //check for masteventsystem
        if (MasterEventSystem.Instance == null)
        {
            Debug.LogError("MasterEventSystem.Instance is null!");
            return "Error: Master Event System is not available.";
        }

        // Directly check flags
        if (MasterEventSystem.Instance.checkFlag(Flags.HawthornLikePlus))
        {
            return "<b>Right-Hand Crew Member</b>\n<size=16><i>Captain Hawthorn sees you as his right-hand, always ready to step up and lead.</i></size>";
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.HawthornLike))
        {
            return "<b>Dependable Inhabitant</b>\n<size=16><i>You're reliable and competent. Hawthorn knows he can count on you.</i></size>";
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.HawthornDislike))
        {
            return "<b>Unreliable Cadet</b>\n<size=16><i>Hawthorn isn’t sure he can trust you. Working together is tense.</i></size>";
        }
        else
        {
            return "<b>Loose Cannon</b>\n<size=16><i>Hawthorn sees you as unpredictable and a danger to the station’s stability.</i></size>";
        }

    }

    private string GetDrAspenBonnieStatus()
    {
        //check for masteventsystem
        if (MasterEventSystem.Instance == null)
        {
            Debug.LogError("MasterEventSystem.Instance is null!");
            return "Error: Master Event System is not available.";
        }

        if (MasterEventSystem.Instance.checkFlag(Flags.BonnieLikePlus))
        {
            return "<b>Research Partner</b>\n<size=16><i>Dr. Bonnie considers you invaluable for breakthrough discoveries.</i></size>";
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.BonnieLike))
        {
            return "<b>Valued Colleague</b>\n<size=16><i>Bonnie respects your input, but you're not in her trusted circle yet.</i></size>";
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.BonnieDislike))
        {
            return "<b>Persistent Nuisance</b>\n<size=16><i>Bonnie finds you a hindrance, tolerating you but preferring distance.</i></size>";
        }
        else
        {
            return "<b>Scientific Deadweight</b>\n<size=16><i>Bonnie sees you as a setback, preferring to work alone.</i></size>";
        }
    }

    private string GetGaryPineStatus()
    {
        //check for masteventsystem
        if (MasterEventSystem.Instance == null)
        {
            Debug.LogError("MasterEventSystem.Instance is null!");
            return "Error: Master Event System is not available.";
        }

        if (MasterEventSystem.Instance.checkFlag(Flags.PineLikePlus))
        {
            return "<b>Partner in Crime</b>\n<size=16><i>You and Gary Pine make a perfect team, always seen together.</i></size>";
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.PineLike))
        {
            return "<b>Budding Ally</b>\n<size=16><i>Gary likes working with you, but he's not fully sure he can trust you yet.</i></size>";
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.PineDislike))
        {
            return "<b>Rival</b>\n<size=16><i>There's tension, and Gary isn’t above outmaneuvering you.</i></size>";
        }
        else
        {
            return "<b>Arch Nemesis</b>\n<size=16><i>You and Gary Pine are locked in a fierce competition.</i></size>";
        }
    }

	public void UpdateJournalUI()
	{
		captainHawthornStatusText.text = GetRelationshipStatus("CaptainHawthorn");
		drAspenBonnieStatusText.text = GetRelationshipStatus("DrAspenBonnie");
		garyPineStatusText.text = GetRelationshipStatus("GaryPine");
	}
}
