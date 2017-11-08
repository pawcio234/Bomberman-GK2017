using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BombSpawner : NetworkBehaviour {

    public GameObject bomb;
    public int firePower = 1;
    public int numberOfBombs = 1;
    public float fuse = 2;

	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        //TODO: make shore we have moved +½ unit before we can drop another bomb.
        //TODO: refactor code.

        if (Input.GetButtonDown("Jump") && numberOfBombs >= 1)
        {
            CmdSpawnBomb();
        }
    }

    [Command]
    private void CmdSpawnBomb()
    {
        Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        var newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
        newBomb.GetComponent<Bomb>().firePower = firePower;
        newBomb.GetComponent<Bomb>().fuse = fuse;
        NetworkServer.Spawn(newBomb);
        numberOfBombs--;
        Invoke("AddBomb", fuse);
    }

    public void AddBomb()
    {
        numberOfBombs++;
    }
}
