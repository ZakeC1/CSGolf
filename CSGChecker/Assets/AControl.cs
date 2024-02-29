using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AControl : MonoBehaviour
{
    public float yScale = 15;
    public float forceColour = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(stop());
        }
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitForSeconds(.5f);
        GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 0);
    }
}
