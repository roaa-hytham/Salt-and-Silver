using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketTransitionController : MonoBehaviour
{
   private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ForestTrigger"))
        {
            SceneManager.LoadScene("ForestScene");
        }
        if (collider.CompareTag("RestaurantTrigger"))
        {
            SceneManager.LoadScene("RestaurantScene");
        }
    }
}
