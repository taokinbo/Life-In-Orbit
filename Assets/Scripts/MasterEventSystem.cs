using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class MasterEventSystem : MonoBehaviour
{
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
        Act5Scene17 = 17,
    };

    public enum EventInfoTypes
    {
        Room, Hallway, CommandCenter, EngineeringBay, Biodome,      // settings
        Lumina, Hawthorn, Pine, Bonnie, Alien,                  // characters
        NameSelection, JobSelection,                                // selections
        AlienActivity,
        None
    };

    private EventInfoTypes[] rooms = {EventInfoTypes.Room, EventInfoTypes.CommandCenter, EventInfoTypes.Biodome, EventInfoTypes.EngineeringBay, EventInfoTypes.Hallway};
    private EventInfoTypes[] people = {EventInfoTypes.Lumina, EventInfoTypes.Hawthorn, EventInfoTypes.Pine, EventInfoTypes.Bonnie, EventInfoTypes.Alien};

    public enum Roles
    {
        Engineer, Biologist, None
    }

    private int biologyDifficulty = 0;
    private int engineerDifficulty = 0;

    private Events currentEvent = Events.GameStart;
    private Roles currentRole = Roles.None;

    Dictionary<Events, bool> eventTriggered = new Dictionary<Events, bool>();

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

    public void ResetEventTrigger()
    {
        foreach (var key in eventTriggered.Keys)
        {
            eventTriggered[key] = false;
        }
    }

    public void SwitchEvent(Events _event)
    {
        eventTriggered[_event] = true;
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
            { EventInfoTypes.Alien, true },
        };
        eventInfo[Events.Act2Scene9] = currentDict;
        // Act 2 Scene 10
        currentDict = new Dictionary<EventInfoTypes, bool>
        {
            { EventInfoTypes.Hallway, true },
            { EventInfoTypes.Pine, true },
        };
        eventInfo[Events.Act2Scene10] = currentDict;
    }

    // BE CARE TO NOT CHANGE VALUE WHEN CALLED. THIS EFFECTS SAVE
    public Dictionary<EventInfoTypes, bool> getAllInfoFromScene(){

        return eventInfo[currentEvent];
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

    public int getDifficulty(Roles role) {
        if (role == Roles.Biologist) return biologyDifficulty;
        if (role == Roles.Engineer) return engineerDifficulty;
        return -1;
    }

    public void setDifficulty(Roles role, int difficulty) {
        if (role == Roles.Biologist) biologyDifficulty = difficulty;
        else if (role == Roles.Engineer) engineerDifficulty = difficulty;
    }

}
