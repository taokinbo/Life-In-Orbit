using UnityEngine;
using UnityEngine.UI;
public class RoleSelectionManager : MonoBehaviour
{
    //create buttons
    public Button engineerButton;
    public Button biologistButton;
    public Button confirmButton;
    public GameObject roleSelectionPanel; //reference to the UI panel for role selection

    //button outlines
    public Outline engineerOutline;
    public Outline biologistOutline;

    private Roles selectedRole;

    void Start()
    {
        //disable confirm button at the start
        confirmButton.interactable = false;

        //no button selected UI
        // Disable all outlines initially
        engineerOutline.enabled = false;
        biologistOutline.enabled = false;

        //Add listeners for the role selection buttons 
        engineerButton.onClick.AddListener(() => SelectRole(Roles.Engineer));
        biologistButton.onClick.AddListener(() => SelectRole(Roles.Biologist));

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
        confirmButton.interactable = true; //enable confirm button once selected

        //change UI to reflect selected role
        // Reset all outlines
        ResetOutlines();

        // Enable the outline for the selected role
        if (role == Roles.Engineer)
        {
            engineerOutline.enabled = true;
        }
        else if (role == Roles.Biologist)
        {
            biologistOutline.enabled = true;
        }
    }

    //method to reset outlines
    void ResetOutlines()
    {
        engineerOutline.enabled = false;
        biologistOutline.enabled = false;
    }
    //method to confirm the slection
    public void ConfirmRole()
    {
        MasterEventSystem.Instance.setRole(selectedRole);
        Debug.Log("Role Confirmed: " + selectedRole.ToString());

        // Mark JobSelection as cleared using eventTypeCleared()
        MasterEventSystem.Instance.eventTypeCleared(EventInfoTypes.JobSelection);

        roleSelectionPanel.SetActive(false);
    }

    //Handle changes in the current event 
    void HandleEventChange(Events currentEvent)
    {
        if (currentEvent == Events.Act1Scene3)
        {
            roleSelectionPanel.SetActive(true); //show the panel
        }
        else
        {
            roleSelectionPanel.SetActive(false); //hide panel for rest of game
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