using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneToPlayersQuarters()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeSceneToHallway()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeSceneToCommandCenter()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeSceneToEngineeringBay()
    {
        SceneManager.LoadScene(3);
    }

    public void ChangeSceneToBiodome()
    {
        SceneManager.LoadScene(4);
    }
}
