using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PipeGameController : MonoBehaviour
{
    //level1
    PipeLevelData level1Data = new PipeLevelData(1);

    //level2
    PipeLevelData level2Data = new PipeLevelData(2);

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
        GameObject[] temp = { GameObject.Find("Canvas1"), GameObject.Find("Canvas2") };
        LayerSwap.loadLevel(2, temp);
    }
}
