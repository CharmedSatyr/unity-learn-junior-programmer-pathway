using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; private set; }

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject loseScreen;
    private SpawnManager spawnManager;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerBoard").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        spawnManager.StartSpawning();
    }

    public void GameOver(bool victory = false)
    {
        isGameActive = false;

        if (victory)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            loseScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        titleScreen.SetActive(false);
        victoryScreen.SetActive(false);
        loseScreen.SetActive(false);
        playerController.ResetPlayerBoard();
        spawnManager.DestroyDebris();
        spawnManager.DestroyBall();
        StartGame();
    }
}