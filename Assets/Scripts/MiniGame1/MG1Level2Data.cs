using UnityEngine;

[CreateAssetMenu(fileName = "Level12Data", menuName = "Levels/Level2")] //makes a new instance of the LevelData ScriptableObject
public class MG1Level2Data : MiniGame1LevelData
{
    private void OnEnable()
    {
        //Set Level 2 UI and gameplay settings
        levelNumber = 2;
        timeOfDay = "Midday";
        hemisphere = "Southern";
        weatherCondition = "Rain";
        overcastCondition = "Light";
        maxSubmissions = 5; //no submission limit

        availableAngles = new SolarPanel.PanelAngle[] { SolarPanel.PanelAngle.Angle45, SolarPanel.PanelAngle.Angle90, SolarPanel.PanelAngle.Angle180, SolarPanel.PanelAngle.Angle30, SolarPanel.PanelAngle.Angle60, SolarPanel.PanelAngle.Angle120 };
        availableOrientation = new SolarPanel.PanelOrientation[] { SolarPanel.PanelOrientation.South, SolarPanel.PanelOrientation.North, SolarPanel.PanelOrientation.West, SolarPanel.PanelOrientation.East };

        correctPanelSettings = new PanelSolution[]
        {
            new PanelSolution {panelID = 1, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 2, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 3, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.East},
            new PanelSolution {panelID = 4, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 5, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 6, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.East},
            new PanelSolution {panelID = 7, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 8, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.North},
            new PanelSolution {panelID = 9, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.East}


        };

    }
}