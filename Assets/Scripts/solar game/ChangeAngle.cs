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
        textBox = panels[panels.Length - 1 - selectedPanel].GetComponentInChildren<TextMeshProUGUI>();

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
        textBox = panels[panels.Length - 1 - selectedPanel].GetComponentInChildren<TextMeshProUGUI>();

        direction = (direction + 1) % 5;

        var imageComponent = panelImage;

        switch (direction)
        {
            case 0:
                panelImage.sprite = Angle0;
                changeText("0");
                break;
            case 1:
                panelImage.sprite = Angle30;
                changeText("30");
                break;
            case 2:
                panelImage.sprite = Angle45;
                changeText("45");
                break;
            case 3:
                panelImage.sprite = Angle60;
                changeText("60");
                break;
            case 4:
                panelImage.sprite = Angle90;
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
