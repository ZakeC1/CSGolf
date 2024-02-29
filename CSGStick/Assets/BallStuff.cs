using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStuff : MonoBehaviour
{
    public Transform clubObj;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("space"))
        {
            GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
       
            Instantiate(clubObj, (transform.position) + new Vector3 (0,1,-1), clubObj.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hole")
        {

            Debug.Log("Completed!");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        }
    }
}
