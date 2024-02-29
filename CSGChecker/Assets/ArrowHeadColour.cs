using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHeadColour : MonoBehaviour
{
    public float forceColour = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            if (forceColour > 1)
            {
                forceColour = 1;
            }
            forceColour -= 0.00769f;
            GetComponent<SpriteRenderer>().color = new Color(1, forceColour, forceColour);
        }

        if (Input.GetKey("s"))
        {
            if (forceColour < 0)
            {
                forceColour = 0;
            }
            forceColour += 0.00769f;
            GetComponent<SpriteRenderer>().color = new Color(1, forceColour, forceColour);
        }
    }
}
