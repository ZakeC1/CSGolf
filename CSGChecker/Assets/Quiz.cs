using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    List<string> questions = new List<string>() { "A particle is accelerated from 1m/s to 5m/s over a distance of 15m. Find the acceleration", "A particle is accelerated from 1m/s to 5m/s over a distance of 15m. Find the acceleration", "EQ3", "A car accelerates uniformly from 5m/s to 15m/s taking 7.5 seconds. How far did it travel during this period", "A car accelerates uniformly from 5m/s to 15m/s taking 7.5 seconds. How far did it travel during this period", "MQ3", "HQ1", "HQ2", "HQ3" };
    List<string> correctAnswer = new List<string>() { "4", "1", "3", "4", "1", "3", "4", "1", "3" };
    List<string> firstChoice = new List<string>() { "0.8m/s-1", "0.8m/s-2", "13", "70m", "75m", "13", "11", "12", "13" };
    List<string> secondChoice = new List<string>() { "0.4m/s-2", "8m/s-2", "23", "100m", "100m", "23", "21", "22", "23" };
    List<string> thirdChoice = new List<string>() { "8m/s-2", "0.8m/s-1", "33", "80m", "80m", "33", "31", "32", "33" };
    List<string> fourthChoice = new List<string>() { "0.8m/s-2", "0.4m/s-2", "43", "75m", "70m", "43", "41", "42", "43" };
    public static string selectedAns;
    private GameObject question;
    private GameObject answer1;
    private GameObject answer2;
    private GameObject answer3;
    private GameObject answer4;
    private GameObject ansButton1;
    private GameObject ansButton2;
    private GameObject ansButton3;
    private GameObject ansButton4;
    private GameObject scoreNum;
    private GameObject quizPanel;
    private GameObject ansCheck;
    public GameObject nextScreen;
    public GameObject correcting;
    public GameObject countDown;
    public static bool choiceCheck;
    float timeCount = 0f;
    int deNum = 10;
    bool selectCheck;
    int randNum;
    bool questionCheck;
    int difNum;
    int totalScore;
    public int par;
    int timeUsed;

    // Start is called before the first frame update
    void Start()
    {
        par = 2;
        totalScore = 1000 - ((MasterScript.currentStrokes - par) * 100);
        if (LevelEnd.difSelector == "Easy")
        {
            difNum = 0;
        }
        if (LevelEnd.difSelector == "Medium")
        {
            difNum = 3;
        }
        if (LevelEnd.difSelector == "Hard")
        {
            difNum = 6;
        }
        choiceCheck = true;
        selectCheck = false;
        questionCheck = true;
        question = GameObject.Find("Question");
        answer1 = GameObject.Find("1");
        answer2 = GameObject.Find("2");
        answer3 = GameObject.Find("3");
        answer4 = GameObject.Find("4");
        ansButton1 = GameObject.Find("1Button");
        ansButton2 = GameObject.Find("2Button");
        ansButton3 = GameObject.Find("3Button");
        ansButton4 = GameObject.Find("4Button");
        scoreNum = GameObject.Find("Num");
    }

    // Update is called once per frame
    void Update()
    {
        if (questionCheck == true)
        {
            randNum = Random.Range(0+difNum, 2+difNum);
            question.GetComponent<TextMeshProUGUI>().text = questions[randNum];
            answer1.GetComponent<TextMeshProUGUI>().text = firstChoice[randNum];
            answer2.GetComponent<TextMeshProUGUI>().text = secondChoice[randNum];
            answer3.GetComponent<TextMeshProUGUI>().text = thirdChoice[randNum];
            answer4.GetComponent<TextMeshProUGUI>().text = fourthChoice[randNum];
            scoreNum.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
            questionCheck = false;
        }

        if (choiceCheck == true)
        {
            if (Buttons.button1 == true)
            {
                selectedAns = answer1.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton1;
                Buttons.button1 = false;
            }
            if (Buttons.button2 == true)
            {
                selectedAns = answer2.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton2;
                Buttons.button2 = false;
            }
            if (Buttons.button3 == true)
            {
                selectedAns = answer3.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton3;
                Buttons.button3 = false;
            }
            if (Buttons.button4 == true)
            {
                selectedAns = answer4.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton4;
                Buttons.button4 = false;
            }
        }

        if (selectCheck == true)
        {
            if (correctAnswer[randNum] == selectedAns)
            {
                Debug.Log("Correct!");
                timeUsed = Mathf.RoundToInt(Timer.maxTime - Timer.timeLeft);
                totalScore += 600 - timeUsed;
                scoreNum.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
                LastUI.finalScore = totalScore;
                ansCheck.GetComponent<Image>().color = new Color(0, 1, 0);
                selectCheck = false;
                choiceCheck = false;
                nextScreen.SetActive(true);
                correcting.GetComponent<TextMeshProUGUI>().text = "Correct!";
                wait();

            }
            else
            {
                totalScore -= 300;
                scoreNum.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
                LastUI.finalScore = totalScore;
                ansCheck.GetComponent<Image>().color = new Color(1, 0, 0);
                if (correctAnswer[randNum] == answer1.gameObject.name)
                {
                    ansButton1.GetComponent<Image>().color = new Color(0, 1, 0);
                }
                if (correctAnswer[randNum] == answer2.gameObject.name)
                {
                    ansButton2.GetComponent<Image>().color = new Color(0, 1, 0);
                }
                if (correctAnswer[randNum] == answer3.gameObject.name)
                {
                    ansButton3.GetComponent<Image>().color = new Color(0, 1, 0);
                }
                if (correctAnswer[randNum] == answer4.gameObject.name)
                {
                    ansButton4.GetComponent<Image>().color = new Color(0, 1, 0);
                }
                selectCheck = false;
                choiceCheck = false;
                nextScreen.SetActive(true);
                correcting.GetComponent<TextMeshProUGUI>().text = "Incorrect!";
                wait();
            }
        }
    }
    public void endQuiz()
    {
        LastUI.par = par;
        LevelEnd.quizChecker = true;
    }
    public void timerEndQuiz()
    {
        totalScore -= 300;
        wait();
    }


    public void wait()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= 1) 
        {
            timeCount = timeCount % 1;
            deNum -= 1;
            if (deNum >= 0)
            {
                countDown.GetComponent<TextMeshProUGUI>().text = deNum.ToString();
            }
            else
            {
                endQuiz();
            }
        }


    }

}
