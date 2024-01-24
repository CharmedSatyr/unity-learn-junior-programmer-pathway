using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly Vector3 initialPosition = Vector3.zero;
    private readonly Quaternion initialRotation = new(0, 0, 0, 0);
    private RigidbodyConstraints initialConstraints;
    private Vector3 rotationSpeed;
    [SerializeField] float rotationSpeedMultiplier = 5.0f;

    private GameManager gameManager;
    private Rigidbody rb;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        initialConstraints = rb.constraints;
    }

    void FixedUpdate()
    {
        if (!gameManager.isGameActive)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        else
        {
            rb.constraints = initialConstraints;
            transform.position = initialPosition;
        }

        float xMovement = -Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        rotationSpeed = new Vector3(zMovement, rotationSpeed.y, xMovement) * rotationSpeedMultiplier;

        transform.Rotate(rotationSpeed);
    }

    public void ResetPlayerBoard()
    {
        transform.SetPositionAndRotation(initialPosition, initialRotation);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rotationSpeed = Vector3.zero;
    }
}
