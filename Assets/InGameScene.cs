using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameScene : MonoBehaviour {

    public Button quit;
    public static int lines;
    public static int level;
    public static int score;
    public Text display;
    public Text nextpiece;
    public Text gameovertext;

    void Start()
    {
        score = 0;
        lines = 0;
        level = 1;
        display.text = "Level: " + level.ToString() + "\nLines: " + lines.ToString();
        display.transform.position = new Vector3(Screen.width * 0.35f, Screen.height * 0.5f);
        nextpiece.transform.position = new Vector3(Screen.width * 0.75f, Screen.height * 0.79f);
        quit.transform.position = new Vector3(Screen.width * 0.975f, Screen.height * 0.95f);
        gameovertext.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        gameovertext.text = null;
    }

	void Update()
    {
        level = (lines / 5) + 1;
        display.text = "Level: " + level.ToString() + "\nLines: " + lines.ToString() + "\nScore: " + score.ToString("000000");
    }

    IEnumerator GrowGameOverFont()
    {
        NextPieceWindow.pieceneeded = true;
        NextPieceWindow.gameover = true;
        yield return new WaitForSeconds(1);
        int fontsize = 0;
        gameovertext.text = "Game Over";
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.05f);
            fontsize += 2;
            gameovertext.fontSize = fontsize;
        }
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("End");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
