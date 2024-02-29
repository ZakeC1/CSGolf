using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject quizObject;
    public Image timerBar;
    public static float maxTime = 120f;
    public static float timeLeft;
    public float timeColourG = 1f;
    public float timeColourR = 0f;
    public float elapsed = 0f;
    public float colDiv;
    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        colDiv = 1 / (maxTime*2);
        timerBar.color = new Color(timeColourR, timeColourG, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Quiz.choiceCheck == true)
        {
            if (timeLeft > 0)
            {
                elapsed += Time.deltaTime;
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
                if (elapsed >= .5f)
                {
                    elapsed = elapsed % .5f;
                    timeColourG -= colDiv;
                    timeColourR += colDiv;
                    timerBar.color = new Color(timeColourR, timeColourG, 0);
                }


            }
            else
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            quizObject.GetComponent<Quiz>().timerEndQuiz();
        }
    }
}
