using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float flySpeed = 10.0f;
    public float pitchSpeed = 1.0f;
    public float rollSpeed = 1.0f;
    public float yawSpeed = 1.0f;
    public float rotateSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //Flight Controls

        Vector3 transformRotation = Vector3.zero;
        //Pitch
        transformRotation += (new Vector3(-Input.GetAxisRaw("Pitch"), 0, 0) * pitchSpeed) * Time.deltaTime;
        //Roll
        transformRotation += (new Vector3(0, -Input.GetAxisRaw("Roll"), 0) * pitchSpeed) * Time.deltaTime;
        //Yaw
        transformRotation += (new Vector3(0, 0, Input.GetAxisRaw("Yaw")) * pitchSpeed) * Time.deltaTime;

        //If we did rotate
        if (transformRotation != Vector3.zero)
        {
            //transformRotation += transform.position;
            //Vector3 relativePos = transformRotation - transform.position;

            //transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.Rotate(transformRotation * Time.deltaTime * rotateSpeed, Space.Self);
        }

        //Fly forwards

        //transform.position += transform.GetChild(0).transform.forward * flySpeed * Time.deltaTime;

        Vector3 forceDir = transform.GetChild(0).transform.forward * flySpeed * Time.deltaTime;
        GetComponent<Rigidbody>().AddForce(forceDir);
    }
}
