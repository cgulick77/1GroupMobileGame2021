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
        playerRb = GetComponent<Rigidbody>();
        //render.sharedMaterial = material[x];
        speed = .08f;
        jumpS = 6.5f;
        //randomPlayerColor();
        
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Detects player inputs
       float verticalInput = Input.GetAxis("Vertical");
       
       Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput); // moves player w/ speed;
       transform.position += moveDirection * speed;

       if (Input.GetKey(KeyCode.Space) && isGrounded == true) // Player jump
       {
           playerRb.AddForce(Vector3.up * jumpS, ForceMode.Impulse);
           isGrounded = false;
           //randomPlayerColor();
           switchColor();
           

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
            //switchColor();
            render.sharedMaterial = material[0];
           
        }
        if (collision.gameObject.layer == 9)
        {
            //switchColor();
            render.sharedMaterial = material[1];
        }
    }

    private void randomPlayerColor() // Randomizes player color
    {
        int randomColor = Random.Range(0, material.Length);
        render.sharedMaterial = material[randomColor];
    }

    private void switchColor() // Switches player color; if green will switch to purple, vice versa
    {
        
       if (render.sharedMaterial = material[0]) 
       {
           render.sharedMaterial = material[1];
           
       }
        else 
       {
           render.sharedMaterial = material[0];
       }
    }
}
