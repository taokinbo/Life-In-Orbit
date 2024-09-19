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

    public void loadLevel1(char[,] initPos, int[] imgData)
   {
        pipeType = imgData;
        Debug.Log(this.pipeType[0]);
        for (int i = 0; i < pipes.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(pipeType[i]);
            pipes[i].GetComponent<Image>().sprite = sprites[pipeType[i]];
            if (pipeType[i] == 0)
            {
                pipes[i].GetComponent<Image>().color = Color.clear;
            }
            Debug.Log(initPos[1, 1]);
        }    

    }
}
