using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketTransitionController : MonoBehaviour
{
   private void OnTriggerEnter(Collider collider)
    {
        // If player collides with ForestTrigger
        if (collider.CompareTag("ForestTrigger"))
        {
            // Load the ForestScene
            SceneManager.LoadScene("ForestScene");
        }

        // If player collides with RestaurantTrigger
        if (collider.CompareTag("RestaurantTrigger"))
        {
            // Load the RestaurantScene
            SceneManager.LoadScene("RestaurantScene");
        }
    }
}
