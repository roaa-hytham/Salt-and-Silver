using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketTransitionController : MonoBehaviour
{
    public PlayerData PlayerData;
   private void OnTriggerEnter(Collider collider)
    {
        // If player collides with ForestTrigger
        if (collider.CompareTag("ForestTrigger"))
        {
            // Load the ForestScene
            SceneManager.LoadScene("ForestScene");
            PlayerData.location = "Forest";
        }

        // If player collides with RestaurantTrigger
        if (collider.CompareTag("RestaurantTrigger"))
        {
            // Load the RestaurantScene
            SceneManager.LoadScene("RestaurantScene");
            PlayerData.location = "Restaurant";
        }
    }
}
