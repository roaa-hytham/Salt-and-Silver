using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Animator anim;
    private Rigidbody rb;

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

}