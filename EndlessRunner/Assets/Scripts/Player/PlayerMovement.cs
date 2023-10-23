using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private int currentLane = 1;
    [SerializeField] private float laneWidth = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane++;
            if (currentLane == 3)
            {
                currentLane = 2;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        } else if (currentLane == 2)
        {
            targetPosition += Vector3.right * laneWidth;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 90 * Time.deltaTime);
    }
}
