using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Strokes : MonoBehaviour
{
    private GameObject strokes;
    // Start is called before the first frame update
    void Start()
    {
        strokes = GameObject.Find("StrokeNum");
    }

    // Update is called once per frame
    void Update()
    {
        strokes.GetComponent<TextMeshProUGUI>().text = "" + MasterScript.currentStrokes;
    }
}
