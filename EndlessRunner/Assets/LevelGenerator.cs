using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform tile;
    [SerializeField] private Transform obstacle;
    private Vector3 tileSpawnLocation;
    private Vector3 obstacleSpawnLocation;
    private int random;


    void Start()
    {
        StartCoroutine(SpawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        float tileSpawnZ = tileSpawnLocation.z;
        if (PlayerManager.gameOver == false && PauseScript.GameIsPaused == false && player.position.z > tileSpawnZ - 30f)
        {
            StartCoroutine(SpawnTile());
        }
    }

    IEnumerator SpawnTile()
    {
        tileSpawnLocation.z += 30;
        obstacleSpawnLocation = tileSpawnLocation;
        obstacleSpawnLocation.x = chooseLane();
        obstacleSpawnLocation.y = 2f;

        Transform newTile = Instantiate(tile, tileSpawnLocation, tile.rotation);
        StartCoroutine(DestroyObj(newTile));
        Transform newObstacle = Instantiate(obstacle, obstacleSpawnLocation, obstacle.rotation);
        StartCoroutine(DestroyObj(newObstacle));
        yield return null;
    }

    IEnumerator DestroyObj(Transform newTile)
    {
        while (true)
        {
            Vector3 toTile = newTile.position - player.position;
            Vector3 playerForward = player.forward;
            float dotProduct = Vector3.Dot(toTile, playerForward);

            if (dotProduct < 0 && player.position.z > newTile.position.z + 30f)
            {
                Destroy(newTile.gameObject);
                break;
            }

            yield return null;
        }

    }


    float chooseLane()
    {
        random = Random.Range(-1, 2);
        if (random == -1)
        {
            return -2.5f;
        } else if (random == 1)
        {
            return 2.5f;
        }
        else
        {
            return 0;
        }

    }
}
