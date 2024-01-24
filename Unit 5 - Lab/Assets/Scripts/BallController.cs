using UnityEngine;

public class BallController : MonoBehaviour
{
    public ParticleSystem particleEffect;
    private GameManager gameManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.isGameActive)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            gameManager.GameOver(true);
            Debug.Log("Game over: Reached goal.");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Debris"))
        {
            Instantiate(particleEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
