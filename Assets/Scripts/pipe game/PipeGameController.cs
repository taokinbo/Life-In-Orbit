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

   

    //void loadLevel()
    //{
    //    layer1Data.loadLevel1(level1Start, level1Layer1, color1);
    //    layer2Data.loadLevel1(level1Start, level1Layer2, color2);
    //    layer3Data.loadLevel1(level1Start, level1Layer3, color3);
    //    GameObject[] temp = { GameObject.Find("Canvas1") };
    //    LayerSwap.loadLevel(1, temp);
    //}

    public float[] initialPos;
    public int[] pipeValid;
    public float[,] finalPos;
    int level;
    public int attempts;

    public void isCorrect()
    {
        attempts += 1;
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
                Debug.Log(i);
                Debug.Log(layer1Data.pipes[i].GetComponent<PipeScript>().curRotation);
                match = false;
                break;
            }

        }
        Debug.Log(match);
        if (match == true)
        {
            level = level + 1;
            Debug.Log(level);
            loadLevelData(level);
        }
        else
        {
            Debug.Log("try again!");
        }

    }

    public void loadLevelData(int level)
    {
        switch (level)
        {
            case 1:
                level = 1;
                this.initialPos = level1Start;
                this.finalPos = lvl1Answer;
                this.pipeValid = lvl1valid;
                layer1Data.loadLevel1(level1Start, level1Layer1, color1);
                layer2Data.loadLevel1(level1Start, level1Layer2, color2);
                layer3Data.loadLevel1(level1Start, level1Layer3, color3);
                GameObject[] temp2 = { GameObject.Find("Canvas1") };
                LayerSwap.loadLevel(1, temp2);
                break;
            case 2:
                level = 1;
                this.initialPos = level1Start;
                this.finalPos = lvl1Answer;
                this.pipeValid = lvl1valid;
                layer1Data.loadLevel1(level1Start, level1Layer1, color1);
                layer2Data.loadLevel1(level1Start, level1Layer2, color2);
                layer3Data.loadLevel1(level1Start, level1Layer3, color3);
                GameObject[] temp = { GameObject.Find("Canvas1") };
                LayerSwap.loadLevel(1, temp);
                break;

            case 3: break;

            case 4: break;

            case 5: break;

            default:
                break;
        }
    }
    // level1
    private int[] level1Layer1 = {
        2, 0, 2, 0, 2, 1, 1, 2, 0,
        0, 3, 1, 1, 1, 1, 1, 2, 0,
        1, 2, 1, 1, 1, 1, 1, 2, 1,
        4, 2, 0, 3, 2, 1, 1, 2, 1,
        1, 0, 0, 1, 1, 1, 1, 1, 1,
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
    public static float[] level1Start =
    {
        0, 0, 0, 0, 180, 0, 90, 0, 0,
        0, 0, 90, 180, 0, 0, 180, 90, 0,
        0, 0, 0, 0, 0, 0, 90, 0, 0,
        0, 0, 0, 0, 270, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };
    public static float[,] lvl1Answer =
    {
        { 
        0,   0,  0,  0,   0,  0,  0,  180,  0,
        0, 180,  0,  0,   0,  0,  0,   90,  0,
        0,   0,  0,  0,   0,  0,  0,  180,  0,
        0,   0,  0,  0, 270,  0,  0,   90,  0,
        0,   0,  0,  0,  90,  0,  0,    0,  0,},
        {
        0,   0,  0,  0,   0,  180, 180, 180,  0,
        0, 180, 180, 180,  180,  180, 180,  90,  0,
        0,   0, 180, 180,  180,  180, 180, 180,  0,
        0,   0,  0,  0, 270,  180, 180,  90,  0,
        0,   0,  0,  0, 270,   0,  0,   0,  0,},
        {
        0,   0,  0,  0,   0,  0,  0,  180,  0,
        0, 270,  0,  0,   0,  0,  0,   90,  0,
        0,   0,  0,  0,   0,  0,  0,  180,  0,
        0,   0,  0,  0, 270,  0,  0,   90,  0,
        0,   0,  0,  0, 270,  0,  0,    0,  0,},
    };
    public static int[] lvl1valid =
    {
        1, 1, 1, 1, 0, 0, 0, 0, 1,
        1, 0, 0, 0, 0, 0, 0, 0, 1,
        1, 0, 0, 0, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 0, 1, 1, 1, 1,
    };

}
