using UnityEngine;

public class ExitBtnController : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit game called.");
        Application.Quit();
    }
}
