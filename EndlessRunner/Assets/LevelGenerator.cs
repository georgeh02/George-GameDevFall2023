using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform tile;
    [SerializeField] private Transform obstacle;
    private Vector3 tileSpawnLocation;
    private Vector3 obstacleSpawnLocation;
    private bool isSpawningTile = false;
    public float[] rowList = { -12.7f, -9.7f, -6.7f, -3.7f, -0.7f, 2.3f, 5.3f, 8.3f, 11.3f, 14.3f };
    //public float[] rowList = { -12.7f, -6.7f, -0.7f, 5.3f, 11.3f};
    //public float[] rowList = { -12.7f, -0.7f, 11.3f };
    public float[] laneList = { -2.5f, 0f, 2.5f };

    void Start()
    {
        StartCoroutine(SpawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        float tileSpawnZ = tileSpawnLocation.z;
        if (PlayerManager.gameOver == false && PauseScript.GameIsPaused == false && player.position.z > tileSpawnZ - 60f)
        {
            StartCoroutine(SpawnTile());
        }
    }

    IEnumerator SpawnTile()
    {
        //isSpawningTile = true;
        tileSpawnLocation.z += 30;
        StartCoroutine(SpawnObstacle(tileSpawnLocation));
        Transform newTile = Instantiate(tile, tileSpawnLocation, tile.rotation);
        StartCoroutine(DestroyObj(newTile));

        yield return null;
        //isSpawningTile = false;
    }

    IEnumerator SpawnObstacle(Vector3 tileSpawnLocation)
    {
        List<float> usedRows = new List<float>();
        obstacleSpawnLocation = tileSpawnLocation;
        obstacleSpawnLocation.y = obstacle.position.y;

        float row1 = chooseRow(usedRows);
        obstacleSpawnLocation.z = tileSpawnLocation.z + row1;
        obstacleSpawnLocation.y = chooseHeight();
        usedRows.Add(row1);
        obstacleSpawnLocation.x = -2.5f;
        Transform newObstacle1 = Instantiate(obstacle, obstacleSpawnLocation, obstacle.rotation);

        
        float row2 = chooseRow(usedRows);
        obstacleSpawnLocation.z = tileSpawnLocation.z + row2;
        obstacleSpawnLocation.y = chooseHeight();
        usedRows.Add(row2);
        obstacleSpawnLocation.x = 0f;
        Transform newObstacle2 = Instantiate(obstacle, obstacleSpawnLocation, obstacle.rotation);

        float row3 = chooseRow(usedRows);

        while ((Mathf.Abs(row3 - row2) <= 6 && Mathf.Abs(row2 - row1) <= 6) || usedRows.Count(value => value == row3) >= 2)
        {
            row3 = chooseRow(usedRows);
        }

        obstacleSpawnLocation.z = tileSpawnLocation.z + row3;
        obstacleSpawnLocation.y = chooseHeight();
        usedRows.Add(row3);
        obstacleSpawnLocation.x = 2.5f;
        Transform newObstacle3 = Instantiate(obstacle, obstacleSpawnLocation, obstacle.rotation);

        StartCoroutine(DestroyObj(newObstacle1));
        StartCoroutine(DestroyObj(newObstacle2));
        StartCoroutine(DestroyObj(newObstacle3));

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

    int chooseHeight()
    {
        return Random.Range(1, 3);
    }

    float chooseRow(List<float> usedRows)
    {
        int rowIndex = Random.Range(0,10);
        usedRows.Add(rowList[rowIndex]);
        return rowList[rowIndex];

    }

    float chooseLane()
    {
        int laneIndex = Random.Range(0, 3);
        return laneList[laneIndex];
    }
}
