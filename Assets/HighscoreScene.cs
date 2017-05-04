using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreScene : MonoBehaviour {

    public Button play;
    public Button quit;
    public Text List;

    void Start()
    {
        quit.transform.position = new Vector3(Screen.width * 0.975f, Screen.height * 0.95f);
        play.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f);
        List.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.6f);
        int[] score = new int[10];
        string[] name = new string[10];
        List.GetComponent<Text>();
        string highscorefile = System.AppDomain.CurrentDomain.BaseDirectory + @"highscorelist.txt";
        string[] hff = System.IO.File.ReadAllLines(highscorefile);
        string[] highscores = new string[10];
        if (hff.Length < 10)
        {
            for (int b = hff.Length; b < 9; b++)
            {
                highscores[b] = "---000000";
            }
        }
        for (int j = 0; j < hff.Length; j++)
        {
            highscores[j] = hff[j];
        }
        for (int x = 0; x < 9; x++)
        {
            name[x] = highscores[x].Substring(0, 3);
            score[x] = int.Parse(highscores[x].Substring(3, 6));
        }
        for (int i = 0; i < 9; i++)
        {
            if (InGameScene.score > score[i])
            {
                for (int j = i; j < 9; j++)
                {
                    score[j + 1] = score[j];
                }
                for (int j = i; j < 9; j++)
                {
                    name[j + 1] = name[j];
                }
                score[i] = InGameScene.score;
                name[i] = End.playername;
                break;
            }
        }
        for (int k = 0; k < 9; k++)
        {
            highscores[k] = name[k] + score[k].ToString("000000");
        }
        System.IO.File.WriteAllLines(highscorefile, highscores);
        for (int i = 1; i < 10; i++)
        {
            List.text += "\n  " + i + ". " + name[i - 1] + " " + score[i - 1].ToString("000000");
        }
        if (name[9] == null)
        {
            name[9] = "---";
        }
        List.text += "\n10. " + name[9] + " " + score[9].ToString("000000") + "\n\nYour score:" + " " + InGameScene.score.ToString("000000");
    }

    public void Begin()
    {
        System.Diagnostics.Stopwatch delay = new System.Diagnostics.Stopwatch();
        delay.Start();
        while (delay.ElapsedMilliseconds != 500)
        {
        }
        delay.Stop();
        SceneManager.LoadScene("In-Game Screen");
    }

    public void Quit()
    {
        Application.Quit();
    } 
}
