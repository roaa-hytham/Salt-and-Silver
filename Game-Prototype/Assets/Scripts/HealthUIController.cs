using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    // Health Panel
    public Image HealthPanel;
    // Health Score Txt
    public TMP_Text HealthTxt;
    // Stores player's data
    public PlayerData playerData;
    // Holds the player's current health score
    private int hp = playerData.health;
    // Holds the maximum health score player can reach
    private int maxHp = playerData.maxHealth;

    // Update is called once per frame
    void Update()
    {
        HealthTxt.text = "HP: " + hp;
        if(hp >= maxHp)
        {
            hp = maxHp;
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
