using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int coins;
    public int level = 1;
    public int health = 100;
    public string location = "Restaurant";

    // Level 1 Conditions
    public int coinsCollected;
    public bool coinsRegistered;
    public int foodCollected;
    public bool restaurantLightsOff;

    // Level 2 Conditions
    public int tomatoesBought;
    public int breadBought;
    public int eggplantsBought;
    public bool hasGroceryBag;
    public bool groceryBagOnCounter;

    // Level 3 Conditions
    public int redMushroomsCollected;
    public int yellowMushroomsCollected;
    public int spiderLiliesCollected;
    public bool isCaught;
}
