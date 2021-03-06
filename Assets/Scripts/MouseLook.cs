﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MouseLook : MonoBehaviour
{
    private Camera cam;

    Vector3 mousePositonInstantaneous = Vector3.zero;

    private const float camScopeSpeed = 100f;
    private const float camPanSpeed = 200f;
    private const float camRotateSpeed = 30f;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float dx = (Input.mousePosition.x - mousePositonInstantaneous.x) / Screen.width;
            float dy = (Input.mousePosition.y - mousePositonInstantaneous.y) / Screen.height;
            transform.eulerAngles += new Vector3(Mathf.Clamp(dy, -2f, 2f) * -200f * Time.deltaTime, Mathf.Clamp(dx, -2f, 2f) * 200f * Time.deltaTime, 0f) * camRotateSpeed;
        }

        mousePositonInstantaneous = Input.mousePosition;

        Vector3 camPosition = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            camPosition.y -= Time.deltaTime * camScopeSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetKey(KeyCode.LeftArrow))
            camPosition -= Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * Time.deltaTime * camPanSpeed;
        if (Input.GetKey(KeyCode.RightArrow))
            camPosition += Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * Time.deltaTime * camPanSpeed;
        if (Input.GetKey(KeyCode.UpArrow))
            camPosition += Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * Time.deltaTime * camPanSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
            camPosition -= Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * Time.deltaTime * camPanSpeed;
        transform.position = camPosition;
    }
}