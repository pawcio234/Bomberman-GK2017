using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PowerUpController : NetworkBehaviour {

    [Command]
    public void CmdSpawnPowerUp(Vector3 position, GameObject powerUp)
    {
        var newPowerUp = Instantiate(powerUp, position,
            Quaternion.identity) as GameObject;
        NetworkServer.Spawn(newPowerUp);
    }

}
