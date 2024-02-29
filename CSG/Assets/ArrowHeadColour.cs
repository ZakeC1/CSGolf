using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHeadColour : MonoBehaviour
{
    public float forceColour = 1;
    // Variables

    void Start()
    {
        
    }

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
        // Increases Colour of ArrowHead with Limit

        if (Input.GetKey("s"))
        {
            if (forceColour < 0)
            {
                forceColour = 0;
            }
            forceColour += 0.00769f;
            GetComponent<SpriteRenderer>().color = new Color(1, forceColour, forceColour);
        }
        // Decreases Colour of ArrowHead with Limit
    }
}
