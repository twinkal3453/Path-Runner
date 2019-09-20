using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;     //A reference to our PlayerMovement script
   
   // public float restartDelay = 2f;

    //This function runs When we hit another object.
    //We get information about the collision and call it "collisionInfo".
    private void OnCollisionEnter(Collision collisionInfo)
    {
        //We check if the object we collided with has a tag called "Obsticle".
        if(collisionInfo.collider.tag == "Obsticle")
        {
            movement.enabled = false;    //Disable the players movement.

            FindObjectOfType<GameManager>().EndGame ();
        }
        
    }
}
