using UnityEngine;

public class SolarPanel : MonoBehaviour
{
	//Panel ID to uniquely identify each panel
	public int PanelID;

	//Enums for the available angles and orientations
	public enum PanelAngle { Angle45 = 45, Angle90 = 90, Angle30 = 30, Angle60 = 60, Angle0 = 0 }
	public enum PanelOrientation { North, East, South, West }

	//Assume that the arrow click system updates these values
	public PanelAngle currentAngle;
	public PanelOrientation currentOrientation;

	//Available angles and orientations based on level data
	public PanelAngle[] availableAngles;
	public PanelOrientation[] availableOrientation;

	//Method to check if the panel is set correctly
	public bool IsCorrect(PanelSolution solution)
	{
		return currentAngle == solution.correctAngle && currentOrientation == solution.correctOrientation;
	}

	//Placeholder for getting the player's selected angle and orientation (through arrow click system)
	public void UpdateCurrentPanel(PanelAngle angle, PanelOrientation orientation)
	{
		//The angle and orientation are placeholders and should come from Alyssa's UI logic
		currentAngle = angle;
		currentOrientation = orientation;
        Debug.Log("Panel " + PanelID + " angle set to: " + currentAngle);
        Debug.Log("Panel " + PanelID + " orientation set to: " + currentOrientation);
    }

	public void SetAngle(PanelAngle newAngle){
		currentAngle = newAngle;
	}

	public void SetOrientation(PanelOrientation newOrientation){
		currentOrientation = newOrientation;
	}

	public PanelAngle GetAngle() {  return currentAngle; }
	public PanelOrientation GetOrientation() { return currentOrientation; }
}
