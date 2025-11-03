using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private Rigidbody rb;
    private Vector3 movement;
    private bool canMove = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!canMove) return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movement = new Vector3(v, 0f, h).normalized;

        anim.SetBool("isWalking", movement.magnitude > 0.1f);
    }
    void FixedUpdate()
    {
        if (!canMove) return;
        if (movement.magnitude > 0.1f)
        {
            Vector3 movePosition = rb.position + movement * speed * Time.fixedDeltaTime;
            rb.MovePosition(movePosition);
            transform.forward = movement;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        //canMove = false;
    //        rb.linearVelocity = Vector3.zero;
    //        movement = Vector3.zero;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        canMove = true;
    //    }
    //}

}