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
                ObjectivesTxt.text = "Level 1:" + "\n" +
                    "1. Collect all food left on tables." + "\n" +
                    "2. Collect money left by customers." + "\n" +
                    "3. Register the money." + "\n" +
                    "4. Close the lights.";
                break;
            // If player is in level 2, then update the objectives list accordingly
            case 2:
                ObjectivesTxt.text = "Level 2:" + "\n" +
                    "1. Go to the market." + "\n" +
                    "2. Buy 5 tomatoes." + "\n" +
                    "3. Buy 3 loaves of bread." + "\n" +
                    "4. Buy 4 eggplants." + "\n" +
                    "5. Go back to the restaurant." + "\n";
                    //"6. Put the grocery bag on the register counter.";
                break;
            // If player is in level 3, then update the objectives list accordingly
            case 3:
                ObjectivesTxt.text = "Level 3:" + "\n" +
                    "1. Go to the forest." + "\n" +
                    "2. Collect 4 red mushrooms." + "\n" +
                    "3. Collect 7 yellow mushrooms." + "\n" +
                    "4. Collect 3 Spider Lilies." + "\n" +
                    "5. Don't get caught by the Forest Spirit." + "\n" +
                    "6. Go back to the restaurant.";
                break;
            // Else, something is wrong, so no objective for now
            default:
                ObjectivesTxt.text = "All Done!";
                break;
        }
    }
}