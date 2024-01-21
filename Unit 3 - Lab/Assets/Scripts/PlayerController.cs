using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 rotationSpeed;
    private BallController ballController;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        ballController = GameObject.Find("Ball").GetComponent<BallController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballController.gameOver)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;

        }

        float xMovement = -Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        rotationSpeed = new(zMovement, rotationSpeed.y, xMovement);

        transform.Rotate(rotationSpeed);

    }
}
