using System.Collections;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    public PlayerData PlayerData;
    public GameObject DialoguePanel;
    public TMP_Text DialogueTxt;

    // Update is called once per frame
    void Update()
    {
        if (PlayerData.isCaught)
        {
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            switch (PlayerData.level)
            {
                // Level 1 conditions are met
                case 1:
                    if (PlayerData.foodCollected == 4 &&
                        PlayerData.coinsCollected == 4 &&
                        PlayerData.coinsRegistered &&
                        PlayerData.restaurantLightsOff &&
                        PlayerData.location == "Restaurant")
                    {
                        // Move to level 2
                        PlayerData.level = 2;
                        StartCoroutine(Level2Dialogue());
                    }
                    break;

                // Level 2 conditions are met
                case 2:
                    if (PlayerData.tomatoesBought >= 5 &&
                        PlayerData.breadBought >= 4 &&
                        PlayerData.eggplantsBought >= 3 &&
                        //PlayerData.groceryBagOnCounter &&
                        PlayerData.location == "Restaurant")
                    {
                        // Move to level 3
                        PlayerData.level = 3;
                        StartCoroutine(LoadNextLevel());
                    }
                    break;

                // Level 3 conditions are met
                case 3:
                    if (PlayerData.redMushroomsCollected >= 4 &&
                        PlayerData.yellowMushroomsCollected >= 7 &&
                        PlayerData.spiderLiliesCollected >= 3 &&
                        !PlayerData.isCaught &&
                        PlayerData.location == "Restaurant")
                    {
                        StartCoroutine(GameWon());
                        // Player Wins
                        PlayerData.level = 4;
                    }
                    break;

                default:
                    PlayerData.level = 1;
                    break;
            }
        }
    }
    IEnumerator LoadNextLevel()
    {
        // Load the next scene
        SceneManager.LoadScene("LevelCompleteScene");

        // Wait for few seconds
        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene("SavingScene");

        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene("RestaurantScene");
    }

    IEnumerator GameWon()
    {
        // Load the next scene
        SceneManager.LoadScene("LevelCompleteScene");

        // Wait for few seconds
        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene("SavingScene");

        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene("WinScene");
    }

    IEnumerator Level2Dialogue()
    {
        yield return StartCoroutine(LoadNextLevel());
        yield return new WaitForSeconds(1);
        DialoguePanel.SetActive(true);
        DialogueTxt.text = "Megan: I need to buy groceries...";
        yield return new WaitForSeconds(2f);
        DialoguePanel.SetActive(false);
    }

    IEnumerator Level3Dialogue()
    {
        yield return StartCoroutine(LoadNextLevel());
        yield return new WaitForSeconds(1);
        DialoguePanel.SetActive(true);
        DialogueTxt.text = "Megan: I need to collect some mushrooms from the forest...";
        yield return new WaitForSeconds(2f);
        DialoguePanel.SetActive(false);
    }
}