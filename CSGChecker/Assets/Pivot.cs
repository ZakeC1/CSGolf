using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate (0, 1, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, -1, 0);
        
        }




    }
}
