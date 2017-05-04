using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button highscores;
    public Button quit;
    public Button play;
    public Text introtext;
    public System.Diagnostics.Stopwatch delay = new System.Diagnostics.Stopwatch();

    void Start()
    {
        introtext.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.75f);
        play.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        highscores.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.4f);
        quit.transform.position = new Vector3(Screen.width * 0.975f, Screen.height * 0.95f);
    }

    public void Begin()
    {
        delay.Start();
        while (delay.ElapsedMilliseconds != 500)
        {
        }
        delay.Reset();
        SceneManager.LoadScene("In-Game Screen");
    }

    public void GetHighscores()
    {
        delay.Start();
        while (delay.ElapsedMilliseconds != 500)
        {
        }
        delay.Reset();
        SceneManager.LoadScene("Highscore List");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
