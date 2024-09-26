using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
public class RoleSelectionManager : MonoBehaviour
{
    //create buttons
    public Button engineerButton;
    public Button biologistButton;
    public Button logisticsButton;
    public Button confirmButton;
    public GameObject roleSelectionPanel; //reference to the UI panel for role selection

    //button outlines
    public Outline engineerOutline;
    public Outline biologistOutline;
    public Outline logisticsOutline;

    private Roles selectedRole;
    private bool shownOnce = false;

    //Hover text 
    public TextMeshProUGUI hoverText;

    void Start()
    {
        //disable confirm button at the start
        confirmButton.interactable = false;


        //no button selected UI
        // Disable all outlines initially
        engineerOutline.enabled = false;
        biologistOutline.enabled = false;
        logisticsOutline.enabled = false;

        //Add listeners for the role selection buttons
        engineerButton.onClick.AddListener(() => SelectRole(Roles.Engineer));

        //handle hover text on locked roles
        biologistButton.onClick.AddListener(() => ShowLockedRoleMessage("This Role is in Development"));
        logisticsButton.onClick.AddListener(() => ShowLockedRoleMessage("This Role is Coming Soon"));

        // Subscribe to the event change notification
        MasterEventSystem.Instance.OnEventInfoChnaged += HandleEventChange;

        //check current event at startup
        HandleEventChange(MasterEventSystem.Instance.getCurrentEvent());
    }


    //method to slect role
    void SelectRole(Roles role)
    {
        selectedRole = role;
        Debug.Log("Role selected: " + selectedRole.ToString());
        confirmButton.interactable = (role == Roles.Engineer);  // Enable confirm only for Engineer once selected

        hoverText.enabled = false;


        //change UI to reflect selected role
        // Reset all outlines
        ResetOutlines();

        // Enable the outline for the selected role
        if (role == Roles.Engineer)
        {
            engineerOutline.enabled = true;
        }
       /* else if (role == Roles.Biologist)
        {
            biologistOutline.enabled = true;
        } */
    }

    //Method to handle locked roles
    void ShowLockedRoleMessage(string message)
    {
        // Show a message like "In Development" for locked roles
        hoverText.text = message;
        hoverText.enabled = true;

        // Make sure the confirm button is disabled since it's a locked role
        confirmButton.interactable = false;

        // Reset outlines
        ResetOutlines();

        // Enable outline for locked role (for clarity or aesthetics)
        if (message == "In Development")
        {
            biologistOutline.enabled = true;  // Enable the outline for Biologist when it's clicked
        }
        else if (message == "Coming Soon")
        {
            logisticsOutline.enabled = true;
        }
    }

    //method to reset outlines
    void ResetOutlines()
    {
        engineerOutline.enabled = false;
        biologistOutline.enabled = false;
        logisticsOutline.enabled = false;
    }
    //method to confirm the slection
    public void ConfirmRole()
    {
        if (selectedRole == Roles.Engineer) //LOCKED OUT PURPOSES ONLY, DELETE LATER
        {
            MasterEventSystem.Instance.setRole(selectedRole);
            Debug.Log("Role Confirmed: " + selectedRole.ToString());

            // Mark JobSelection as cleared using eventTypeCleared()

            MasterEventSystem.Instance.setRole(selectedRole);
            roleSelectionPanel.SetActive(false);

            MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.JobSelection);
        }
    }

    //Handle changes in the current event
    void HandleEventChange(Events currentEvent)
    {
        if (currentEvent == Events.Act1Scene3 && !shownOnce)
        {
            roleSelectionPanel.SetActive(true); //show the panel
            shownOnce = true;
        }
    }
    // Unsubscribe from the event when this object is destroyed
    void OnDestroy()
    {
        if (MasterEventSystem.Instance != null)
        {
            MasterEventSystem.Instance.OnEventInfoChnaged -= HandleEventChange;
        }
    }
}
