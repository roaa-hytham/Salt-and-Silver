using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public TMP_Text Inventory;
    public PlayerData playerData;

    // Update is called once per frame
    void Update()
    {
        if(playerData.tomatoesBought > 0)
        {
            Inventory.text += "Tomatoes: " + playerData.tomatoesBought + "\n";
        }

        if(playerData.breadBought > 0)
        {
            Inventory.text += "Bread: " + playerData.breadBought + "\n";
        }

        if(playerData.eggplantsBought > 0)
        {
            Inventory.text += "Eggplants: " + playerData.eggplantsBought + "\n";
        }

        if(playerData.redMushroomsCollected > 0)
        {
            Inventory.text += "Red Mushrooms: " + playerData.redMushroomsCollected + "\n";
        }

        if(playerData.yellowMushroomsCollected > 0)
        {
            Inventory.text += "Yellow Mushrooms: " + playerData.yellowMushroomsCollected + "\n";
        }

        if(playerData.spiderLiliesCollected > 0)
        {
            Inventory.text += "Spider Lilies: " + playerData.spiderLiliesCollected + "\n";
        }
            
    }
}
