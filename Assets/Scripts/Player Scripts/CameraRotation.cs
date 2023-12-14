using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    public float speed = 100f;

    private float xMouse;
    private float yMouse;
    private float xRotation = 0f;

    public CameraRotation cameraRotation;
    private bool camAllowedMove = true;

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor initially
        LockCursor();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //This is a joke :)
        if (camAllowedMove                                  
            
            
            
            
            ==                                            
            
            
            
                                                                                                                                                                                                                       true)

                  {
                   {
                {
                                   {
                        {
                                                     {
                                {



                                               {
                                        {
                                                                       {
                                                {
                                                    {
                                                                 {
                                                            {
                                                                                     {
                                                                    {
                                                                        { 
                                                                     xMouse = Input.            GetAxis("Mouse X")          * speed * Time.deltaTime;
                                        yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

            // Rotation up and down
                                   xRotation -= yMouse;
                  xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                                        transform.                localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                             player.Rotate(Vector3.up * xMouse);
                                    }    }     }     }     }      }     }     }     }
}}}}}}}}}

    private void LockCamera()
    {
        camAllowedMove = false;
    }

    // Lock the cursor
    private void LockCursor()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Unlock the cursor
    private void UnlockCursor()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Called when a panel is opened
    public void OnPanelOpened()
    {
        LockCamera();
        UnlockCursor();
    }

    // Called when a panel is closed
    public void OnPanelClosed()
    {
        LockCursor();
    }


}
