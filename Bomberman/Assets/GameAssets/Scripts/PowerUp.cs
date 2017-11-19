using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public int bombs;
    public int firePower;
    public int speed;
    public int life;

    GameController gameController;

    public void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.level[(int)transform.position.x, (int)transform.position.y] = gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //See if we have collided with the player
        if (collision.gameObject.tag == "Player")
        {
            //Gather references to components
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            BombSpawner BombSpawner = collision.gameObject.GetComponent<BombSpawner>();

            //adjust the values
            playerController.speed += speed;
            playerController.life += life;
            BombSpawner.numberOfBombs += bombs;
            BombSpawner.firePower += firePower;

            //Remove the powerup
            Destroy(gameObject);
        }
    }
}
