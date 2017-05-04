using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPieceWindow : MonoBehaviour {

    public static bool pieceneeded;
    public static bool gameover;

    void Start()
    {
        gameover = false;
        pieceneeded = false;
    }

    void Update()
    {
        if (pieceneeded)
        {
            Destroy(gameObject);
            if (!gameover)
            {
                pieceneeded = false;
            }
        }
	}
}
