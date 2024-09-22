using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLevelData 
{
    public GameObject[] pipes;

    public char[,] initialPos;
    public int[,] pipeValid;
    public char[,] finalPos;
    int level;

    public PipeLevelData(int level)
    {

    }

    public bool isCorrect() 
    {
        for (int i = 0; i < finalPos.GetLength(0); i++)
        {
            for (int j = 0; j < finalPos.GetLength(1); j++)
            {
                if (this.pipeValid[i, j] != 0)
                {
                    if (this.initialPos[i, j] != this.finalPos[i, j])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
