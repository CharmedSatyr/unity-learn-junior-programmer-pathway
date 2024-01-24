using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float lowerBound = -100.0f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("Ball"))
            {
                gameManager.GameOver();
                Debug.Log("Game over: Ball was destroyed.");
            }
        }
    }
}
