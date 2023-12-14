using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    #region variables
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 7f;

    private Vector3 moveDirection;
    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;

    public float gravity = -9.81f;
    public float jumpSpeed = 4f;
    public float jumpheight = 4f;

    private CharacterController characterController;

    private bool isPlayerMovementEnabled = true;

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isPlayerMovementEnabled)
        {
            //Debug.Log($"Gravity: {gravity}, Velocity: {velocity.y}");

            Move();
        }
        //else
        //{
        //    Debug.Log($"Gravity: {gravity}, Velocity: {velocity.y}");
        //}
    }

    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        float MoveZ = Input.GetAxis("Vertical");
        float MoveX = Input.GetAxis("Horizontal");

        moveDirectionZ = new Vector3(0, 0, MoveZ);
        moveDirectionX = new Vector3(MoveX, 0, 0);
        moveDirection = transform.TransformDirection(moveDirectionX + moveDirectionZ);

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //walk
        {
            Walk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //run
        {
            Run();
        }

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space)) // jump
            {
                Jump();
            }
            if (moveDirection != Vector3.zero)// idle
            {
                Idle();
            }
        }

        // Move the character
        characterController.Move((moveDirection * moveSpeed + velocity) * Time.deltaTime);
    }

    private void Walk()
    {
        characterController.Move(moveDirection * walkSpeed * Time.deltaTime);
    }

    private void Run()
    {
        characterController.Move(moveDirection * runSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
    }

    private void Idle()
    {
        // Add idle behavior here if needed
    }

    public void SetPlayerMovementEnabled(bool enable)
    {
        isPlayerMovementEnabled = enable;
    }
}
