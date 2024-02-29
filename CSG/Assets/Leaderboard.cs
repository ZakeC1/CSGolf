using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    int scoreCount = 100;
    static Leaderboard scoreBoard;
    static string seperator = "~S~";
    public TMP_InputField inputName;
    public int inputScore;
    public GameObject scoreObject;
    public GameObject scoreRoot;
    public TMP_Text textName, textScore;
    // Variables

    void Start()
    {
        scoreBoard = this;
    }
    // Define Varibale as This Object

    void Update()
    {
        inputScore = LastUI.finalScore;
    }
    // Sets Score For Leaderboards

    public void ShowScore()
    {
        StartCoroutine(DisplayScore());
    }
    // Calls Coroutine to Display Score

    IEnumerator DisplayScore()
    {
        while (scoreRoot.transform.childCount > 0)
        {
            Destroy(scoreRoot.transform.GetChild(0).gameObject);
            yield return null;
        }
        // Destroys Child Objects of scoreRoot

        List<PlayerScore> playerScore = GetScore();
        foreach (PlayerScore score in playerScore)
        {
            textName.text = score.playerName;
            textScore.text = score.playerScore.ToString();

            GameObject instantiatedScore = Instantiate(scoreObject);
            instantiatedScore.SetActive(true);

            instantiatedScore.transform.SetParent(scoreRoot.transform);
        }
        // Counts Amount of Scores and Instaniates them for Display
    }
    public void SaveScoreNow()
    {
        SaveScore(inputName.text, inputScore);
    }
    // Function to Call SaveScore Function

    public static void SaveScore(string name, int score)
    {
        List<PlayerScore> playerScores = new List<PlayerScore>();
        for (int i = 0; i < scoreBoard.scoreCount; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i))
            {
                string[] scoreFormat = PlayerPrefs.GetString("Score" + i).Split(new string[] { seperator }, System.StringSplitOptions.RemoveEmptyEntries);
                playerScores.Add(new PlayerScore(scoreFormat[0], int.Parse(scoreFormat[1])));
            }
            else
            {
                break;
            }
            // Checks for Key "Score" ans Seperates String by the Key ~S~

        }
        if (playerScores.Count < 1)
        {
            PlayerPrefs.SetString("Score0", name + seperator + score);
            return;
        }
        // Sets First Score

        playerScores.Add(new PlayerScore(name, score));
        playerScores = playerScores.OrderByDescending(o => o.playerScore).ToList();
        // Orders List playerScores

        for (int i = 0; i < scoreBoard.scoreCount; i++)
        {
            if (i >= playerScores.Count)
            {
                break;
            }
            PlayerPrefs.SetString("Score" + i, playerScores[i].GetFormat());
        }
        // Adds Score in Next Space
    }

    public List<PlayerScore> GetScore()
    {
        List<PlayerScore> playerScores = new List<PlayerScore>();
        for (int i = 0; i <scoreBoard.scoreCount; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i))
            {
                string[] scoreFormat = PlayerPrefs.GetString("Score" + i).Split(new string[] { seperator }, System.StringSplitOptions.RemoveEmptyEntries);
                playerScores.Add(new PlayerScore(scoreFormat[0], int.Parse(scoreFormat[1])));
            }
            else
            {
                break;
            }
        }

        return playerScores;
    }
    // Returns Score as List
}

public class PlayerScore
{
    public string playerName;
    public int playerScore;

    public PlayerScore (string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }

    public string GetFormat()
    {
        return playerName + "~S~" + playerScore;
    }
    // Sets Variables to Correct Type
}
