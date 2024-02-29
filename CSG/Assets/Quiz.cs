using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    List<string> questions = new List<string>() { "EQ1", "EQ2", "EQ3", "MQ1", "MQ2", "MQ3", "HQ1", "HQ2", "HQ3" };
    List<string> correctAnswer = new List<string>() { "4", "1", "3", "4", "1", "3", "4", "1", "3" };
    List<string> firstChoice = new List<string>() { "11", "12", "13", "11", "12", "13", "11", "12", "13" };
    List<string> secondChoice = new List<string>() { "21", "22", "23", "21", "22", "23", "21", "22", "23" };
    List<string> thirdChoice = new List<string>() { "31", "32", "33", "31", "32", "33", "31", "32", "33" };
    List<string> fourthChoice = new List<string>() { "41", "42", "43", "41", "42", "43", "41", "42", "43" };
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
    // Variables

    void Start()
    {
        par = 2;
        totalScore = 1000 - ((Strokes.currentStrokes - par) * 100);
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
        // Checks the Difficulty Picked

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
        // Define Values and Finds Objects
    }

    // Update is called once per frame
    void Update()
    {
        if (questionCheck == true)
        {
            randNum = Random.Range(0+difNum, 3+difNum);
            question.GetComponent<TextMeshProUGUI>().text = questions[randNum];
            answer1.GetComponent<TextMeshProUGUI>().text = firstChoice[randNum];
            answer2.GetComponent<TextMeshProUGUI>().text = secondChoice[randNum];
            answer3.GetComponent<TextMeshProUGUI>().text = thirdChoice[randNum];
            answer4.GetComponent<TextMeshProUGUI>().text = fourthChoice[randNum];
            scoreNum.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
            questionCheck = false;
        }
        // Diplays Random Question

        if (choiceCheck == true)
        {
            if (Buttons.button1 == true)
            {
                selectedAns = answer1.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton1;
                Buttons.button1 = false;
            }
            // Checks Button1

            if (Buttons.button2 == true)
            {
                selectedAns = answer2.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton2;
                Buttons.button2 = false;
            }
            // Checks Button2

            if (Buttons.button3 == true)
            {
                selectedAns = answer3.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton3;
                Buttons.button3 = false;
            }
            // Checks Button3

            if (Buttons.button4 == true)
            {
                selectedAns = answer4.gameObject.name;
                selectCheck = true;
                ansCheck = ansButton4;
                Buttons.button4 = false;
            }
            // Checks Button4

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
            // Checks Correct Answer with Effects
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
            // Incorrect Answers Effect
        }
    }
    public void endQuiz()
    {
        LastUI.par = par;
        LevelEnd.quizChecker = true;
    }
    // Function to Chnage Static Variables

    public void timerEndQuiz()
    {
        totalScore -= 300;
        wait();
    }
    // Deducts Score with Wait


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
            // Countdown Time
        }


    }
    // Funtion to Wait

}
