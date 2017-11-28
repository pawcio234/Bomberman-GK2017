using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    public GameObject levelHolder;
    public int length;
    public int width;
    public static int X;
    public static int Y;
    public GameObject[,] level;
    // Use this for initialization
    void Start()
    {
        X = (length == 22) ? 22 : ((length == 13) ? 14 : ((length == 25) ? 26 : 0));//22;
        Y = (width == 13) ? 13 : ((width == 15) ? 15 : 0);//13;
        level = new GameObject[X, Y];
        LevelScan();
    }

    public int GetX()
    {
        return X;
    }

    public int GetY()
    {
        return Y;
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
