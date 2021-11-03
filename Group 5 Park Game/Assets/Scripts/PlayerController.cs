using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Material [] material;
    private int x;
    Renderer render;
    private Rigidbody playerRb;
    private float speed, jumpS;
    public bool isGrounded, playerColor, start;

    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        playerRb = GetComponent<Rigidbody>();
        speed = .08f;
        jumpS = 6.5f;
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Detects player inputs
       float verticalInput = Input.GetAxis("Vertical");
       render.sharedMaterial = material[x]; // Checks players current material
       
       Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput); // moves player w/ speed;
       transform.position += moveDirection * speed;
       playerCurrentColor(); // Checks players current color

       if (Input.GetKey(KeyCode.Space) && isGrounded == true) // Player jump
       {
           playerRb.AddForce(Vector3.up * jumpS, ForceMode.Impulse);
           isGrounded = false;
           switchColor(); // Switches player color
       }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground")) // Detects when player is touching the ground
        {
            isGrounded = true;
        }

        if (collision.gameObject.layer == 8)
        {
            x = 0;
        }
        if (collision.gameObject.layer == 9)
        {
            x++;
        }
    }

    private void randomPlayerColor() // Randomizes player color
    {
        int randomColor = Random.Range(0, material.Length);
        render.sharedMaterial = material[randomColor];
        //x = randomColor;
    }

    public void switchColor() // Switches player color; if green will switch to purple, vice versa
    {
    
       if (x < 1 && isGrounded == false) 
       {
           x++;
       }

        else if (x > 0 && isGrounded == false)
       { 
           x = 0;
       }
    }

    public void playerCurrentColor()
    {
        if (x < 1)
        {
            playerColor = true; // Current player color is green
        }
        if (x > 0)
        {
            playerColor = false; // Current player color is purple
        }
    }
}
