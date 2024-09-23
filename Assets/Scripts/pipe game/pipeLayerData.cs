using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeLayerData : MonoBehaviour
{
    int[] pipeType;


    public GameObject[] pipes;

    [SerializeField]
    public Sprite[] sprites;


    public void Start()
    {

    }

    public void loadLevel1(float[] initPos, int[] imgData, Color color)
   {
        pipeType = imgData;
        //Debug.Log(this.pipeType[0]);
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].GetComponent<Image>().sprite = sprites[pipeType[i]];
            if (pipeType[i] == 0)
            {
                pipes[i].GetComponent<Image>().color = Color.clear;
            }
            else
            {
                pipes[i].GetComponent<Image>().color = color;
            }
            pipes[i].GetComponent<Transform>().Rotate(new Vector3(0, 0, 0));
            pipes[i].GetComponent<Transform>().Rotate(new Vector3(0, 0, initPos[i]));
            pipes[i].GetComponent<PipeScript>().curRotation = initPos[i];
        }    

    }

    public void init()
    {
        foreach (GameObject pipe in pipes)
        {
            //pipe.GetComponent<Image>().sprite = sprites[0];
            pipe.GetComponent<Transform>().Rotate(new Vector3(0, 0, 0));
            pipe.GetComponent<Image>().color = Color.clear;
        }
    }
}
