using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    // Health Panel
    public Image HealthPanel;
    public GameObject HealthPanelObject;
    private bool isVisible = true;
    // Health Score Txt
    public TMP_Text HealthTxt;
    // Stores player's data
    public PlayerData playerData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isVisible = !isVisible;
            HealthPanelObject.SetActive(isVisible);
        }

        // Holds the player's current health score
        int hp = playerData.health;
        // Holds the maximum health score player can reach
        int maxHp = playerData.maxHealth;
        HealthTxt.text = "HP: " + hp;
        if(hp >= maxHp)
        {
            hp = maxHp;
            // Change color accordingly
            HealthPanel.color = Color.green;
        }
        if(hp <= maxHp / 2)
        {
            HealthPanel.color = Color.yellowGreen;
        }
        if(hp <= maxHp / 3)
        {
            HealthPanel.color = Color.yellow;
        }
        if(hp <= maxHp / 4)
        {
            HealthPanel.color = Color.red;
        }
    }
}
