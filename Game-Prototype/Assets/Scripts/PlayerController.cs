using System.Runtime.ExceptionServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Animator anim;
    private Rigidbody rb;
    //public Camera fpCamera; // First Person Camera
    //public Camera tpCamera; // Third Person Camera
    public Camera mainCamera; // Currently Used Camera
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(v, 0f, h).normalized;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (movement.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
            rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
            transform.forward = movement;
        }
        else
        {
            anim.SetBool("isWalking", false);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("CashRegister"))
                {
                    if (Input.GetKeyDown(KeyCode.E)) // Interact with / Use
                    {
                        anim.SetTrigger("pressBtn");
                    }
                }
            }
        }
    }
}
