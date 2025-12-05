using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBtnController : MonoBehaviour
{
    public void StartGame()
    {
        // Start the coroutine
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        SceneManager.LoadScene("LoadingScene");

        // Wait for few seconds
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadScene("RestaurantScene");
    }
}