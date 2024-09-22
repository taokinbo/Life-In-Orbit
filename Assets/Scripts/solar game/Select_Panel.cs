using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Panel : MonoBehaviour
{

    public int PanelID = -1;
    public SolarGameController gameController;
    public Sprite North;
    public Sprite East;
    public Sprite South;
    public Sprite West;
    public Sprite Empty;
    private int direction;
    public Image panelImage;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameController) gameController = GetComponent<SolarGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void panelClicked()
    {
        if (!gameController)
        {
            gameController = GetComponent<SolarGameController>();
        }
        gameController.setSelectedPanel(PanelID);
    }

    public void switchImage()
    {
        direction = (direction + 1) % 4;

        //var componetThing = panelImage.GetComponent<UnityEngine.UI.Image>();
        var componetThing = panelImage;
       // Debug.Log("did we find componentThing: " + componetThing);
        //var componetThing = panelImage;
        //Debug.Log("got to switch image: " + direction);
        switch (direction)
        {
            case 0:
                componetThing.sprite = South;
                break;
            case 1:
                componetThing.sprite = East;
                break;
            case 2:
                componetThing.sprite = North;
                break;
            case 3:
                componetThing.sprite = West;
                break;
            default:
                componetThing.sprite = Empty;
                break;
        }
    }


}
