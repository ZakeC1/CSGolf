using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int scoreCount = 100;
    static ScoreBoard scoreBoard;
    static string seperator = "~S~";

    [Header("SAVE PANEL")]
    public TMP_InputField inputName;
    public int inputScore;

    public GameObject scoreObject;
    public GameObject scoreRoot;
    public TMP_Text textName, textScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = this;
    }

    void Update()
    {
        inputScore = LastUI.finalScore;


    }

    public void ShowScore()
    {
        StartCoroutine(DisplayScore());
    }

    IEnumerator DisplayScore()
    {
        while (scoreRoot.transform.childCount > 0)
        {
            Destroy(scoreRoot.transform.GetChild(0).gameObject);
            yield return null;
        }

        List<PlayerScore> playerScore = GetScore();
        foreach (PlayerScore score in playerScore)
        {
            textName.text = score.playerName;
            textScore.text = score.playerScore.ToString();

            GameObject instantiatedScore = Instantiate(scoreObject);
            instantiatedScore.SetActive(true);

            instantiatedScore.transform.SetParent(scoreRoot.transform);
        }
    }
    public void SaveScoreNow()
    {
        SaveScore(inputName.text, inputScore);
    }
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

        }
        if (playerScores.Count < 1)
        {
            PlayerPrefs.SetString("Score0", name + seperator + score);
            return;
        }

        playerScores.Add(new PlayerScore(name, score));
        playerScores = playerScores.OrderByDescending(o => o.playerScore).ToList();

        for (int i = 0; i < scoreBoard.scoreCount; i++)
        {
            if (i >= playerScores.Count)
            {
                break;
            }
            PlayerPrefs.SetString("Score" + i, playerScores[i].GetFormat());
        }
    }
    // Update is called once per frame
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
}
