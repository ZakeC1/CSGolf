using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject quizPanel;
    public GameObject difPanel;
    public GameObject LastUI;
    public static bool checker = false;
    public static bool difChecker = false;
    public static bool quizChecker = false;
    public static string difSelector;
    // Variables

    void Start()
    {

    }

    void Update()
    {
        if (checker == true)
        {
            endPanel.SetActive(true);
            checker = false;

        }
        // Loads EndPanel
        if (difChecker == true)
        {
            difPanel.SetActive(false);
            quizPanel.SetActive(true);
            difChecker = false;
        }
        // Loads Quiz
        if (quizChecker == true)
        {
            quizPanel.SetActive(false);
            LastUI.SetActive(true);
            quizChecker = false;
        }
        //Loads Last UI
     
    }
}
