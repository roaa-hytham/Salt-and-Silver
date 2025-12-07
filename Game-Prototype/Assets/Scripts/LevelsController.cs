using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public PlayerData PlayerData;

    // Update is called once per frame
    void Update()
    {
        switch (PlayerData.level)
        {
            // Level 1 conditions are met
            case 1:
                if (PlayerData.foodCollected == 4 &&
                    PlayerData.coinsCollected == 4 &&
                    PlayerData.coinsRegistered &&
                    PlayerData.restaurantLightsOff)
                {
                    // Move to level 2
                    PlayerData.level = 2;
                }
                break;

            // Level 2 conditions are met
            case 2:
                if(PlayerData.tomatoesBought == 5 &&
                    PlayerData.breadBought == 3 &&
                    PlayerData.eggplantsBought == 4 &&
                    PlayerData.groceryBagOnCounter)
                {
                    // Move to level 3
                    PlayerData.level = 3;
                }
                break;

            // Level 3 conditions are met
            case 3:
                if(PlayerData.redMushroomsCollected == 4 &&
                    PlayerData.yellowMushroomsCollected == 7 &&
                    PlayerData.spiderLiliesCollected == 3 &&
                    !PlayerData.isCaught)
                {
                    // Player Wins
                    PlayerData.level = 4;
                }
                break;

            default:
                PlayerData.level = 1;
                break;
        }
    }
}
