using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static bool dif1;
    public static bool dif2;
    public static bool dif3;
    public static bool button1;
    public static bool button2;
    public static bool button3;
    public static bool button4;
    // Start is called before the first frame update
    void Start()
    {
        button1 = false;
        button2 = false;
        button3 = false;
        button4 = false;
        dif1 = false;
        dif2 = false;
        dif3 = false;
    }

    public void Button_Click1()
    {
        button1 = true;
    }
    public void Button_Click2()
    {
        button2 = true;
    }
    public void Button_Click3()
    {
        button3 = true;
    }
    public void Button_Click4()
    {
        button4 = true;
    }
    public void Button_ClickDif1()
    {
        LevelEnd.difSelector = "Easy";
        LevelEnd.difChecker = true;
    }
    public void Button_ClickDif2()
    {
        LevelEnd.difSelector = "Medium";
        LevelEnd.difChecker = true;
    }
    public void Button_ClickDif3()
    {
        LevelEnd.difSelector = "Hard";
        LevelEnd.difChecker = true;
    }

    public void Menu()
    {
        MasterScript.currentStrokes = 0;
        SceneManager.LoadScene("Menu");
    }
    public void Leader()
    {
        MasterScript.currentStrokes = 0;
        SceneManager.LoadScene("Menu");
        MainMenu.Leaderboards = true;
    }
    public void NextLevel()
    {
        MasterScript.currentStrokes = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
