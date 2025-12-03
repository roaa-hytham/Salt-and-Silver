using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtnController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("RestaurantScene");
    }
}
