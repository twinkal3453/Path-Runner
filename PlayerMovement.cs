using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //This is a reference to the Rigidbody component called"rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500;
   


    //We marked this as "Fixed"Update because we 
    //are using it to mass with Physics.
    void FixedUpdate()
    {
        //Add a forward force
        rb.AddForce(0, 0, forwardForce  * Time.deltaTime);

        if (Input.GetKey("d"))//if the Player is pressing the "d" key
        {
            //Add a force tho the right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")) // If the player is pressint the "a" key
        {
            //Add a force to the left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
