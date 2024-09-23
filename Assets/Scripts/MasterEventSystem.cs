using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public enum Events
{
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
    None,
    PlayersQuarters, Hallway, CommandCenter, EngineeringBay, Biodome,      // settings
    Lumina, Hawthorn, Pine, Bonnie, Alien,                  // characters
    NameSelection, JobSelection,                                // selections
    OpenTablet, OpenDirectory, OpenResearch, OpenExitGame, //tablet
    AlienActivity, AscendecyIndex, RelationshipUpdated
};

public enum Roles
{
    Engineer, Biologist, None
}

public enum Flags
{
    None,
    Test1, Test2, // TODO: remove test1 and test 2
    HawthornLike, HawthornDislike, PineLike, PineDislike, BonnieLike, BonnieDislike,
    SupportHawthorn, SupportBonnie,
    RoleEngineer, RoleBiologist,
    Minigame1Start, MG1Tut, MG1F1, MG1F2, MG1F3, MG1F4, MG1F5, MG1F6, MG1Complete, MG1Pass, MG1Fail,
    PineAskHawthorn, PineAskLumina, PineAskBonnie,
    BonnieAskAlien, BonnieAskHawthorn, BonnieAskPine,
    HawthornAskPine, HawthornAskAlien, HawthornAskBonnie,
    HawthornLikePlus, HawthornDislikePlus, PineLikePlus, PineDislikePlus, BonnieLikePlus, BonnieDislikePlus,
    BonnieHint, BonnieNoHint,
    AiHigh, AiLow, AiHighHawthorn, AiLowHawthorn, AiHighBonnie, AiLowBonnie,
    PineHint, PineNoHint,
    AIHighLikePlus, AIHighLike, AIHighDislike, AIHighDislikePlus, AILowLikePlus, AILowLike, AILowDislike, AILowDislikePlus,
}

public class MasterEventSystem : MonoBehaviour
{

    private readonly EventInfoTypes[] rooms = { EventInfoTypes.PlayersQuarters, EventInfoTypes.CommandCenter, EventInfoTypes.Biodome, EventInfoTypes.EngineeringBay, EventInfoTypes.Hallway, EventInfoTypes.AscendecyIndex };
    private readonly EventInfoTypes[] people = { EventInfoTypes.Lumina, EventInfoTypes.Hawthorn, EventInfoTypes.Pine, EventInfoTypes.Bonnie, EventInfoTypes.Alien };

    private int biologyDifficulty = 0;
    private int engineerDifficulty = 0;
    private string playerName = "Aster";

    private Events currentEvent = Events.GameStart;
    private Roles currentRole = Roles.None;
    private Scenes curentLocation;

    private int pointsHawthorn = 0;
    private int pointsPine = 0;
    private int pointsBonnie = 0;
    private int extreamRelationship = 6;

    Dictionary<Events, Dictionary<EventInfoTypes, bool>> eventInfo = new Dictionary<Events, Dictionary<EventInfoTypes, bool>>();
    HashSet<Flags> flags = new HashSet<Flags>(){
        Flags.HawthornDislike, Flags.PineDislike, Flags.BonnieDislike, Flags.Minigame1Start, Flags.BonnieNoHint, Flags.PineNoHint,
    };

    public static MasterEventSystem Instance;

    public delegate void EventInfoChangeHandler(Events newEvent);
    public event EventInfoChangeHandler OnEventInfoChnaged;



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
        setDefaultEventInfo();

    }

    // Start is called before the first frame update
    void Start()
    {
        // if save file
        // set current event to save value
        // set event dictionary to
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Scenes getLocation()
    {
        return curentLocation;
    }

    public void setLocation(Scenes location)
    {
        curentLocation = location;
        EventInfoTypes roomEvent;
        switch (location) {
            case Scenes.PlayersQuarters:
                roomEvent = EventInfoTypes.PlayersQuarters;
                break;
            case Scenes.Hallway:
                roomEvent = EventInfoTypes.Hallway;
                break;
            case Scenes.CommandCenter:
                roomEvent = EventInfoTypes.CommandCenter;
                break;
            case Scenes.EngineeringBay:
                roomEvent = EventInfoTypes.EngineeringBay;
                break;
            case Scenes.Biodome:
                roomEvent = EventInfoTypes.Biodome;
                break;
            default:
                roomEvent = EventInfoTypes.None;
                break;
        }
        eventTypeCleared(roomEvent);
        Save();
    }

    private void setDefaultEventInfo()
    {
        //Game start
        // var currentDict = new Dictionary<EventInfoTypes, bool>();
        var currentDict = new Dictionary<EventInfoTypes, bool>()
        {
            // { EventInfoTypes.Hawthorn, true} // TODO: REMOVE AFTER DONE WITH TESTING
        };
        eventInfo[Events.GameStart] = currentDict;
        // Act 1 Scene 1
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.PlayersQuarters, true },
            { EventInfoTypes.Lumina, true },
            // { EventInfoTypes.Hawthorn, true}, // TODO: remove after done with testing
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
            { EventInfoTypes.Lumina, true},
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
        currentDict = new Dictionary<EventInfoTypes, bool> // TODO: Ask jazz if all PlayersQuarterss need to be explored before next story progression (is preffered if so)
        {
            { EventInfoTypes.CommandCenter, true },
            { EventInfoTypes.Biodome, true },
            { EventInfoTypes.EngineeringBay, true },
            { EventInfoTypes.PlayersQuarters, true },
            { EventInfoTypes.AlienActivity, true },
            { EventInfoTypes.Lumina, true },

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
            { EventInfoTypes.Lumina, true },
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
            // { EventInfoTypes.Biodome, true },
            // { EventInfoTypes.EngineeringBay, true },
            // { EventInfoTypes.PlayersQuarters, true },
            // { EventInfoTypes.Lumina, true },
            { EventInfoTypes.Pine, true },
            { EventInfoTypes.Bonnie, true },
            { EventInfoTypes.Hawthorn, true }

        };
        eventInfo[Events.Act3Scene13] = currentDict;

        // Act 3 Scene 14
        currentDict = new Dictionary<EventInfoTypes, bool> {
            {EventInfoTypes.PlayersQuarters, true },
            {EventInfoTypes.Lumina, true },
        };
        eventInfo[Events.Act3Scene14] = currentDict;

        // Act 4 Scene 15
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.Hawthorn, true },
            {EventInfoTypes.Lumina, true },
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
            {EventInfoTypes.Bonnie, true },
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.PlayersQuarters, true },
        };
        eventInfo[Events.Act4Scene17] = currentDict;

        // Act 5 Scene 18
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.CommandCenter, true },
            {EventInfoTypes.Hawthorn, true },
            {EventInfoTypes.Lumina, true },
        };
        eventInfo[Events.Act5Scene18] = currentDict;

        // Act 5 Scene 19
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            {EventInfoTypes.EngineeringBay, true },
            {EventInfoTypes.Biodome, true },
            {EventInfoTypes.Lumina, true },
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
    public Dictionary<EventInfoTypes, bool> getAllInfoFromScene()
    {

        return eventInfo[currentEvent];
    }

    public string getAllEventInfo()
    {
        string json = JsonConvert.SerializeObject(eventInfo, Formatting.Indented);
        return json;
    }

    private void setAllEventInfo(string json)
    {
        eventInfo = JsonConvert.DeserializeObject<Dictionary<Events, Dictionary<EventInfoTypes, bool>>>(json);
    }

    public string getAllFlags()
    {
        return JsonConvert.SerializeObject(flags, Formatting.Indented);
    }

    public void setAllFlags(string json)
    {
        flags = JsonConvert.DeserializeObject<HashSet<Flags>>(json);
    }

    public void addFlag(Flags newFlag)
    {
        if (newFlag == Flags.None) return;

        flags.Add(newFlag);
        Debug.Log("Flag Added: " + newFlag);
        if (newFlag == Flags.SupportBonnie) {
            if (checkFlag(Flags.AiHigh)) flags.Add(Flags.AiHighBonnie);
            else flags.Add(Flags.AiLowBonnie);
        }
        if (newFlag == Flags.SupportHawthorn) {
            if (checkFlag(Flags.AiHigh)) flags.Add(Flags.AiHighHawthorn);
            else flags.Add(Flags.AiLowHawthorn);
        }
        eventTypeCleared(EventInfoTypes.None);
    }

    public void removeFlag(Flags newFlag)
    {
        flags.Remove(newFlag);
    }

    public bool checkFlag(Flags flag)
    {
        return flags.Contains(flag);
    }

    public IEnumerable<EventInfoTypes> getInfoFromSubsection(EventInfoTypes[] subsection, bool mustBeTrue = false)
    {
        List<EventInfoTypes> currentItems = new List<EventInfoTypes>();
        var currentEventInfo = eventInfo[currentEvent];

        foreach (var item in subsection)
        {
            if (currentEventInfo.ContainsKey(item) && (!mustBeTrue || currentEventInfo[item])) currentItems.Add(item);
        }
        return currentItems;
    }

    public IEnumerable<EventInfoTypes> getPlayersQuartersForEvent(bool mustBeUnseen = false)
    {
        return getInfoFromSubsection(rooms, mustBeUnseen);
    }

    public IEnumerable<EventInfoTypes> getPeopleForEvent(bool mustBeUntalked = false)
    {
        return getInfoFromSubsection(people, mustBeUntalked);
    }

    public void eventTypeCleared(EventInfoTypes clearedItem)
    {
        var currentEventInfo = eventInfo[currentEvent];
        if (currentEventInfo.ContainsKey(clearedItem))
        {
            currentEventInfo[clearedItem] = false;
            if (clearedItem == EventInfoTypes.EngineeringBay || clearedItem == EventInfoTypes.Biodome)
            {
                currentEventInfo[EventInfoTypes.EngineeringBay] = false;
                currentEventInfo[EventInfoTypes.Biodome] = false;
            }
        }
        if (isSceneDone())
        {
            currentEvent++;
            setLocation(curentLocation);
            Save();
        }
        else
        {
            Debug.Log("Scene is not done: ");
            Debug.Log(getAllInfoFromScene());
        }

        OnEventInfoChnaged?.Invoke(currentEvent);
    }

    public EventInfoTypes getMinigameType()
    {
        var currentEventInfo = eventInfo[currentEvent];
        if (currentRole == Roles.Engineer && currentEventInfo.ContainsKey(EventInfoTypes.EngineeringBay)) return EventInfoTypes.EngineeringBay;
        if (currentRole == Roles.Biologist && currentEventInfo.ContainsKey(EventInfoTypes.Biodome)) return EventInfoTypes.Biodome;
        return EventInfoTypes.None;
    }

    public int getMinigameLevel()
    {
        int curScene = (int)currentEvent;

        if (curScene <= 5) return 0;
        if (curScene <= 9) return 1;
        if (curScene <= 12) return 2;
        if (curScene <= 16) return 3;
        if (curScene <= 19) return 4;
        else return -1;

    }

    public bool isSceneDone()
    {
        var currentEventInfo = eventInfo[currentEvent];
        bool notDone = false;
        foreach (var val in currentEventInfo.Values)
        {
            notDone = notDone || val;
        }
        return !notDone;
    }

    public void setRole(Roles role)
    {
        currentRole = role;
    }

    public Roles getRole()
    {
        return currentRole;
    }

    public void setPlayerName(string name)
    {
        playerName = name;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    public int getDifficulty(Roles role)
    {
        if (role == Roles.Biologist) return biologyDifficulty;
        if (role == Roles.Engineer) return engineerDifficulty;
        return -1;
    }

    public void setDifficulty(Roles role, int difficulty)
    {
        if (role == Roles.Biologist) biologyDifficulty = difficulty;
        else if (role == Roles.Engineer) engineerDifficulty = difficulty;
    }

    public Events getCurrentEvent()
    {
        return currentEvent;
    }

    private void setCurrentEvent(Events scene)
    {
        currentEvent = scene;
    }

    public void cheatNextScene()
    {
        currentEvent++;
        Save();
        OnEventInfoChnaged?.Invoke(currentEvent);
    }

    private void removeAIRelationshipFlags() {
        flags.Remove(Flags.AIHighDislike);
        flags.Remove(Flags.AIHighDislike);
        flags.Remove(Flags.AIHighLikePlus);
        flags.Remove(Flags.AIHighLike);
        flags.Remove(Flags.AILowDislike);
        flags.Remove(Flags.AILowDislike);
        flags.Remove(Flags.AILowLikePlus);
        flags.Remove(Flags.AILowLike);
    }

    public void changePoints(EventInfoTypes character, int pointChange)
    {
        switch (character)
        {
            case EventInfoTypes.Hawthorn:
                Debug.Log("hawthorn points changed from: " + pointsHawthorn);
                pointsHawthorn += pointChange;
                Debug.Log("-> to " + pointsHawthorn);
                removeAIRelationshipFlags();
                bool isFlagHigh = checkFlag(Flags.AiHigh);
                if (pointsHawthorn > 0)
                {
                    removeFlag(Flags.HawthornDislike);
                    removeFlag(Flags.HawthornDislikePlus);
                    addFlag(Flags.HawthornLike);
                    if (pointsHawthorn > extreamRelationship) {
                        flags.Add(Flags.HawthornLikePlus);
                        flags.Add(isFlagHigh? Flags.AIHighLikePlus : Flags.AILowLikePlus);
                    }
                    else flags.Remove(Flags.HawthornLikePlus);
                    flags.Add(isFlagHigh? Flags.AIHighLike : Flags.AILowLike);


                }
                else
                {
                    removeFlag(Flags.HawthornLike);
                    removeFlag(Flags.HawthornLikePlus);
                    addFlag(Flags.HawthornDislike);
                    if (pointsHawthorn < -1 * extreamRelationship) {
                        flags.Add(Flags.HawthornDislikePlus);
                        flags.Add(isFlagHigh? Flags.AIHighDislikePlus : Flags.AILowDislikePlus);
                    }
                    else flags.Remove(Flags.HawthornDislikePlus);
                    flags.Add(isFlagHigh? Flags.AIHighDislike : Flags.AILowDislike);

                }
                break;
            case EventInfoTypes.Pine:
                Debug.Log("Pine points changed from: " + pointsPine);
                pointsPine += pointChange;
                Debug.Log("-> to " + pointsPine);
                if (pointsPine > 0)
                {
                    removeFlag(Flags.PineDislike);
                    removeFlag(Flags.PineDislikePlus);
                    removeFlag(Flags.PineNoHint);
                    flags.Add(Flags.PineHint);
                    addFlag(Flags.PineLike);
                    if (pointsPine > extreamRelationship) flags.Add(Flags.PineLikePlus);
                    else flags.Remove(Flags.PineLikePlus);
                }
                else
                {
                    removeFlag(Flags.PineLike);
                    removeFlag(Flags.PineLikePlus);
                    removeFlag(Flags.PineHint);
                    flags.Add(Flags.PineNoHint);
                    addFlag(Flags.PineDislike);
                    if (pointsPine < -1 * extreamRelationship) flags.Add(Flags.PineDislikePlus);
                    else flags.Remove(Flags.PineDislikePlus);
                }
                break;
            case EventInfoTypes.Bonnie:
                Debug.Log("Bonnie points changed from: " + pointsBonnie);
                pointsBonnie += pointChange;
                Debug.Log("-> to " + pointsBonnie);
                if (pointsBonnie > 0)
                {
                    removeFlag(Flags.BonnieDislike);
                    removeFlag(Flags.BonnieDislikePlus);
                    removeFlag(Flags.BonnieNoHint);
                    flags.Add(Flags.BonnieHint);
                    addFlag(Flags.BonnieLike);
                    if (pointsBonnie > extreamRelationship) flags.Add(Flags.BonnieLikePlus);
                    else flags.Remove(Flags.BonnieLikePlus);
                }
                else
                {
                    removeFlag(Flags.BonnieLike);
                    removeFlag(Flags.BonnieLikePlus);
                    removeFlag(Flags.BonnieHint);
                    flags.Add(Flags.BonnieNoHint);
                    addFlag(Flags.BonnieDislike);
                    if (pointsBonnie < -1 * extreamRelationship) flags.Add(Flags.BonnieDislikePlus);
                    else flags.Remove(Flags.BonnieDislikePlus);
                }
                break;
            default:
                break;
        }
    }

    public void setRelationshipPoints(EventInfoTypes character, int point)
    {
        switch (character)
        {
            case EventInfoTypes.Hawthorn:
                pointsHawthorn = point;
                break;
            case EventInfoTypes.Pine:
                pointsPine = point;
                break;
            case EventInfoTypes.Bonnie:
                pointsBonnie = point;
                break;
            default:
                break;
        }
    }

    public int getRelationshipPoints(EventInfoTypes character)
    {
        switch (character)
        {
            case EventInfoTypes.Hawthorn:
                return pointsHawthorn;
            case EventInfoTypes.Pine:
                return pointsPine;
            case EventInfoTypes.Bonnie:
                return pointsBonnie;
            default:
                return 0;
        }
    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int biologyDifficulty;
        public int engineerDifficulty;
        public Events currentEvent;
        public Roles currentRole;
        public string eventInfo;
        public int score;
        public Scenes location;
        public int pointsHawthorn;
        public int pointsPine;
        public int pointsBonnie;
        public string flags;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = MasterEventSystem.Instance.getPlayerName();
        data.biologyDifficulty = MasterEventSystem.Instance.getDifficulty(Roles.Biologist);
        data.engineerDifficulty = MasterEventSystem.Instance.getDifficulty(Roles.Engineer);
        data.currentEvent = MasterEventSystem.Instance.getCurrentEvent();
        data.currentRole = MasterEventSystem.Instance.getRole();
        data.eventInfo = MasterEventSystem.Instance.getAllEventInfo();
        data.location = MasterEventSystem.Instance.getLocation();
        data.pointsHawthorn = MasterEventSystem.Instance.getRelationshipPoints(EventInfoTypes.Hawthorn);
        data.pointsPine = MasterEventSystem.Instance.getRelationshipPoints(EventInfoTypes.Pine);
        data.pointsBonnie = MasterEventSystem.Instance.getRelationshipPoints(EventInfoTypes.Bonnie);
        data.flags = MasterEventSystem.Instance.getAllFlags();

        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("saving...");
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(json);
            MasterEventSystem.Instance.setPlayerName(data.playerName);
            MasterEventSystem.Instance.setDifficulty(Roles.Biologist, data.biologyDifficulty);
            MasterEventSystem.Instance.setDifficulty(Roles.Engineer, data.engineerDifficulty);
            MasterEventSystem.Instance.setCurrentEvent(data.currentEvent);
            MasterEventSystem.Instance.setRole(data.currentRole);
            MasterEventSystem.Instance.setAllEventInfo(data.eventInfo);
            MasterEventSystem.Instance.setLocation(data.location);
            MasterEventSystem.Instance.setRelationshipPoints(EventInfoTypes.Hawthorn, data.pointsHawthorn);
            MasterEventSystem.Instance.setRelationshipPoints(EventInfoTypes.Pine, data.pointsPine);
            MasterEventSystem.Instance.setRelationshipPoints(EventInfoTypes.Bonnie, data.pointsBonnie);
            MasterEventSystem.Instance.setAllFlags(data.flags);
        }
        else
        {
            Debug.Log("load failed");
        }
    }



}
