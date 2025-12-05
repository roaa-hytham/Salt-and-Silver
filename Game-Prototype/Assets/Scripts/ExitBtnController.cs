using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitBtnController : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine
        StartCoroutine(ExitGameAfterSaving());

        // Exit game
        Debug.Log("Exit game called.");
        Application.Quit();
    }

    IEnumerator ExitGameAfterSaving()
    {
        // Load the next scene
        SceneManager.LoadScene("SavingScene");

        // Wait for few seconds
        yield return new WaitForSeconds(3f);
    }
}