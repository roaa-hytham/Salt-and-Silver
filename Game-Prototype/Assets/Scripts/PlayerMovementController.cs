using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private Rigidbody rb;
    private Vector3 movement;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movement = new Vector3(v, 0f, h).normalized;

        anim.SetBool("isWalking", movement.magnitude > 0.1f);
    }
    void FixedUpdate()
    {
        if (movement.magnitude > 0.1f)
        {
            Vector3 movePosition = rb.position + movement * speed * Time.fixedDeltaTime;
            rb.MovePosition(movePosition);
            transform.forward = movement;
        }
    }

}