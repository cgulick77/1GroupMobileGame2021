using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject [] platformsGreen, platformsPurple;
    // Start is called before the first frame update
    int i = 0;
    /* HOW TO USE:
        1-Create an empty gameObject
        2-Add this script 
        3-Go to inspector and in size type the amount of object you're putting in for each color
        3-Drag all the gameObject into their designated color list.
    */
    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>(); // Find the player controller script
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.playerColor == true) // Checks if player color is green or purple.
        {
            
            for (i = 0; i <platformsGreen.Length; i++) // If player color = green, enable green. / For loop is used to check very object in the array.
            {
                platformsGreen[i].SetActive(true);
                platformsPurple[i].SetActive(false);
            }
            
        }
        else
        {
            for (i = 0; i <platformsPurple.Length; i++) // If player color = purple, enable purle.
            {
                platformsPurple[i].SetActive(true);
                platformsGreen[i].SetActive(false);
            }
        }
    }
}
