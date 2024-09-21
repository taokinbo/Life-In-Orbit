using UnityEngine;

[CreateAssetMenu(fileName = "Level1Data", menuName = "Levels/Level1")] //makes a new instance of the LevelData ScriptableObject
public class MG1Level1Data : MiniGame1LevelData
{
    private void OnEnable()
    {
        //Set Level 1 UI and gameplay settings
        levelNumber = 1;
        timeOfDay = "Evening";
        hemisphere = "Southern";
        weatherCondition = "Clear Skies";
        overcastCondition = "None";
        maxSubmissions = 6; //no submission limit

        availableAngles = new SolarPanel.PanelAngle[] { SolarPanel.PanelAngle.Angle45, SolarPanel.PanelAngle.Angle90, SolarPanel.PanelAngle.Angle180 };
        availableOrientation = new SolarPanel.PanelOrientation[] { SolarPanel.PanelOrientation.South, SolarPanel.PanelOrientation.North, SolarPanel.PanelOrientation.West, SolarPanel.PanelOrientation.East };

        correctPanelSettings = new PanelSolution[]
        {
            new PanelSolution {panelID = 1, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 2, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 3, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.East},
            new PanelSolution {panelID = 4, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 5, correctAngle = SolarPanel.PanelAngle.Angle180, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 6, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.East}

        };

    }
}