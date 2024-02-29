using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static bool Leaderboards = false;
    public GameObject Main;
    public GameObject LeaderBoard;
    public Leaderboard Leaderboard;
    // Variables

    public void PlayGame ()
    {

        SceneManager.LoadScene("Level 1");
    }
    // Loads Level 1

    public void QuitGame ()
    {
        Debug.Log("Quitted!");
        Application.Quit();
    }
    // Quits Program

    void Update()
    {
        if (Leaderboards == true)
        {
            Main.SetActive(false);
            LeaderBoard.SetActive(true);
            Leaderboard.ShowScore();
            Leaderboards = false;
        }
        // Loads the Leaderboards
    }
}
