using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    public float speed;
    public int life;
    private Rigidbody2D rb2d;
    private GameObject gameover;

    static int numberOfPlayers;
    public Sprite[] sprites;
    public Vector3[] spawnPositions;
    private int HowManyPlayers;
    

	// Use this for initialization
	void Start () {
        //get the number of connected players
        gameover = GameObject.Find("GameOverText");

        gameover.GetComponent<Text>().enabled = false;
        HowManyPlayers = Network.connections.Length;
        Debug.Log(HowManyPlayers);
        if (numberOfPlayers >= 4)
        {
            numberOfPlayers++;
            Destroy(gameObject);
        }
        int positionTableOffset;
        int x = GameObject.Find("GameController").GetComponent<GameController>().GetX();
        if (x == 14)
        {
            positionTableOffset = 0;
        }
        else if(x == 22)
        {
            positionTableOffset = 4;
        }
        else if(x == 26)
        {
            positionTableOffset = 8;
        }
        else
        {
            positionTableOffset = 0;
           Debug.Log("cos jest zle " + x);
        }

        rb2d = GetComponent<Rigidbody2D>();
        GameObject.Find("GameController").GetComponent<GameController>().LevelScan();
        int playerIndex = numberOfPlayers;
        GetComponent<SpriteRenderer>().sprite = sprites[playerIndex];
        transform.position = spawnPositions[playerIndex + positionTableOffset];
        numberOfPlayers++;
	}

    void OnDestroy()
    {
        numberOfPlayers--;
        if(HowManyPlayers > 0)
        {
            if(numberOfPlayers == 0)
            {
                Debug.Log("Draw!");
            }
            else
            {
                
                Debug.Log("You lost!");
            }
        }
        //int i = Application.loadedLevel; tak się przechodzi do nastepnej rundy ale trzeba wszystko przeładować kurde
        //Application.LoadLevel(i + 1);
        else
        {
            gameover.GetComponent<Text>().text = "Game over!";
            gameover.GetComponent<Text>().enabled = true;
            Debug.Log("You lost!");
            Application.LoadLevel("mainMenu");
        }
    }
    
    //public override void OnStartLocalPlayer()
    //{
    //    GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.123f, 0.123124f);
    //}

    // Update is called once per frame
    void Update () {
        HowManyPlayers = Network.connections.Length;
        if (!isLocalPlayer)
        {   
            return;
        }

        if (HowManyPlayers > 0)
        {
            if (numberOfPlayers == 1)
            {
                Debug.Log("You won!");
            }
        }
        //Get input from player
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //prevent diagonal movement
        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(y) >= Mathf.Abs(x))
            x = 0;

        //Calculate movement
        Vector2 movement = new Vector2(x, y) * speed;

        //Set movement
        rb2d.velocity = movement;
	}
}
