using UnityEngine;
using TMPro;

public class ObjectivesTxtController : MonoBehaviour
{
    // Where player's data is saved
    public PlayerData playerData;
    // UI Text Object
    public TMP_Text ObjectivesTxt;

    // Update is called once per frame
    void Update()
    {
        switch (playerData.level)
        {
            // If player is in level 1, then update the objectives list accordingly
            case 1:
                ObjectivesTxt.text = "L1";
                break;
            // If player is in level 2, then update the objectives list accordingly
            case 2:
                ObjectivesTxt.text = "L2";
                break;
            // If player is in level 3, then update the objectives list accordingly
            case 3:
                ObjectivesTxt.text = "L3";
                break;
            // Else, something is wrong, so no objective for now
            default:
                ObjectivesTxt.text = "All Done!";
                break;
        }
    }
}