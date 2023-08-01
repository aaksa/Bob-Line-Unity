using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float xPosition1 = 0.685f;
    public float xPosition2 = -0.685f;
    public float fixedY = -1.9f;

    private Rigidbody2D rb;

    private bool isAtPosition1 = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Set the Rigidbody2D to kinematic
        SetPosition(xPosition2, Quaternion.Euler(0f, 0f, 90f));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Get the world position of the mouse click
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure the z-position is 0 since we're working in 2D

            // Check if the mouse click is on the right side of the screen
            if (mousePosition.x > 0 | mousePosition.x < 0)
            {
                if (isAtPosition1)
                    SetPosition(xPosition2, Quaternion.Euler(0f, 0f, 90f));
                else
                    SetPosition(xPosition1, Quaternion.Euler(0f, 190f, 90f));
                isAtPosition1 = !isAtPosition1;
            }
        }
    }


    private void SetPosition(float x, Quaternion rotation)
    {
        // Teleport the character to the specified x position while keeping the fixedY
        rb.MovePosition(new Vector2(x, fixedY));

        // Set the character's rotation based on the target position
        //Vector3 rotationEuler = isAtPosition1 ? new Vector3(0f, 0f, 90f) : new Vector3(0f, 0f, 90f);
        //rb.transform.rotation = Quaternion.Euler(rotationEuler);
        rb.transform.rotation = rotation;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            audioManager.PlaySFX(audioManager.death);
            SceneManager.LoadScene(2);

        }
    }


}
