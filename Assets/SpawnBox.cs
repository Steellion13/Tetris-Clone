using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour {

    public GameObject[] boxList;
    public GameObject[] pieceimages;
    public int n;

    void Start()
    {
        SpawnNewBox();
    }

    public void SpawnNewBox()
    {
        transform.position = new Vector3(5, 19);
        if (n == 4 || n == 1 || n == 2)
        {
            transform.position += new Vector3(0, -1);
        }
        if (n == 0)
        {
            transform.position += new Vector3((float)0.5, (float)-0.5);
        }
        Instantiate(boxList[n], transform.position, Quaternion.identity);
        NextPieceWindow.pieceneeded = true;
        n = Random.Range(0, pieceimages.Length);
        Instantiate(pieceimages[n], new Vector3(Screen.width / 70, Screen.height / 35), Quaternion.identity);
    }

}
