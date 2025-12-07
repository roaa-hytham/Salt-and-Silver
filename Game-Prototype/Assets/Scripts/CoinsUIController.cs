using TMPro;
using UnityEngine;

public class CoinsUIController : MonoBehaviour
{
    // Coins Panel
    public GameObject CoinsPanel;
    private bool isVisible = true;
    // Coins Score Txt
    public TMP_Text CoinsTxt;
    // Stores player's data
    public PlayerData playerData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isVisible = !isVisible;
            CoinsPanel.SetActive(isVisible);
        }
        CoinsTxt.text = "Coins: " + playerData.coins;
    }
}
