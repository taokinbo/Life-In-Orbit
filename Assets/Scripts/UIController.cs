using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum Scenes {StartMenu, PlayersQuarters, Hallway, CommandCenter, EngineeringBay, Biodome, DialogueUI, TabletMenu, OpeningScene}

public class UIController : MonoBehaviour
{
    public Flags currentFlagToRemove = Flags.None;
    public Flags currentFlagToRun = Flags.None;
    // public TMP_Dropdown dropdown;


    // Start is called before the first frame update
    void Start()
    {
        // dropdown = FindCompoentOfTYpe
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSceneToPlayersQuarters()
    {
        MasterEventSystem.Instance.setLocation(Scenes.PlayersQuarters);
        SceneManager.LoadScene((int)Scenes.PlayersQuarters);
        SceneManager.LoadScene((int)Scenes.DialogueUI, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.TabletMenu, LoadSceneMode.Additive);
    }

    public void ChangeSceneToHallway()
    {
        MasterEventSystem.Instance.setLocation(Scenes.Hallway);
        SceneManager.LoadScene((int)Scenes.Hallway);
        SceneManager.LoadScene((int)Scenes.DialogueUI, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.TabletMenu, LoadSceneMode.Additive);
    }

    public void ChangeSceneToCommandCenter()
    {
        MasterEventSystem.Instance.setLocation(Scenes.CommandCenter);
        SceneManager.LoadScene((int)Scenes.CommandCenter);
        SceneManager.LoadScene((int)Scenes.DialogueUI, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.TabletMenu, LoadSceneMode.Additive);
    }
    public void ChangeSceneToEngineeringBay()
    {
        //Need to add only allow in at certain scenes
        MasterEventSystem.Instance.setLocation(Scenes.EngineeringBay);
        SceneManager.LoadScene((int)Scenes.EngineeringBay);
        SceneManager.LoadScene((int)Scenes.DialogueUI, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.TabletMenu, LoadSceneMode.Additive);
    }

    public void ChangeSceneToBiodome()
    {
        //Need to lock until role is unlocked (but also should only be available at certain scenes)
        MasterEventSystem.Instance.setLocation(Scenes.Biodome);
        SceneManager.LoadScene((int)Scenes.Biodome);
        SceneManager.LoadScene((int)Scenes.DialogueUI, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.TabletMenu, LoadSceneMode.Additive);
    }

    public void ChangeSceneToIntroSeq() {
        MasterEventSystem.Instance.setLocation(Scenes.OpeningScene);
        SceneManager.LoadScene((int)Scenes.OpeningScene);
    }

    public void newGame() {
        // ChangeSceneToPlayersQuarters();
        MasterEventSystem.Instance.stopMusic();
        ChangeSceneToIntroSeq();

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
        SceneManager.LoadScene((int)Scenes.DialogueUI);
    }

    public void cheaterFunc() {
        MasterEventSystem.Instance.cheatNextScene();
    }

    public void markFlag() {
        MasterEventSystem.Instance.removeFlag(currentFlagToRemove);
        MasterEventSystem.Instance.addFlag(currentFlagToRun);
    }

    public void TestSetLocation(TMP_Dropdown dropdown){
        Debug.Log("is setting location");
        MasterEventSystem.Instance.setLocation((Scenes)dropdown.value);
        MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.None);
    }
}
