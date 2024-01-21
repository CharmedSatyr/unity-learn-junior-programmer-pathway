using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private PlayerController playerControllerScript;
    private float leftBoundary = -15f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            return;
        }

        if (gameObject.CompareTag("Obstacle") && transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }


        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
