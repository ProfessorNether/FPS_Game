using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    public float speed = 100f;

    public Camera cam;

    private float xMouse;
    private float yMouse;
    private float xRotation = 0f;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor initially
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerHealth.panelOpened)
        {
            // Unlock the cursor for free mouse movement
            UnlockCursor();

            xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

            // Rotation up and down
            xRotation -= yMouse;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * xMouse);
        }
        else
        {
            // Lock the cursor when the panel is opened
            LockCursor();
        }
    }

    // Lock the cursor
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Unlock the cursor
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
