using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CaptureState : MonoBehaviour
{
    private Select_Panel[] panels;
    // Start is called before the first frame update
    void Start()
    {
        panels = FindObjectsOfType<Select_Panel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Snapshot()
    {
        foreach (Select_Panel panel in panels)
        {

        }
    }
}
