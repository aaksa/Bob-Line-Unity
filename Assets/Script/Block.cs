using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Disable gravity and set isKinematic to true to ensure the fallingSpeed is constant

    }

    private void FixedUpdate()
    {
        // Apply a constant downward force to make the object fall at the specified speed
        rb.velocity = new Vector2(rb.velocity.x, -6);
        // Debug.Log the velocity to see if it's changing
        Debug.Log(rb.velocity.y);
    }


    // Update is called once per frame
    void Update()
    {

        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
        
    }
}
