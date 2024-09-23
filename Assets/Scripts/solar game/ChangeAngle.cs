using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAngle : MonoBehaviour
{
    public SolarGameController gameController;
    public Sprite Angle0;
    public Sprite Angle30;
    public Sprite Angle45;
    public Sprite Angle60;
    public Sprite Angle90;
    private int direction;
    public Image panelImage;
    private TextMeshProUGUI textBox;
    private Select_Panel[] panels;

    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAngleImageDirection()
    {
        int selectedPanel = gameController.getSelectedPanel();
        foreach (Select_Panel panel in panels)
        {
            if (panel.PanelID == selectedPanel)
            {
                textBox = panel.GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        switch (textBox.text)
        {
            case "0":
                panelImage.sprite = Angle0;
                direction = 0;
                break;
            case "30":
                panelImage.sprite = Angle30;
                direction = 1;
                break;
            case "45":
                panelImage.sprite = Angle45;
                direction = 2;
                break;
            case "60":
                panelImage.sprite = Angle60;
                direction = 3;
                break;
            case "90":
                panelImage.sprite = Angle90;
                direction = 4;
                break;
            default:
                break;

        }
    }

    public void changeAngleImage()
    {
        int selectedPanel = gameController.getSelectedPanel();
        foreach (Select_Panel panel in panels)
        {
            if (panel.PanelID == selectedPanel)
            {
                textBox = panel.GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        int level = MasterEventSystem.Instance.getMinigameLevel();

        direction = (direction + 1) % 5;
        if (level == 0 || level == 1)
        {
            if(direction == 1 || direction == 3)
            {
                direction++;
            }
        }

        var imageComponent = panelImage;

        switch (direction)
        {
            case 0:
                panelImage.sprite = Angle0;
                changeText("0");
                gameController.SetSolarPanelAngle(SolarPanel.PanelAngle.Angle0, selectedPanel);
                break;
            case 1:
                panelImage.sprite = Angle30;
                gameController.SetSolarPanelAngle(SolarPanel.PanelAngle.Angle30, selectedPanel);
                changeText("30");
                break;
            case 2:
                panelImage.sprite = Angle45;
                gameController.SetSolarPanelAngle(SolarPanel.PanelAngle.Angle45, selectedPanel);
                changeText("45");
                break;
            case 3:
                panelImage.sprite = Angle60;
                gameController.SetSolarPanelAngle(SolarPanel.PanelAngle.Angle60, selectedPanel);
                changeText("60");
                break;
            case 4:
                panelImage.sprite = Angle90;
                gameController.SetSolarPanelAngle(SolarPanel.PanelAngle.Angle90, selectedPanel);
                changeText("90");
                break;
            default:
                break;
        }
            
    }

    private void changeText(string text)
    {
        textBox.text = text;
    }
}
