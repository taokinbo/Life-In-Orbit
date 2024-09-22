using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangePanel : MonoBehaviour
{

    public static ChangePanel Instance { get; private set; }
    [SerializeField]
    public GameObject[] Canvases = { };
   

    public void ShowNewPanel()
    {
        for (int i = 0; i < Canvases.Length; i++)
        {
            int index = Canvases[i].GetComponent<Canvas>().sortingOrder;

            if (index < 4)
            {
                Canvases[i].GetComponent<Canvas>().sortingOrder = index + 1;
            }

            else if (index == 4)
            {
                Canvases[i].GetComponent<Canvas>().sortingOrder = 1;
            }
        }
    }


}
