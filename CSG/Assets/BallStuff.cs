using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStuff : MonoBehaviour
{

    public float zforce;
    public Transform clubObj;
    public Transform arrow;
    public bool mouseEnd;
    public bool endMouse;
    // Variables

    void Start()
    {
        zforce = 30;
        mouseEnd = false;
        endMouse = false;
    }

    void Update()
    {
        if (Input.GetKeyDown ("space"))
        {
            GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            //Instantiate(clubObj, transform.position, clubObj.rotation);
            arrow.GetComponent<Transform>().position = transform.position;
        }
        // Spawns a new putter
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -1, 0);
        }
        // Rotates putter left
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0);
        }
        // Rotates putter right
        if (Input.GetKey("w"))
        {
            zforce += 9;
            Debug.Log(zforce);
        }
        // Adds force
        if (Input.GetKey("s"))
        {
            zforce -= 9;
            Debug.Log(zforce);
        }
        // Reduces Force
        if (zforce < 30)
        {
            zforce = 30;
        }
        if (zforce > 1200)
        {
            zforce = 1200;
        }
        // Restrictions for the force
        if (Input.GetButtonDown("Fire1") & mouseEnd == false)
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zforce);
            Strokes.currentStrokes += 1;
            mouseEnd = true;
            StartCoroutine(stop());
        }
        // Releases the putter
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hole")
        {
            Debug.Log("Completed!");
            LevelEnd.checker = true;
            mouseEnd = true;
            endMouse = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        }
        // Collision check with hole
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        arrow.GetComponent<Transform>().position = transform.position;
        if (endMouse == false)
        {
            mouseEnd = false;
        }
    }
    // Resets Ball
}
