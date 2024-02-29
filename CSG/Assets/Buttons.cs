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
    // Variables

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
    // Defines Values

    public void Button_Click1()
    {
        button1 = true;
    }
    // Quiz Answer 1

    public void Button_Click2()
    {
        button2 = true;
    }
    // Quiz Answer 2

    public void Button_Click3()
    {
        button3 = true;
    }
    // Quiz Answer 3

    public void Button_Click4()
    {
        button4 = true;
    }
    // Quiz Answer 4

    public void Button_ClickDif1()
    {
        LevelEnd.difSelector = "Easy";
        LevelEnd.difChecker = true;
    }
    // Difficulty Choice Easy

    public void Button_ClickDif2()
    {
        LevelEnd.difSelector = "Medium";
        LevelEnd.difChecker = true;
    }
    // Difficulty Choice Medium

    public void Button_ClickDif3()
    {
        LevelEnd.difSelector = "Hard";
        LevelEnd.difChecker = true;
    }
    // Difficulty Choice Hard

    public void Menu()
    {
        Strokes.currentStrokes = 0;
        SceneManager.LoadScene("Menu");
    }
    // Menu Loader

    public void Leader()
    {
        Strokes.currentStrokes = 0;
        SceneManager.LoadScene("Menu");
        MainMenu.Leaderboards = true;
    }
    // Leaderboards Loader

    public void NextLevel()
    {
        Strokes.currentStrokes = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Loads Next Level

}
