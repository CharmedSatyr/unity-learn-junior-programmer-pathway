using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ballPrefab;
    [SerializeField] float spawnRange;

    private int ballCount;
    private int ballsToSpawn = 1;

    private int startDelay = 1;
    private int repeatRate = 3;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBalls), startDelay, repeatRate);
    }

    void Update()
    {
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(10, 10 + spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new(spawnPosX, spawnPosY, spawnPosZ);
    }

    private void SpawnBalls()
    {
        for (int i = 0; i < ballsToSpawn; i++)
        {
            Instantiate(ballPrefab, GenerateSpawnPosition(), ballPrefab.transform.rotation);
        }

        ballsToSpawn++;
    }
}