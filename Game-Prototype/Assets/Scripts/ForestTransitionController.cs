using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestTransitionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // If player collides with MarketTrigger
        if (collider.CompareTag("MarketTrigger"))
        {
            // Load the MarketScene
            SceneManager.LoadScene("MarketScene");
        }
    }
}
