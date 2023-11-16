using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    //private Vector3 velocity = Vector3.zero;

    private float elapsedTime = 0f;
    [SerializeField] private float speedInterval = 10f;
    //[SerializeField] private float speedAmount = 1f;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        //elapsedTime += Time.deltaTime;

        //if (elapsedTime >= speedInterval)
        //{
        //    //offset.z = Mathf.Lerp(offset.z, offset.z + speedAmount, 10 * Time.deltaTime);
        //    offset.z = Mathf.Lerp(offset.z, offset.z - (transform.position.z - player.position.z), 10 * Time.deltaTime);
        //    elapsedTime = 0f;
        //}

        //offset.z = offset.z - (transform.position.z - player.position.z) - 3;

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, 10 * Time.deltaTime);
    }
}