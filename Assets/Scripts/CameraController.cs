using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float speed = 10.0f;
    public float zoomSpeed = 1000.0f;

    private float _mult = 1.0f;

    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        var rotate = 0.0f;

        if (Input.GetKey(KeyCode.Q))
            rotate = -1.0f;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1.0f;


        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        transform.Rotate(Vector3.up * (Time.deltaTime * rotateSpeed * rotate * _mult), Space.World);
        transform.Translate(new Vector3(hor, 0, ver) * (Time.deltaTime * _mult * speed), Space.Self);

        transform.position += transform.up * (zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"));

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20.0f, 20.0f), transform.position.z);
        
        
    }
}