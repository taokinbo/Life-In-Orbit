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

   
    public float[] initialPos;
    public int[] pipeValid;
    public float[,] finalPos;
    int level;
    public int attempts;

    public void isCorrect()
    {
        attempts += 1;
        bool match = true;
        for (int i = 0; i < finalPos.GetLength(1); i++)
        {
            if (this.pipeValid[i] == 0)
            {
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

        }
        Debug.Log(match);
        if (match == true)
        {
            Debug.Log(this.level);
            this.level = this.level + 1;
            Debug.Log(this.level);
            loadLevelData(this.level);
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
                this.level = 1;
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
                this.level = 2;
                this.initialPos = level2Start;
                this.finalPos = lvl2Answer;
                this.pipeValid = lvl2valid;
                layer1Data.loadLevel1(level2Start, level2Layer1, color1);
                layer2Data.loadLevel1(level2Start, level2Layer2, color2);
                layer3Data.loadLevel1(level2Start, level2Layer3, color3);
                GameObject[] temp = { GameObject.Find("Canvas1") };
                LayerSwap.loadLevel(1, temp);
                break;

            case 3: 
                this.level = 3;
                this.initialPos = level3Start;
                this.finalPos = lvl3Answer;
                this.pipeValid = lvl3valid;
                layer1Data.loadLevel1(level3Start, level3Layer1, color1);
                layer2Data.loadLevel1(level3Startlayer2, level3Layer2, color2);
                layer3Data.loadLevel1(level3Start, level3Layer3, color3);
                GameObject[] temp3 = { GameObject.Find("Canvas1"), GameObject.Find("Canvas2") };
                LayerSwap.loadLevel(2, temp3);
                break;
            case 4: break;

            case 5: break;

            default:
                break;
        }
    }

    // level1
    //the image of the pipe on the layer
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
    //starting angles
    public static float[] level1Start =
    {
        0,   0,   0,   0, 180,   0,  90,   0,   0,
        0,   0,  90, 180,   0,   0, 180,  90,   0,
        0,   0,   0,   0,   0,   0,  90,   0,   0,
        0,   0,   0,   0, 270,   0,   0,   0,   0,
        0,   0,   0,   0,   0,   0,   0,   0,   0,
    };
    //there are multiple possible answers sometimes because visually on a straight pipe a 90 is the same as 270 etc.
    public static float[,] lvl1Answer =
    {
        { 
        0,   0,   0,   0,   0,   0,   0,  180,  0,
        0, 180,   0,   0,   0,   0,   0,   90,  0,
        0,   0,   0,   0,   0,   0,   0,  180,  0,
        0,   0,   0,   0, 270,   0,   0,   90,  0,
        0,   0,   0,   0,  90,   0,   0,    0,  0,},
        {
        0,   0,   0,   0,   0, 180, 180, 180,   0,
        0, 270, 180, 180, 180, 180, 180,  90,   0,
        0,   0, 180, 180, 180, 180, 180, 180,   0,
        0,   0,   0,   0, 270, 180, 180,  90,   0,
        0,   0,   0,   0, 270,   0,   0,   0,   0,},
    };
    //which squares need to be checked for this to be correct (avoids wasting time trying to create answers for all the extraneous pipes that dont matter)
    public static int[] lvl1valid =
    {
        1, 1, 1, 1, 0, 0, 0, 0, 1,
        1, 0, 0, 0, 0, 0, 0, 0, 1,
        1, 0, 0, 0, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 0, 1, 1, 1, 1,
    };



    // level 2
    private int[] level2Layer1 = {
        3, 2, 2, 2, 1, 2, 4, 1, 4,
        0, 2, 1, 1, 2, 2, 3, 2, 0,
        2, 3, 2, 2, 1, 1, 1, 1, 2,
        1, 2, 1, 3, 2, 2, 1, 2, 1,
        1, 2, 0, 2, 1, 2, 4, 2, 1,
    };
    private int[] level2Layer2 = {
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };
    private int[] level2Layer3 = {
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };
    public static float[] level2Start =
    {
        0,   0,   0,   0, 180,   0,  90,   0,   0,
        0,   0,  90, 180,   0,   0, 180,  90,   0,
        0,   0,   0,   0,   0,   0,  90,   0,   0,
        0,   0,   0,   0, 270,   0,   0,   0,   0,
        0,   0,   0,   0,   0,   0,   0,   0,   0,
    };
    public static float[,] lvl2Answer =
    {
        {
        0,   0,   0,   0,  90,   0,   0,   0,   0,
        0,  90,   0,   0,  90,   0,   0,   0,   0,
      270,  90,   0, 270,   0,   0,   0,   0, 180,
       90,   0,   0,   0, 180,   0,   0,   0,  90,
       90,   0,   0,   0,  90,   0,   0,   0,  90,},
        {
        0,   0,   0,   0, 270,   0,   0,   0,   0,
        0,  90, 180, 180,  90,   0,   0,   0,   0,
      270,  90,   0, 270, 180, 180, 180, 180, 180,
      270,   0, 180,   0, 180,   0,   0,   0, 270,
      270,   0,   0,   0, 270,   0,   0,   0, 270,},
    };
    public static int[] lvl2valid =
    {
        1, 1, 1, 1, 0, 1, 1, 1, 1,
        1, 0, 0, 0, 0, 1, 1, 1, 1,
        0, 0, 1, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 0, 1, 1, 1, 0,
    };


    // level3
    private int[] level3Layer1 = {
        0, 0, 0, 0, 2, 2, 0, 0, 2,
        3, 0, 2, 0, 1, 2, 2, 0, 0,
        4, 1, 0, 2, 2, 1, 3, 1, 0,
        2, 1, 1, 1, 3, 0, 1, 0, 1,
        1, 0, 0, 0, 1, 0, 2, 1, 2,
    };
    private int[] level3Layer2 = {
        0, 0, 0, 0, 1, 0, 0, 0, 4,
        0, 0, 0, 0, 1, 2, 3, 0, 0,
        2, 1, 1, 3, 3, 1, 2, 1, 0,
        1, 2, 0, 1, 1, 0, 2, 1, 2,
        1, 0, 0, 2, 2, 0, 4, 0, 1,
    };
    private int[] level3Layer3 = {
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0,
    };
    public static float[] level3Start =
    {
        0,   0,   0,   0, 180,   0,  90,   0,   0,
        0,   0,  90, 180,   0,   0, 180,  90,   0,
        0,   0,   0,   0,   0,   0,  90,   0,   0,
        0,   0,   0,   0, 270,   0,   0,   0,   0,
        0,   0,   0,   0,   0,   0,   0,   0,   0,
    };
    public static float[] level3Startlayer2 =
   {
        0,   0,   0,   0, 270,   0,   0,   0,   0,
        0,   0,   0,   0,  90,  90,   0,   0,   0,
        0,   0,   0,   0, 090,   0, 180,   0,   0,
        0,   0,   0,  90,   0,   0, 270,   0,   0,
        0,   0,   0,   0, 270,   0,   0,   0,  90,
    };
    public static float[,] lvl3Answer =
    {
        {
        0,   0,   0,   0,   0, 180,   0,   0,   0,
        0,   0,   0,   0,   0,   0, 180,   0,   0,
      270,   0,   0, 180, 270,   0,  90,   0,   0,
      270,   0,   0,   0,  90,   0,  90,   0, 180,
       90,   0,   0,   0, 270,   0,   0,   0, 180,},
        {
        0,   0,   0,   0,   0, 180,   0,   0,   0,
        0,   0,   0,   0, 180,   0, 180,   0,   0,
      270,   0,   0, 180, 270,   0,  90,   0,   0,
      270, 180, 180, 180,  90,   0,  90,   0, 180,
      270,   0,   0,   0, 270,   0,   0, 180, 180,},
    };
    public static int[] lvl3valid =
    {
        1, 1, 1, 1, 0, 0, 1, 1, 1,
        1, 1, 1, 1, 0, 0, 0, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 1, 1,
        0, 0, 0, 0, 0, 1, 0, 0, 0,
        0, 1, 1, 0, 0, 1, 0, 0, 0,
    };


//    base copy
//    0, 0, 0, 0, 0, 0, 0, 0, 0,
//    0, 0, 0, 0, 0, 0, 0, 0, 0,
//    0, 0, 0, 0, 0, 0, 0, 0, 0,
//    0, 0, 0, 0, 0, 0, 0, 0, 0,
//    0, 0, 0, 0, 0, 0, 0, 0, 0,
//   
}
