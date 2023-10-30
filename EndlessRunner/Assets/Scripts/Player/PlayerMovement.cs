using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 3;
    [SerializeField] private float duckForce = 3;
    [SerializeField] private float Gravity = -20;
    private int currentLane = 1;

    [SerializeField] private float laneWidth = 2f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (!PauseScript.GameIsPaused)
        {
            direction.z = moveSpeed;

            controller.Move(direction * Time.deltaTime);

            if (controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
                {
                    Jump();
                }

            }
            else
            {
                direction.y += Gravity * Time.deltaTime;
            }

            if (!controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    Duck();
                }

            }


            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                currentLane++;
                if (currentLane == 3)
                {
                    currentLane = 2;
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                currentLane--;
                if (currentLane == -1)
                {
                    currentLane = 0;
                }

            }

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (currentLane == 0)
            {
                targetPosition += Vector3.left * laneWidth;
            }
            else if (currentLane == 2)
            {
                targetPosition += Vector3.right * laneWidth;
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, 90 * Time.deltaTime);
            controller.center = controller.center;
        }


    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void Duck()
    {
        direction.y -= duckForce;
    }
}
