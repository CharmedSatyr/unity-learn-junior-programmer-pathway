using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public List<GameObject> debrisPrefabs;

    public Vector3 ballSpawnPosition;
    public float ballMinimumYPosition = -10f;

    private GameManager gameManager;

    private const float spawnRange = 7f;
    private const float startDelay = 3;
    private const float repeatRate = 3;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void StartSpawning()
    {
        SpawnBall();
        InvokeRepeating(nameof(SpawnDebris), startDelay, repeatRate);
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPosition, ballPrefab.transform.rotation);
    }

    void SpawnDebris()
    {
        if (!gameManager.isGameActive)
        {
            return;
        }

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(1, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        int index = Random.Range(0, debrisPrefabs.Count - 1);

        Instantiate(
            debrisPrefabs[index],
            new Vector3(spawnPosX, spawnPosY, spawnPosZ),
            debrisPrefabs[index].transform.rotation
        );
    }

    public void DestroyDebris()
    {
        GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");

        if (debris.Length == 0)
        {
            return;

        }

        foreach (GameObject item in debris)
        {
            Destroy(item);
        }
    }

    public void DestroyBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Destroy(ball);
    }
}
