using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    [Header("Transform references")]
    public Transform rootBody;
    public Transform pitchBody;

    [Header("Speeds")]
    public float playerSpeed = 2;
    public float mouseSpeed = 2f;

    // Private Variables
    private CharacterController characterController;
    private float yaw = 0f;
    private float pitch = 0f;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        // Move forward / backward
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    private void LateUpdate()
    {
        yaw += mouseSpeed * (Input.GetAxis("Mouse X") + Input.GetAxis("Horizontal"));
        // pitch += mouseSpeed * Input.GetAxis("Mouse Y"); // TODO: Bugged way, make it this for workshop template
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");
        // Limit rotation
        pitch = Mathf.Clamp(pitch, -45f, 15f);
        pitchBody.localEulerAngles = new Vector3(pitch, 0, 0);
        rootBody.eulerAngles = new Vector3(0, yaw, 0);

    }
}