using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PowerUpSpawner : NetworkBehaviour {

    public GameObject[] powerUps;
    PowerUpController powerUpController;
    //public int numberOfFirePowerUps;

    public void SpawnPowerUp()
    {
        if(!isServer)
        {
            return;
        }

        powerUpController = FindObjectOfType<PowerUpController>();

        int randomIndex = Random.Range(0, powerUps.Length);
        if(Random.Range(0f,1f) > 0.5f)
        {
            powerUpController.CmdSpawnPowerUp(transform.position, powerUps[randomIndex]);
        }
        //TODO: keep track of spawned powerups
    }

}
