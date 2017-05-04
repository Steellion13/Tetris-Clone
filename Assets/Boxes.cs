using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boxes : MonoBehaviour {

    public static int gridWeight = 10;
    public static int gridHeight = 20;
    public static Transform[,] grid = new Transform[gridWeight, gridHeight];
    static double fall = 0;
    static double delay = 0;
    static double droptime = 1;

    public static bool isInsideGrid(Vector2 pos)
    {
        return (pos.x >= 0 && pos.x < gridWeight && pos.y >= 0);
    }

    public static void Delete(int y)
    {
        for (int x = 0; x < gridWeight; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static bool isFull(int y)
    {
        for (int x = 0; x < gridWeight; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public static void DeleteRow()
    {
        int turnlines = 0;
        int turnscore = 0;
        for (int y = 0; y < gridHeight; y++)
        {
            if (isFull(y))
            {
                Delete(y);
                RowDownAll(y + 1);
                y--;
                turnlines += 1;
                InGameScene.level = (turnlines + InGameScene.lines) / 5 + 1;
            }
        }
        InGameScene.lines += turnlines;
        turnscore = 100 + (InGameScene.level - 1) * 25;
        if (turnlines != 1)
        {
            if (turnlines == 2)
            {
                turnscore *= 3;
            }
            else
            {
                turnscore *= turnlines * turnlines / 2;
            }
        }
        droptime = Mathf.Pow((float)0.9, InGameScene.level);
        InGameScene.score += turnscore;
    }

    public static void RowDown(int y)
    {
        for (int x = 0; x < gridWeight; x++)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void RowDownAll(int y)
    {
        for (int i = y; i < gridHeight; ++i)
        {
            RowDown(i);
        }
    }

    void Start()
    {
        if (!isValidPosition())
        {
            FindObjectOfType<InGameScene>().StartCoroutine("GrowGameOverFont");
            enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time - delay >= 0.1)
        {
            transform.position += new Vector3(1, 0);
            if (isValidPosition())
            {
                GridUpdate();
            }
            else
            {
                transform.position += new Vector3(-1, 0);
            }
            delay = Time.time;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time - delay >= 0.1)
        {
            transform.position += new Vector3(-1, 0);
            if (isValidPosition())
            {
                GridUpdate();
            }
            else
            {
                transform.position += new Vector3(1, 0);
            }
            delay = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
            if (isValidPosition())
            {
                GridUpdate();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }
        }
        else if (Time.time - fall >= droptime)
        {
            transform.position += new Vector3(0, -1);
            if (isValidPosition())
            {
                GridUpdate();
            }
            else
            {
                transform.position += new Vector3(0, 1);
                DeleteRow();
                FindObjectOfType<SpawnBox>().SpawnNewBox();
                enabled = false;
            }
            fall = Time.time;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Time.time - delay >= 0.1)
        {
            transform.position += new Vector3(0, -1);
            if (isValidPosition())
            {
                GridUpdate();
            }
            else
            {
                transform.position += new Vector3(0, 1);
                DeleteRow();
                FindObjectOfType<SpawnBox>().SpawnNewBox();
                enabled = false;
            }
            delay = Time.time;
        }
    }

    bool isValidPosition()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = child.position;
            if (!isInsideGrid(v))
            {
                return false;
            }
            if (grid[(int)v.x, (int)v.y] != null && grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void GridUpdate()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWeight; x++)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform child in transform)
        {
            Vector2 v = child.position;
            grid[(int)v.x, (int)v.y] = child;
        }
    }
}
