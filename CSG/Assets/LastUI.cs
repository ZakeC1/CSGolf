using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastUI : MonoBehaviour
{
    public GameObject levelPar;
    public GameObject userStrokes;
    public GameObject finScore;
    public static int par;
    public static int finalScore;
    // Variables

    void Start()
    {
        
    }


    void Update()
    {
        levelPar.GetComponent<TextMeshProUGUI>().text = par.ToString();
        userStrokes.GetComponent<TextMeshProUGUI>().text = Strokes.currentStrokes.ToString();
        finScore.GetComponent<TextMeshProUGUI>().text = finalScore.ToString();
        // Updates Texts in LastUI

    }
}
