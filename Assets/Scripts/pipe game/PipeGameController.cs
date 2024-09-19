using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class PipeGameController : MonoBehaviour
{

    public PipeLayerData layer1Data;
    Color color1 = new Color(0.231f, 0.768f, 1f, 1f);

    public PipeLayerData layer2Data;
    Color color2 = new Color(0.925f, 0.329f, 0.8f, 1f);

    public PipeLayerData layer3Data;
    Color color3 = new Color(1f, 0.803f, 0.078f, 1f);

    public LayerSwap LayerSwap;
    // Start is called before the first frame update
    void Start()
    {
        layer1Data.init();
        layer2Data.init();
        layer3Data.init();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void startGame()
    {
        loadLevelData(1);
    }

    private int[] level1Layer1 = {
        1, 1, 1, 1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1, 1, 1, 1,
    };
    private int[] level1Layer2 = {
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };
    private int[] level1Layer3 = {
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };

    void loadLevel()
    {
        layer1Data.loadLevel1(blankPos, level1Layer1, color1);
        layer2Data.loadLevel1(blankPos, level1Layer2, color2);
        layer3Data.loadLevel1(blankPos, level1Layer3, color3);
        GameObject[] temp = { GameObject.Find("Canvas1") };
        LayerSwap.loadLevel(1, temp);
    }

    public float[] initialPos;
    public int[] pipeValid;
    public float[,] finalPos;
    int level;

    public void isCorrect()
    {
        bool match = true;
        //Debug.Log(finalPos.GetLength(1));
        //Debug.Log(finalPos.GetLength(0));
        for (int i = 0; i < finalPos.GetLength(1); i++)
        {
            //    if (this.pipeValid[i] == 0)
            //    {
            float[] floats = new float[finalPos.GetLength(0)];
            for (int j = 0; j < finalPos.GetLength(0); j++)
            {
                floats[j] = finalPos[j, i];
            }
            Debug.Log(Array.IndexOf(floats, layer1Data.pipes[i].GetComponent<PipeScript>().curRotation));
            if (Array.IndexOf(floats, layer1Data.pipes[i].GetComponent<PipeScript>().curRotation) == -1)
            {
                match = false;
                break;
            }

        }
        Debug.Log(match);

    }

    public void loadLevelData(int level)
    {
        switch (level)
        {
            case 1:
                level = 1;
                this.initialPos = blankPos;
                this.finalPos = lvl1Answer;
                this.pipeValid = lvl1valid;
                layer1Data.loadLevel1(blankPos, level1Layer1, color1);
                layer2Data.loadLevel1(blankPos, level1Layer2, color2);
                layer3Data.loadLevel1(blankPos, level1Layer3, color3);
                GameObject[] temp = { GameObject.Find("Canvas1") };
                LayerSwap.loadLevel(1, temp);
                break;
            case 2: break;

            case 3: break;

            case 4: break;

            case 5: break;

            default:
                break;
        }
    }

    public static float[] blankPos =
    {
        0, 0, 0, 90, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 90, 0,
        0, 0, 0, 0, 90, 0, 0, 0, 0,
    };
    public static float[,] lvl1Answer =
    {
        { 0, 0, 0, 90, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 90, 0,
        0, 0, 0, 0, 90, 0, 0, 0, 0,},
        {180, 180, 180, 270, 180, 180, 180, 180, 180,
        180, 180, 180, 180, 180, 180, 180, 180, 180,
        180, 180, 180, 180, 180, 180, 180, 180, 180,
        180, 180, 180, 180, 180, 180, 180, 270, 180,
        180, 180, 180, 180, 270, 180, 180, 180, 180,}
    };
    public static int[] lvl1valid =
    {
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };

}
