using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PipeGameController : MonoBehaviour
{
    //level1
    public PipeLayerData layer1Data;

////level2
    PipeLayerData layer2Data;

    public LayerSwap LayerSwap;
    // Start is called before the first frame update
    void Start()
    {
        loadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadLevel()
    {
        layer1Data.loadLevel1(blankPos);
        GameObject[] temp = { GameObject.Find("Canvas1"), GameObject.Find("Canvas2") };
        LayerSwap.loadLevel(2, temp);
    }


    public float[] initialPos;
    public int[] pipeValid;
    public float[] finalPos;
    int level;

    public void gameLevelData(int level)
    {
        switch (level)
        {
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            default:
                break;
        }
    }

    public bool isCorrect()
    {
        for (int i = 0; i < finalPos.GetLength(0); i++)
        {
                if (this.pipeValid[i] != 0)
                {
                if (this.layer1Data.pipes[i].GetComponent<PipeScript>().curRotation != this.finalPos[i])
                    
                    {
                        return false;
                    }
                }
        }
        return true;
    }


    public static char[,] blankPos =
    {
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
    };
}
