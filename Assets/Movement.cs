using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10;

    bool isGrounded = false;
    public Transform GroundCheck1; // Put the prefab of the ground here
    public LayerMask groundLayer; // Insert the layer here.
    public float overlapCircleRadius = 0.15f;
    public float jumpPower = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            velocity.x = speed * Input.GetAxisRaw("Horizontal");
        }
        else
        {
            velocity.x = 0;
        }
        if (isGrounded & Input.GetAxisRaw("Vertical") > 0)
        {
            velocity.y = Input.GetAxisRaw("Vertical") * jumpPower;
        }
        GetComponent<Rigidbody2D>().velocity = velocity;


    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, overlapCircleRadius, groundLayer); // checks if you are within 0.15 position in the Y of the ground


    }
}
