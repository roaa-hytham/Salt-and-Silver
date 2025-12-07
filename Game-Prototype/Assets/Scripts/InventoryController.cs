using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public TMP_Text Inventory;
    public PlayerData playerData;
    private bool visibleInventory = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !visibleInventory)
        {
            SceneManager.LoadScene("InventoryScene");
            visibleInventory = !visibleInventory;
        }

        if(Input.GetKeyDown(KeyCode.I) && visibleInventory)
        {
            switch (playerData.location)
            {
                case "Restaurant":
                    SceneManager.LoadScene("RestaurantScene");
                    break;
                case "Market":
                    SceneManager.LoadScene("MarketScene");
                    break;
                case "Forest":
                    SceneManager.LoadScene("ForestScene");
                    break;
            }
            visibleInventory = !visibleInventory;
        }

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
