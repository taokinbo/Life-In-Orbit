using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public enum Events {
        GameStart = 0,
        Act1Scene1 = 1,
        Act1Scene2 = 2,
        Act1Scene3 = 3,
        Act1Scene4 = 4,
        Act2Scene5 = 5,
        Act2Scene6 = 6,
        Act2Scene7 = 7,
        Act2Scene8 = 8,
        Act2Scene9 = 9,
        Act2Scene10 = 10,
        Act3Scene11 = 11,
        Act3Scene12 = 12,
        Act3Scene13 = 13,
        Act3Scene14 = 14,
        Act4Scene15 = 15,
        Act4Scene16 = 16,
        Act4Scene17 = 17,
        Act5Scene18 = 18,
        Act5Scene19 = 19,
        Act5Scene20 = 20,
        Act5Scene21 = 21,
    };

    public enum EventInfoTypes
    {
        Room, Hallway, CommandCenter, EngineeringBay, Biodome,      // settings
        Lumina, Hawthorn, Pine, Bonnie, Alien,                  // characters
        NameSelection, JobSelection,                                // selections
        AlienActivity,
        None
    };

    public enum Roles {
        Engineer, Biologist, None
    }

public class MasterEventSystem : MonoBehaviour
{

    private EventInfoTypes[] rooms = {EventInfoTypes.Room, EventInfoTypes.CommandCenter, EventInfoTypes.Biodome, EventInfoTypes.EngineeringBay, EventInfoTypes.Hallway};
    private EventInfoTypes[] people = {EventInfoTypes.Lumina, EventInfoTypes.Hawthorn, EventInfoTypes.Pine, EventInfoTypes.Bonnie, EventInfoTypes.Alien};

    private int biologyDifficulty = 0;
    private int engineerDifficulty = 0;
    private string playerName = "";

    private Events currentEvent = Events.GameStart;
    private Roles currentRole = Roles.None;

    Dictionary<Events, Dictionary<EventInfoTypes, bool>> eventInfo = new Dictionary<Events, Dictionary<EventInfoTypes, bool>>();

    public static MasterEventSystem Instance;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // if save file
        // set current event to save value
        // set event dictionary to
        setDefaultEventInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setDefaultEventInfo()
    {
        //Game start
        var currentDict = new Dictionary<EventInfoTypes, bool>();
        eventInfo[Events.GameStart] = currentDict;
        // Act 1 Scene 1
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.Room, true },
            { EventInfoTypes.Lumina, true },
        };
        eventInfo[Events.Act1Scene1] = currentDict;
        // Act 1 Scene 2
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.Hawthorn, true },
        };
        eventInfo[Events.Act1Scene2] = currentDict;
        // Act 1 Scene 3
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.JobSelection, true },
        };
        eventInfo[Events.Act1Scene3] = currentDict;
        // Act 1 Scene 4
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.Hallway, true },
            { EventInfoTypes.Pine, true },
        };
        eventInfo[Events.Act1Scene4] = currentDict;
        // Act 2 Scene 5
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.EngineeringBay, true },
            { EventInfoTypes.Biodome, true },
            { EventInfoTypes.Lumina, true },
        };
        eventInfo[Events.Act2Scene5] = currentDict;
        // Act 2 Scene 6
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.Bonnie, true },
        };
        eventInfo[Events.Act2Scene6] = currentDict;
        // Act 2 Scene 7 (Ascendecy Index Unlocked, will occur through item scripts)
        currentDict = new Dictionary<EventInfoTypes, bool> // TODO: Ask jazz if all rooms need to be explored before next story progression (is preffered if so)
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.Biodome, true },
            { EventInfoTypes.EngineeringBay, true },
            { EventInfoTypes.Room, true },
            { EventInfoTypes.AlienActivity, true },
            { EventInfoTypes.Lumina, true },
            { EventInfoTypes.Pine, true },

        };
        eventInfo[Events.Act2Scene7] = currentDict;
        // Act 2 Scene 8
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.Hawthorn, true },
        };
        eventInfo[Events.Act2Scene8] = currentDict;
        // Act 2 Scene 9
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.EngineeringBay, true },
            { EventInfoTypes.Biodome, true },
            { EventInfoTypes.AlienActivity, true },
        };
        eventInfo[Events.Act2Scene9] = currentDict;
        // Act 2 Scene 10
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.Hallway, true },
            { EventInfoTypes.Pine, true },
        };
        eventInfo[Events.Act2Scene10] = currentDict;

        // Act 3 Scene 11
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.Hawthorn, true },
        };
        eventInfo[Events.Act3Scene11] = currentDict;

        // Act 3 Scene 12
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.EngineeringBay, true },
            {EventInfoTypes.Biodome, true },
            {EventInfoTypes.Lumina, true },
            {EventInfoTypes.AlienActivity, true },
        };
        eventInfo[Events.Act3Scene12] = currentDict;

        // Act 3 Scene 13
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.Biodome, true },
            { EventInfoTypes.EngineeringBay, true },
            { EventInfoTypes.Room, true },
            { EventInfoTypes.Lumina, true },
            { EventInfoTypes.Pine, true },
            { EventInfoTypes.Bonnie, true },
            { EventInfoTypes.Hawthorn, true }

        };
        eventInfo[Events.Act3Scene13] = currentDict;

        // Act 3 Scene 14
        currentDict = new Dictionary<EventInfoTypes, bool> {
            {EventInfoTypes.Room, true },
            {EventInfoTypes.Lumina, true },
        };
        eventInfo[Events.Act3Scene14] = currentDict;

        // Act 4 Scene 15
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.Hawthorn, true },
        };
        eventInfo[Events.Act4Scene15] = currentDict;

        // Act 4 Scene 16
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.EngineeringBay, true },
            {EventInfoTypes.Biodome, true },
            {EventInfoTypes.Lumina, true },
            {EventInfoTypes.Bonnie, true },
            {EventInfoTypes.AlienActivity, true },
        };
        eventInfo[Events.Act4Scene16] = currentDict;

        // Act 4 Scene 17
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.Hallway, true },
            {EventInfoTypes.Pine, true },
            {EventInfoTypes.Hawthorn, true },
            {EventInfoTypes.Lumina, true },
            {EventInfoTypes.Bonnie, true },
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.Room, true },
        };
        eventInfo[Events.Act4Scene17] = currentDict;

        // Act 5 Scene 18
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.Hawthorn, true },
        };
        eventInfo[Events.Act5Scene18] = currentDict;

        // Act 5 Scene 19
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.EngineeringBay, true },
            {EventInfoTypes.Biodome, true },
            {EventInfoTypes.Lumina, true },
            {EventInfoTypes.Bonnie, true },
            {EventInfoTypes.Hawthorn, true },
            {EventInfoTypes.Pine, true },
            {EventInfoTypes.AlienActivity, true },
        };
        eventInfo[Events.Act5Scene19] = currentDict;

        // Act 5 Scene 20
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true},
            {EventInfoTypes.Hawthorn, true },
            {EventInfoTypes.Lumina, true },
            {EventInfoTypes.Bonnie, true },
            {EventInfoTypes.Pine, true },
            {EventInfoTypes.Alien, true },
        };
        eventInfo[Events.Act5Scene20] = currentDict;

        // Act 5 Scene 21
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true },
        };
        eventInfo[Events.Act5Scene21] = currentDict;
    }

    // BE CARE TO NOT CHANGE VALUE WHEN CALLED. THIS EFFECTS SAVE
    public Dictionary<EventInfoTypes, bool> getAllInfoFromScene(){

        return eventInfo[currentEvent];
    }

    public string getAllEventInfo() {
        string json = JsonConvert.SerializeObject(eventInfo, Formatting.Indented);
        return json;
    }

    public IEnumerable<EventInfoTypes> getInfoFromSubsection(EventInfoTypes[] subsection, bool mustBeTrue = false) {
        List <EventInfoTypes> currentItems = new List<EventInfoTypes>();
        var currentEventInfo = eventInfo[currentEvent];

        foreach (var item in subsection){
            if (currentEventInfo.ContainsKey(item) && (!mustBeTrue || currentEventInfo[item])) currentItems.Add(item);
        }
        return currentItems;
    }

    public IEnumerable<EventInfoTypes> getRoomForEvent(bool mustBeUnseen = false) {
        return getInfoFromSubsection(rooms, mustBeUnseen);
    }

    public IEnumerable<EventInfoTypes> getPeopleForEvent(bool mustBeUntalked = false) {
        return getInfoFromSubsection(people, mustBeUntalked);
    }

    public void eventTypeCleared(EventInfoTypes clearedItem) {
        var currentEventInfo = eventInfo[currentEvent];
        if (currentEventInfo.ContainsKey(clearedItem)) {
            currentEventInfo[clearedItem] = false;
            if (clearedItem == EventInfoTypes.EngineeringBay || clearedItem == EventInfoTypes.Biodome) {
                currentEventInfo[EventInfoTypes.EngineeringBay] = false;
                currentEventInfo[EventInfoTypes.Biodome] = false;
            }

            if (isSceneDone()) currentEvent++;
        }
    }

    public EventInfoTypes getMinigameType() {
        var currentEventInfo = eventInfo[currentEvent];
        if (currentRole == Roles.Engineer && currentEventInfo.ContainsKey(EventInfoTypes.EngineeringBay)) return EventInfoTypes.EngineeringBay;
        if (currentRole == Roles.Biologist && currentEventInfo.ContainsKey(EventInfoTypes.Biodome)) return EventInfoTypes.Biodome;
        return EventInfoTypes.None;
    }

    public bool isSceneDone() {
        var currentEventInfo = eventInfo[currentEvent];
        bool notDone = false;
        foreach (var val in currentEventInfo.Values) {
            notDone = notDone || val;
        }
        return notDone;
    }

    public void setRole(Roles role) {
        currentRole= role;
    }

    public Roles getRole() {
        return currentRole;
    }

    public void setPlayerName(string name) {
        playerName = name;
    }

    public string getPlayerName() {
        return playerName;
    }

    public int getDifficulty(Roles role) {
        if (role == Roles.Biologist) return biologyDifficulty;
        if (role == Roles.Engineer) return engineerDifficulty;
        return -1;
    }

    public void setDifficulty(Roles role, int difficulty) {
        if (role == Roles.Biologist) biologyDifficulty = difficulty;
        else if (role == Roles.Engineer) engineerDifficulty = difficulty;
    }

    public Events getCurrentScene() {
        return currentEvent;
    }


    [System.Serializable]
    class SaveData {
        public string playerName;
        public int biologyDifficulty;
        public int engineerDifficulty;
        public Events currentEvent;
        public Roles currentRole;
        public string eventInfo;
        public int score;
    }

    public void Save() {
        SaveData data = new SaveData();
        data.playerName = MasterEventSystem.Instance.getPlayerName();
        data.biologyDifficulty = MasterEventSystem.Instance.getDifficulty(Roles.Biologist);
        data.engineerDifficulty = MasterEventSystem.Instance.getDifficulty(Roles.Engineer);
        data.currentEvent = MasterEventSystem.Instance.getCurrentScene();
        data.currentRole = MasterEventSystem.Instance.getRole();
        data.eventInfo = MasterEventSystem.Instance.getAllEventInfo();

        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // TeamColor = data.TeamColor;
        }
        else {
            Debug.Log("load failed");
        }
    }



}
