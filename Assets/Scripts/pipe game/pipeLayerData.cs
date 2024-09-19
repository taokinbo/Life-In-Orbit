using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeLayerData : MonoBehaviour
{
    //public float[] posibleRotations = { 0, 90, 180, 270 };
    int[] pipeType;


    public GameObject[] pipes;

    [SerializeField]
    public Sprite[] sprites;


    public void Start()
    {

    }


    private int[] level1 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };

    public void loadLevel1(char[,] initPos)
   {
        pipeType = level1;
        Debug.Log(this.pipeType[0]);
        for (int i = 0; i < pipes.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(pipeType[i]);
            pipes[i].GetComponent<Image>().sprite = sprites[1];
            Debug.Log(initPos[1, 1]);
        }    

    }
}
