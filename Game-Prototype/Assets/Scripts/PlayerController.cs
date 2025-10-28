using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public GameObject firstPersonRig;   // The GameObject that holds your first-person Cinemachine camera
    public GameObject thirdPersonRig;   // The GameObject that holds your third-person Cinemachine camera

    private Animator anim;
    private Rigidbody rb;
    private bool isFirstPerson = false; // start in third-person

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        SetCameraMode(isFirstPerson);
    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();
        HandleCameraSwitch();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(v, 0f, h).normalized;

        if (movement.magnitude > 0.1f)
        {
            anim.SetBool("isWalking", true);

            Vector3 movePosition = rb.position + movement * speed * Time.deltaTime;
            rb.MovePosition(movePosition);

            transform.forward = movement;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void HandleInteraction()
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

    private void HandleCameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            SetCameraMode(isFirstPerson);
        }
    }

    private void SetCameraMode(bool firstPerson)
    {
        if (firstPersonRig != null)
            firstPersonRig.SetActive(firstPerson);

        if (thirdPersonRig != null)
            thirdPersonRig.SetActive(!firstPerson);
    }
}