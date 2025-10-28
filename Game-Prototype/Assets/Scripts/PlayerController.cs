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
        //HandleInteraction();
        HandleCameraSwitch();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-v, 0f, h).normalized;

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

        if (Input.GetMouseButtonDown(0)) // left-click
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















//using UnityEngine;

////[RequireComponent(typeof(Animator))]
////[RequireComponent(typeof(Rigidbody))]
//public class PlayerController : MonoBehaviour
//{
//    //[Header("Movement Settings")]
//    public float speed = 5f;

//    //[Header("Cameras")]
//    public Camera firstPersonCamera;
//    public Camera thirdPersonCamera;

//    private Animator anim;
//    private Rigidbody rb;
//    private bool isFirstPerson = false; // Start in third-person by default

//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody>();
//        rb.freezeRotation = true;

//        // Ensure only one camera is active at start
//        SetCameraMode(isFirstPerson);
//    }

//    void Update()
//    {
//        HandleMovement();
//        HandleInteraction();
//        HandleCameraSwitch();
//    }

//    private void HandleMovement()
//    {
//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");
//        Vector3 movement = new Vector3(-v, 0f, h).normalized;

//        if (movement.magnitude > 0.1f)
//        {
//            anim.SetBool("isWalking", true);
//            Vector3 movePosition = rb.position + movement * speed * Time.deltaTime;
//            rb.MovePosition(movePosition);
//            transform.forward = movement;
//        }
//        else
//        {
//            anim.SetBool("isWalking", false);
//        }
//    }

//    private void HandleInteraction()
//    {
//        Camera activeCamera = isFirstPerson ? firstPersonCamera : thirdPersonCamera;
//        if (activeCamera == null) return;
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button
//        {
//            Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                if (hit.collider.CompareTag("CashRegister"))
//                {
//                    anim.SetTrigger("pressBtn");
//                }
//            }
//        }
//    }

//    private void HandleCameraSwitch()
//    {
//        if (Input.GetKeyDown(KeyCode.C))
//        {
//            isFirstPerson = !isFirstPerson;
//            SetCameraMode(isFirstPerson);
//        }
//    }

//    private void SetCameraMode(bool firstPerson)
//    {
//        if (firstPersonCamera != null)
//            firstPersonCamera.gameObject.SetActive(firstPerson);
//        if (thirdPersonCamera != null)
//            thirdPersonCamera.gameObject.SetActive(!firstPerson);
//    }
//}

















//if (Physics.Raycast(ray, out RaycastHit hit))
//{
//    switch (hit.collider.tag)
//    {
//        case "CashRegister":
//            anim.SetTrigger("pressBtn");
//            break;
//        case "Door":
//            anim.SetTrigger("openDoor");
//            break;
//            // Add more interactions here
//    }
//}






//using System.Runtime.ExceptionServices;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5f;
//    private Animator anim;
//    private Rigidbody rb;
//    //public Camera fpCamera; // First Person Camera
//    //public Camera tpCamera; // Third Person Camera
//    public Camera mainCamera; // Currently Used Camera
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody>();
//    }
//    void Update()
//    {
//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");
//        Vector3 movement = new Vector3(v, 0f, h).normalized;
//        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

//        if (movement.magnitude > 0)
//        {
//            anim.SetBool("isWalking", true);
//            rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
//            transform.forward = movement;
//        }
//        else
//        {
//            anim.SetBool("isWalking", false);

//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                if (hit.collider.CompareTag("CashRegister"))
//                {
//                    if (Input.GetKeyDown(KeyCode.E)) // Interact with / Use
//                    {
//                        anim.SetTrigger("pressBtn");
//                    }
//                }
//            }
//        }
//    }
//}





////using UnityEngine;

////[RequireComponent(typeof(Animator))]
////[RequireComponent(typeof(Rigidbody))]
////public class PlayerController : MonoBehaviour
////{
////    public float speed = 5f;
////    public Camera mainCamera; // The currently active camera

////    private Animator anim;
////    private Rigidbody rb;

////    void Start()
////    {
////        anim = GetComponent<Animator>();
////        rb = GetComponent<Rigidbody>();
////        rb.freezeRotation = true; // Prevent physics from rotating the player
////    }

////    void Update()
////    {
////        HandleMovement();
////        HandleInteraction();
////    }

////    private void HandleMovement()
////    {
////        float h = Input.GetAxis("Horizontal");
////        float v = Input.GetAxis("Vertical");

////        // Fixed coordinate order — use (h, 0, v), not (v, 0, h)
////        Vector3 movement = new Vector3(h, 0f, v).normalized;

////        if (movement.magnitude > 0.1f)
////        {
////            anim.SetBool("isWalking", true);

////            // Move using Rigidbody for smoother physics movement
////            Vector3 movePosition = rb.position + movement * speed * Time.deltaTime;
////            rb.MovePosition(movePosition);

////            // Rotate toward movement direction
////            transform.forward = movement;
////        }
////        else
////        {
////            anim.SetBool("isWalking", false);
////        }
////    }

////    private void HandleInteraction()
////    {
////        if (mainCamera == null) return;

////        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

////        if (Physics.Raycast(ray, out RaycastHit hit))
////        {
////            if (hit.collider.CompareTag("CashRegister") && Input.GetKeyDown(KeyCode.E))
////            {
////                anim.SetTrigger("pressBtn");
////            }
////        }
////    }
////}
