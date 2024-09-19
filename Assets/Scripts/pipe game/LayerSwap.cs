using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LayerSwap : MonoBehaviour
{

    public static LayerSwap Instance { get; private set; }
    [SerializeField]
    public GameObject[] Canvases = { };
    int layers;

    public void ShowNewMenu()
    {
        for (int i = 0; i < Canvases.Length; i++)
        {
            int index = Canvases[i].GetComponent<Canvas>().sortingOrder;
            
            if (index < layers)
            {
                Canvases[i].GetComponent<Canvas>().sortingOrder = index + 1;
            }

            else if (index == layers)
            {
                Canvases[i].GetComponent<Canvas>().sortingOrder = 1;
            }
        }
    }

    public void loadLevel(int layer, GameObject[] selectedCanvases)
    {
        layers = layer; 
        Canvases = selectedCanvases;
        for (int i = 0;i < Canvases.Length;i++)
        {
            Canvases[i].GetComponent<Canvas>().sortingOrder = i + 1;
        }
    }

}
