using UnityEngine;

public class InteractionController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Camera mainCam = Camera.main;
        if (mainCam == null) return;
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("CashRegister"))
                {
                    anim.SetTrigger("pressBtn");
                }
            }
        }
    }
}
