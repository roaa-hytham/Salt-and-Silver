using UnityEngine;

public class ObjectivesUIController : MonoBehaviour
{
    public GameObject objectivesPanel;
    public GameObject instructionsTxt;
    public GameObject instructionsKey;
    private bool isVisible = false;
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
            instructionsKey.SetActive(false);
            isShowing = !isShowing;
            instructionsTxt.SetActive(isShowing);
        }
    }
}
