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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelPar.GetComponent<TextMeshProUGUI>().text = par.ToString();
        userStrokes.GetComponent<TextMeshProUGUI>().text = MasterScript.currentStrokes.ToString();
        finScore.GetComponent<TextMeshProUGUI>().text = finalScore.ToString();
    }
}
