using UnityEngine;
using UnityEngine.UI;


public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private GameManager gameManager;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
