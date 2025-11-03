using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float interactDistance = 3f;

    public string interactTrigger = "pressBtn";

    private Animator playerAnim;
    private Camera mainCam;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        mainCam = Camera.main;

        if (mainCam == null)
            Debug.LogError("No Main Camera found in the scene. Tag your player camera as 'MainCamera'.");
    }

    void Update()
    {
        if (mainCam == null) return;
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                if (hit.collider.CompareTag("CashRegister"))
                {
                    if (playerAnim != null)
                        playerAnim.SetTrigger(interactTrigger);

                    //Animator objAnim = hit.collider.GetComponent<Animator>();
                    //if (objAnim != null)
                    //    objAnim.SetTrigger(interactTrigger);

                    Debug.Log("Interacted with: " + hit.collider.name);
                }
            }
        }
    }
}
