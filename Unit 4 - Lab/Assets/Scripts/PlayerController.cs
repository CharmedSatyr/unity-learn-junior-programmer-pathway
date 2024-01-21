using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ball;

    private readonly Vector3 initialPosition = new(0, 0, 0);
    private readonly Quaternion initialRotation = new(0, 0, 0, 0);
    private Vector3 rotationSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball == null)
        {
            Reset();
            return;
        }

        if (ball.GetComponent<BallController>().gameOver)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }

        float xMovement = -Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        rotationSpeed = new(zMovement, rotationSpeed.y, xMovement);

        transform.Rotate(rotationSpeed);
    }

    public void Reset()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rotationSpeed = Vector3.zero;
    }
}
