using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes {StartMenu, PlayersQuarters, Hallway, CommandCenter, EngineeringBay, Biodome, Tester}

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
        MasterEventSystem.Instance.setLocation(Scenes.PlayersQuarters);
        SceneManager.LoadScene((int)Scenes.PlayersQuarters);
    }

    public void ChangeSceneToHallway()
    {
        MasterEventSystem.Instance.setLocation(Scenes.Hallway);
        SceneManager.LoadScene((int)Scenes.Hallway);
    }

    public void ChangeSceneToCommandCenter()
    {
        MasterEventSystem.Instance.setLocation(Scenes.CommandCenter);
        SceneManager.LoadScene((int)Scenes.CommandCenter);
    }
    public void ChangeSceneToEngineeringBay()
    {
        MasterEventSystem.Instance.setLocation(Scenes.EngineeringBay);
        SceneManager.LoadScene((int)Scenes.EngineeringBay);
    }

    public void ChangeSceneToBiodome()
    {
        MasterEventSystem.Instance.setLocation(Scenes.Biodome);
        SceneManager.LoadScene((int)Scenes.Biodome);
    }

    public void newGame() {
        ChangeSceneToPlayersQuarters();
    }

    public void loadGame() {
        MasterEventSystem.Instance.Load();
        switch(MasterEventSystem.Instance.getLocation()) {
            case Scenes.PlayersQuarters:
                ChangeSceneToPlayersQuarters();
                break;
            case Scenes.Hallway:
                ChangeSceneToHallway();
                break;
            case Scenes.CommandCenter:
                ChangeSceneToCommandCenter();
                break;
            case Scenes.EngineeringBay:
                ChangeSceneToEngineeringBay();
                break;
            case Scenes.Biodome:
                ChangeSceneToBiodome();
                break;
            default:
                break;
        }
    }

    public void exitGame() {
        Application.Quit();
    }

    public void testerFunc() {
        MasterEventSystem.Instance.setLocation(Scenes.Biodome);
        SceneManager.LoadScene((int)Scenes.Tester);
    }
}
