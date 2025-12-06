using UnityEngine;

public class ObjectivesUIController : MonoBehaviour
{
    // Objectives Panel UI
    public GameObject objectivesPanel;
    // Shortcuts Panel UI
    public GameObject shortcutsPanel;
    // Shortcuts Instruction Panel
    public GameObject instructionsPanel;
    // Visibility of Objective Panel
    private bool isVisible = true;
    // Visibility of Shortcuts Panel
    private bool isShowing = false;

    // Update is called once per frame
    void Update()
    {
        // Toggle with "O"
        if (Input.GetKeyDown(KeyCode.O))
        {
            isVisible = !isVisible;
            objectivesPanel.SetActive(isVisible);
        }

        // Toggle with "K"
        if (Input.GetKeyDown(KeyCode.K))
        {
            instructionsPanel.SetActive(false);
            isShowing = !isShowing;
            shortcutsPanel.SetActive(isShowing);
        }
    }
}
