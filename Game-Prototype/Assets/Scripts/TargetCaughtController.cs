using UnityEngine;

public class TargetCaughtController : MonoBehaviour
{
    public PlayerData PlayerData;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerData.isCaught = true;
        }
    }
}