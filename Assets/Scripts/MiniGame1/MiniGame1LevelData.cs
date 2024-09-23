using UnityEngine;

[System.Serializable] //This allows class and variables to show up in the inspector.
public class MiniGame1LevelData : ScriptableObject
{
	//Solution Elements/UI changing elements
	public int levelNumber; //label level
	public string timeOfDay; //Time of day (e.g., Midday)
	public string weatherCondition; //Weather condition (e.r., Clear Skies)
	public string hemisphere; //Hemisphere (e.g. Northern or Southern
    public string overcastCondition; //(e.g. "Light cloud cover"

	// Available angles and orientations for this level
	public SolarPanel.PanelAngle[] availableAngles;
	public SolarPanel.PanelOrientation[] availableOrientation;

	//Correct settings for each panel in the grid
	public PanelSolution[] correctPanelSettings;

	//Submission-related
	public int maxSubmissions;


    // Commenting for clarity:
    // - timeOfDay will change the displayed time on the screen.
    // - hemisphere will change the globe icon (north or south).
    // - weatherCondition will change the weather icon.
    // - overcastCondition will determine which grid asset to display.
    // - maxSubmissions will change how many attempts the player has (except in Level 0, where it’s infinite).
}

[System.Serializable]
public class PanelSolution
{
	public int panelID; //Unique ID for each panel
	public SolarPanel.PanelAngle correctAngle; //Correct angle for this panel
	public SolarPanel.PanelOrientation correctOrientation; //Correct orienation for each angle
}
