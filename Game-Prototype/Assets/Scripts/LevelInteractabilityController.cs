using UnityEngine;
using UnityEngine.UI;

public class LevelInteractabilityController : MonoBehaviour
{
    public PlayerData PlayerData;
    public Button Level1Btn;
    public Button Level2Btn;
    public Button Level3Btn;

    public void LevelBtnsController()
    {
        switch (PlayerData.level)
        {
            case 2:
                Level1Btn.interactable = true;
                Level2Btn.interactable = true;
                Level3Btn.interactable = false;
                break;

            case 3:
                Level1Btn.interactable = true;
                Level2Btn.interactable = true;
                Level2Btn.interactable = true;
                break;

            default:
                Level1Btn.interactable= true;
                Level2Btn.interactable= false;
                Level3Btn.interactable= false;
                break;
        }
    }
}
