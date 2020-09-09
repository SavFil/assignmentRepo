using UnityEngine;

public class Control : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpPower = 1f;
    private float boost = 1f;

    private float movement = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Jump();
        Boost();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * movementSpeed * boost * Time.deltaTime;
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Z) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.X) && Mathf.Abs(rb.velocity.y) < 0.001f)
            boost = 2f;
        else
            boost = 1f;

    }
}
