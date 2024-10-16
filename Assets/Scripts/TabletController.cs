using System.Collections.Generic;
using TMPro; //for textmeshproUGUI
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //for image component

public class TabletController : MonoBehaviour
{
    public GameObject tabletPanel;      // The main tablet UI panel
    public GameObject homePanel;        // The Home Screen
    public GameObject directoryPanel;   // The Directory panel (RelationshipManager)
    public GameObject researchPanel;    // The Research panel
    public GraphicRaycaster canvasCaster; // The interaction controller for the canvas

    //UI elements
    public TextMeshProUGUI tasksText;              // The text field for displaying tasks
    public TextMeshProUGUI dayText;                // The text field for displaying the current day
    public TextMeshProUGUI tempText;            // The text field for displaying the current temperature
    public TextMeshProUGUI ascendancyIndexText;    // The text field for displaying Ascendancy Index

    public Image weatherIcon; //displaying weather image

    //weather icons
    public Sprite sunnyIcon;
    public Sprite snowyIcon;
    public Sprite rainyIcon;
    public Sprite stormyIcon;

    //method to open tablet
    private bool isTabletOpen = false;  // Track whether the tablet is open

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TabletController Start() method is running");  // Log to check if this is called
        CloseTablet();
        // OpenHome();
    }

    // Optionally, use a keyboard shortcut to toggle the tablet
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (isTabletOpen)
            {
                CloseTablet();  // Close if already open
            }
            else
            {
                // Debug.Log()
                OpenTablet();  // Open if not open
            }
        }
    }


    // Open the tablet by loading the TabletMenu scene additively
    public void OpenTablet()
    {
        // SceneManager.LoadSceneAsync("TabletMenu", LoadSceneMode.Additive); // none of this is working if scene isnt loaded yet. need to load scene in navigation area
        isTabletOpen = true;
        canvasCaster.enabled = true;
        homePanel.SetActive(true);  // Ensure the tablet panel becomes visible
        directoryPanel.SetActive(false);
        researchPanel.SetActive(false);
        UpdateDayAndWeather();
        UpdateAscendancyIndex();
        UpdateTaskList();
        Debug.Log("Tablet opened and all sections updated");
    }

    public void CloseTablet()
    {
            // SceneManager.UnloadSceneAsync("TabletMenu"); // Dont destroy tablet when closing, just hide
        isTabletOpen = false;
        canvasCaster.enabled = false;
        homePanel.SetActive(false);  // Ensure the tablet panel hides when closing
        directoryPanel.SetActive(false);
        researchPanel.SetActive(false);
    }
    // Method to update the tasks for the current scene/day
    public void UpdateTaskList()
    {
        if (MasterEventSystem.Instance == null)
        {
            Debug.LogError("MasterEventSystem is not initialized.");
            tasksText.text = "Could not retrieve tasks from masterevent system.";
            return;
        }
        // Get the current day from the MasterEventSystem
        int currentDay = MasterEventSystem.Instance.GetCurrentDay();

        // Fetch the tasks for the current scene
        List<MasterEventSystem.TaskStatus> tasks = MasterEventSystem.Instance.GetTasksForCurrentScene();

        // Initialize a string to hold the task list
        string taskDisplay = "";

        // Loop through each task and display it based on completion status and current day
        foreach (MasterEventSystem.TaskStatus task in tasks)
        {
            // Here, you should make sure that the task is assigned to the current day
            // Assuming each TaskStatus or MasterEventSystem tracks the day the task is assigned to:
            if (MasterEventSystem.Instance.GetCurrentDay() == currentDay)
            {
                if (task.IsCompleted)
                {
                    // Option 1: Cross off the task using the <s> (strikethrough) tag
                    taskDisplay += "<s>Task: " + task.Description + "</s>\n";  // Crossed-off text
                }
                else
                {
                    // Display pending tasks normally
                    taskDisplay += "Task: " + task.Description + "\n";
                }
            }
        }

        // Update the UI text field with the task list
        tasksText.text = taskDisplay;
    }



    // Method to update the current day and weather
    public void UpdateDayAndWeather()
    {
        int currentDay = 1; //MasterEventSystem.Instance.GetCurrentDay();  // Get the current day from MasterEventSystem

        // Initialize variables for temperature
        float temperature = 0f;

        // Determine the weather and temperature based on the current day
        switch (currentDay)
        {
            case 1:

                temperature = 75f;
                weatherIcon.sprite = sunnyIcon;  // Set the Sunny weather icon
                break;
            case 2:

                temperature = 60f;
                weatherIcon.sprite = rainyIcon;  // Set the Rainy weather icon
                break;
            case 13:

                temperature = 30f;
                weatherIcon.sprite = snowyIcon;  // Set the Snowy weather icon
                break;
            case 14:

                temperature = 50f;
                weatherIcon.sprite = stormyIcon;  // Set the Stormy weather icon
                break;
            default:

                temperature = 0f;
                Debug.LogWarning("Unknown day or weather condition.");
                break;
        }

        // Update the day and weather text
        dayText.text = currentDay.ToString();
        tempText.text = temperature.ToString("F0") + "°F";  // Display temperature
    }



    //Method to update the Ascendancy Index
    public void UpdateAscendancyIndex()
    {
        float ascendancyScore = AscendancyIndexManager.Instance.GetAscendancyIndex();
        Debug.Log("Tablet Ascendancy Score has been calculated and retrieved.");
        ascendancyIndexText.text = ascendancyScore.ToString("F1");
        Debug.Log("UI has been updated.");

    }

    public void OpenHome()
    {
        homePanel.SetActive(true);
        directoryPanel.SetActive(false);
        researchPanel.SetActive(false);

        // UpdateTaskList();
        UpdateDayAndWeather();
        UpdateAscendancyIndex();
    }

    public void OpenDirectory()
    {
        // homePanel.SetActive(false);      // Hide the home screen
        directoryPanel.SetActive(true);  // Show the directory panel
        researchPanel.SetActive(false);   // Hide the research panel

        RelationshipManager.Instance.OpenDirectory();
    }

    // Method to open the Research panel
    public void OpenResearch()
    {
        // homePanel.SetActive(false);      // Hide the home screen
        directoryPanel.SetActive(false);
        researchPanel.SetActive(true);   // Show the research panel
    }

    //method to quit the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
