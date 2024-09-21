using UnityEngine;

[CreateAssetMenu(fileName = "Level0Data", menuName = "Levels/Level0")] //makes a new instance of the LevelData ScriptableObject
public class MG1Level0Data : MiniGame1LevelData
{
	private void OnEnable()
	{
		//Set Level 0 UI and gameplay settings
		levelNumber = 0;
		timeOfDay = "Midday";
		hemisphere = "Northern";
		weatherCondition = "Clear Skies";
		overcastCondition = "None";
		maxSubmissions = -1; //no submission limit

		availableAngles = new SolarPanel.PanelAngle[] { SolarPanel.PanelAngle.Angle45, SolarPanel.PanelAngle.Angle90, SolarPanel.PanelAngle.Angle180 };
		availableOrientation = new SolarPanel.PanelOrientation[] { SolarPanel.PanelOrientation.South, SolarPanel.PanelOrientation.North, SolarPanel.PanelOrientation.West, SolarPanel.PanelOrientation.East };

		correctPanelSettings = new PanelSolution[]
		{
			new PanelSolution {panelID = 1, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.South},
			new PanelSolution {panelID = 2, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.South},
			new PanelSolution {panelID = 3, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.South}

		};

    }
}
