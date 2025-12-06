using UnityEngine;
using UnityEngine.UI;

public class LevelInteractabilityController : MonoBehaviour
{
    // Where player's data is saved
    public PlayerData PlayerData;
    // Level 1 Button
    public Button Level1Btn;
    // Level 2 Button
    public Button Level2Btn;
    // Level 3 Button
    public Button Level3Btn;

    public void LevelBtnsController()
    {
        switch (PlayerData.level)
        {
            // If player finished level 1, then they can now access level 2
            case 2:
                Level1Btn.interactable = true;
                Level2Btn.interactable = true;
                Level3Btn.interactable = false;
                break;
            // If player finished level 2, then they can now access level 3
            case 3:
                Level1Btn.interactable = true;
                Level2Btn.interactable = true;
                Level2Btn.interactable = true;
                break;
            // Else, they remain in level 1 and cannot access other levels
            default:
                Level1Btn.interactable= true;
                Level2Btn.interactable= false;
                Level3Btn.interactable= false;
                break;
        }
    }
}
