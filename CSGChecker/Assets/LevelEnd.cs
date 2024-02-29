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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checker == true)
        {
            endPanel.SetActive(true);
            checker = false;

        }
        if (difChecker == true)
        {
            difPanel.SetActive(false);
            quizPanel.SetActive(true);
            difChecker = false;
        }
        if (quizChecker == true)
        {
            quizPanel.SetActive(false);
            LastUI.SetActive(true);
            quizChecker = false;
        }
     
    }
}
