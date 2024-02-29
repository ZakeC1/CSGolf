using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static bool Leaderboards = false;
    public GameObject Main;
    public GameObject LeaderBoard;
    public ScoreBoard scoreBoard;
    public void PlayGame ()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame ()
    {
        Debug.Log("Quitted!");
        Application.Quit();
    }

    void Update()
    {
        if (Leaderboards == true)
        {
            Main.SetActive(false);
            LeaderBoard.SetActive(true);
            scoreBoard.ShowScore();
            Leaderboards = false;
        }
        
    }
}
