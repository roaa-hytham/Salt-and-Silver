using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitBtnController : MonoBehaviour
{
    public void ExitGame()
    {
        // Start the coroutine
        StartCoroutine(ExitGameAfterSaving());
    }

    IEnumerator ExitGameAfterSaving()
    {
        // Load the next scene
        SceneManager.LoadScene("SavingScene");

        // Wait for few seconds
        yield return new WaitForSeconds(3f);

        // Exit game
        Debug.Log("Exit game called.");
        Application.Quit();
    }
}