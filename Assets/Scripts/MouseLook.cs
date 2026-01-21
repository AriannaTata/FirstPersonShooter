using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // in modo tale che a ogni update non cambia la rotazione che deve essere fissa
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //la rotazione è ruotata di 90 gradi al massimo
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // sono 4 numeri che usano i numeri complessi 
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
