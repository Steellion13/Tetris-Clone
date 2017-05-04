using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    public Button quit;
    public InputField namebox;
    public Button submit;
    public Text endtext;
    public static string playername;

	void Start ()
    {
        quit.transform.position = new Vector3(Screen.width * 0.975f, Screen.height * 0.95f);
        submit.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.4f);
        endtext.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.75f);
        endtext.text = "Game Over\nYou scored " + InGameScene.score.ToString("000000") + " points";
	}

    public void Submit ()
    {
        if (namebox.text.Length != 3)
        {
            namebox.text = "";
            namebox.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Try again";
        }
        else
        {
            playername = namebox.text;
            System.Diagnostics.Stopwatch delay = new System.Diagnostics.Stopwatch();
            delay.Start();
            while (delay.ElapsedMilliseconds != 500)
            {
            }
            delay.Stop();
            SceneManager.LoadScene("Highscore List");
        }
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
