using UnityEngine;
using UnityEngine.SceneManagement;

public class RestaurantTransitionController : MonoBehaviour
{
    public PlayerData playerData;
    private void OnTriggerEnter(Collider collider)
    {
        // If player collides with MarketTrigger
        if (collider.CompareTag("MarketTrigger"))
        {
            // Load the MarketScene
            SceneManager.LoadScene("MarketScene");
            playerData.location = "Market";
        }
    }
}