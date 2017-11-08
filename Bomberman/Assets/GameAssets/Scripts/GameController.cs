using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    public GameObject levelHolder;
    public const int X = 22;
    public const int Y = 13;
    public GameObject[,] level = new GameObject[X, Y];

    // Use this for initialization
    void Start()
    {
        LevelScan();
    }

    public void LevelScan()
    {
        var objects = levelHolder.GetComponentsInChildren<Transform>();

        foreach (var child in objects)
        {
            level[(int)child.position.x, (int)child.position.y] = child.gameObject;
        }

        level[0, 0] = null;
    }
}
