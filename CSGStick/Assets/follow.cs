using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Ball;
    public int CameraHeight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire2"))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 10;
            Camera.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mousePos.z)
                - new Vector3(0, -2, 2);

        }
        else Camera.transform.position = new Vector3(Ball.transform.position.x, CameraHeight, Ball.transform.position.z)
            - new Vector3(0, 0, 2);
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView -= 1;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView += 1;
        }
    }
}