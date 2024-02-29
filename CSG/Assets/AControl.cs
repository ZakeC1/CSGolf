using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AControl : MonoBehaviour
{
    public float yScale = 15;
    public float forceColour = 1;
    // Variables

    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, 0, 1);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, -1);

        }
        // Rotates the Ball
        if (Input.GetKey("w"))
        {
            yScale += .3f;
            forceColour -= 0.00769f;
            if (forceColour > 1)
            {
                forceColour = 1;
            }
            if (yScale > 54)
            {
                yScale = 54;
            }
            GetComponent<SpriteRenderer>().color = new Color(1, forceColour, forceColour);
            GetComponent<Transform>().localScale = new Vector3(6, yScale, 1);
        }
        // Increases Scale and Colour with Limits

        if (Input.GetKey("s"))
        {
            yScale -= .3f;
            forceColour += 0.00769f;
            if (forceColour < 0)
            {
                forceColour = 0;
            }
            if (yScale < 15)
            {
                yScale = 15;
            }
            GetComponent<SpriteRenderer>().color = new Color(1, forceColour, forceColour);
            GetComponent<Transform>().localScale = new Vector3(6, yScale, 1);
        }
        // Decreases the Scale and Colour with Limits

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(stop());
        }
        // Calls Function
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(6);
        GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 0);
    }
    // Resets Arrow
}
