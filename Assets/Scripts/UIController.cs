using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public enum Scenes {StartMenu, PlayersQuarters, Hallway, CommandCenter, EngineeringBay, Biodome, Tester}

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
        MasterEventSystem.Instance.setLocation(EventInfoTypes.PlayersQuarters);
        SceneManager.LoadScene((int)Scenes.PlayersQuarters);
    }

    public void ChangeSceneToHallway()
    {
        MasterEventSystem.Instance.setLocation(EventInfoTypes.Hallway);
        SceneManager.LoadScene((int)Scenes.Hallway);
    }

    public void ChangeSceneToCommandCenter()
    {
        MasterEventSystem.Instance.setLocation(EventInfoTypes.CommandCenter);
        SceneManager.LoadScene((int)Scenes.CommandCenter);
    }
    public void ChangeSceneToEngineeringBay()
    {
        MasterEventSystem.Instance.setLocation(EventInfoTypes.EngineeringBay);
        SceneManager.LoadScene((int)Scenes.EngineeringBay);
    }

    public void ChangeSceneToBiodome()
    {
        MasterEventSystem.Instance.setLocation(EventInfoTypes.Biodome);
        SceneManager.LoadScene((int)Scenes.Biodome);
    }

    public void newGame() {
        ChangeSceneToPlayersQuarters();
    }

    public void loadGame() {
        MasterEventSystem.Instance.Load();
        switch(MasterEventSystem.Instance.getLocation()) {
            case EventInfoTypes.PlayersQuarters:
                ChangeSceneToPlayersQuarters();
                break;
            case EventInfoTypes.Hallway:
                ChangeSceneToHallway();
                break;
            case EventInfoTypes.CommandCenter:
                ChangeSceneToCommandCenter();
                break;
            case EventInfoTypes.EngineeringBay:
                ChangeSceneToEngineeringBay();
                break;
            case EventInfoTypes.Biodome:
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
        MasterEventSystem.Instance.setLocation(EventInfoTypes.Biodome);
        SceneManager.LoadScene((int)Scenes.Tester);
    }
}
