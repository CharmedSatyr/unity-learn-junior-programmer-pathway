using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private PlayerController playerControllerScript;
    private Vector3 spawnPosition = new(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver)
        {
            return;
        }

        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
