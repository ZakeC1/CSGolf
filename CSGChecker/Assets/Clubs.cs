using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clubs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ConstantForce>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<ConstantForce>().enabled = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(obj: gameObject);
    }
}
