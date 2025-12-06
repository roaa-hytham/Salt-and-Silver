using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsBtnController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void Levels()
    {
        // Load scene with Levels Buttons
        SceneManager.LoadScene("LevelsScene");
    }
}
