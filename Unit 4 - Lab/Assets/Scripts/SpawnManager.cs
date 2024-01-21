using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject debrisPrefab;

    public Vector3 ballSpawnPosition;
    public float ballMinimumYPosition = -10f;

    private bool readyingBall = false;

    private float spawnRange = 7f;

    private float startDelay = 1;
    private float repeatRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();

        InvokeRepeating(nameof(SpawnDebris), startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0 && !readyingBall)
        {
            readyingBall = true;
            DestroyDebris();
            StartCoroutine(SpawnBallAfterDelay());
        }
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPosition, ballPrefab.transform.rotation);
    }

    IEnumerator SpawnBallAfterDelay()
    {
        yield return new WaitForSeconds(1);

        SpawnBall();

        readyingBall = false;
    }

    void SpawnDebris()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(1, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Instantiate(debrisPrefab, new Vector3(spawnPosX, spawnPosY, spawnPosZ), debrisPrefab.transform.rotation);
    }

    void DestroyDebris()
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
}
