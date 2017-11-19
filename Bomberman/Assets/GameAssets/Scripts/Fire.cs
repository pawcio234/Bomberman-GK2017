using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    void Start()
    {
        //Remove fire when it's done.
        Destroy(gameObject, 0.3f);
    }

    void Update()
    {
        //Rotate effect
        transform.Rotate(0, 0, -45);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PowerUpSpawner>() != null)
        {
            //Make sure the fire dosn't kill the power up
            GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PowerUpSpawner>().SpawnPowerUp();
        }
        //Don't destroy other fires
        else if (collision.gameObject.GetComponent<Fire>() != null)
        {
            return;
        }     
        //If we have found a bomb, trigger it
        else if (collision.gameObject.GetComponent<Bomb>() != null)
        {
            collision.gameObject.GetComponent<Bomb>().Explode();
        }
        // LIFE BONUS LOGIC, NOT SURE IF WORKS AS EXPECTED !!!
        else if(collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController.life >= 1)
            {
                playerController.life--;
                return;
            }
        }

        //Remove the thing we collided with.
        Destroy(collision.gameObject);
    }
}
