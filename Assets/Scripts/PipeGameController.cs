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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Dictionary<char, (int, int)> pipeDirections = new Dictionary<char, (int, int)>
    {
        {'r', (0,1)},
        {'l', (0,-1)},
        {'u', (-1,0)},
        {'d', (1,0)},
        {' ', (0,0)}
    };

}
