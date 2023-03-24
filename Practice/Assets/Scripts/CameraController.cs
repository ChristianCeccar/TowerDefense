using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Movement based Scroll Wheel Zoom.

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.localPosition += -Vector3.up * Input.GetAxis("Mouse ScrollWheel") * 5;
        }
    }
}
