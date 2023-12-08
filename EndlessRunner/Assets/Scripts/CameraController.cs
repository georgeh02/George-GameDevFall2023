using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    Vector3 lastPlayerPosition;


    void Start()
    {
        //offset = transform.position - player.position;
        transform.position = player.position + new Vector3(0, 4, 9);
    }

    void LateUpdate()
    {
        //OLD VERSION
        //Vector3 target = new Vector3(transform.position.x, transform.position.y, player.position.z);
        //transform.position = Vector3.Lerp(transform.position, target, 10 * Time.deltaTime);
        //transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.25f);

        Vector3 currentPlayerPosition = player.transform.position;
        float distanceMoved = currentPlayerPosition.z - lastPlayerPosition.z;
        lastPlayerPosition = currentPlayerPosition;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceMoved);
    }


}