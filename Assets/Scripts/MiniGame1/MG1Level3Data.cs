using UnityEngine;

[CreateAssetMenu(fileName = "Level13Data", menuName = "Levels/Level3")] //makes a new instance of the LevelData ScriptableObject
public class MG1Level3Data : MiniGame1LevelData
{
    private void OnEnable()
    {
        //Set Level 3 UI and gameplay settings
        levelNumber = 3;
        timeOfDay = "Morning";
        hemisphere = "Northern";
        weatherCondition = "Snow";
        overcastCondition = "Light & Heavy";
        maxSubmissions = 4; //no submission limit

        availableAngles = new SolarPanel.PanelAngle[] { SolarPanel.PanelAngle.Angle45, SolarPanel.PanelAngle.Angle90, SolarPanel.PanelAngle.Angle0, SolarPanel.PanelAngle.Angle30, SolarPanel.PanelAngle.Angle60};
        availableOrientation = new SolarPanel.PanelOrientation[] { SolarPanel.PanelOrientation.South, SolarPanel.PanelOrientation.North, SolarPanel.PanelOrientation.West, SolarPanel.PanelOrientation.East };

        correctPanelSettings = new PanelSolution[]
        {
            new PanelSolution {panelID = 0, correctAngle = SolarPanel.PanelAngle.Angle90, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 1, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 2, correctAngle = SolarPanel.PanelAngle.Angle60, correctOrientation = SolarPanel.PanelOrientation.East},
            new PanelSolution {panelID = 3, correctAngle = SolarPanel.PanelAngle.Angle30, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 4, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.South},
            new PanelSolution {panelID = 5, correctAngle = SolarPanel.PanelAngle.Angle90, correctOrientation = SolarPanel.PanelOrientation.East},
            new PanelSolution {panelID = 6, correctAngle = SolarPanel.PanelAngle.Angle30, correctOrientation = SolarPanel.PanelOrientation.West},
            new PanelSolution {panelID = 7, correctAngle = SolarPanel.PanelAngle.Angle45, correctOrientation = SolarPanel.PanelOrientation.South},
            new PanelSolution {panelID = 8, correctAngle = SolarPanel.PanelAngle.Angle90, correctOrientation = SolarPanel.PanelOrientation.East}


        };

    }
}