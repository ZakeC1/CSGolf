using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Strokes : MonoBehaviour
{
    private GameObject strokes;
    public static int currentStrokes = 0;
    // Variables

    void Start()
    {
        strokes = GameObject.Find("StrokeNum");
    }
    // Finds Game Object


    void Update()
    {
        strokes.GetComponent<TextMeshProUGUI>().text = "" + currentStrokes;
    }
    // Replaces Text
}
