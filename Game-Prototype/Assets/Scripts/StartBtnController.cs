using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBtnController : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("LoadingScene");

        // Start the coroutine
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        // Wait for few seconds
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadScene("RestaurantScene");
    }
}