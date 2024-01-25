using UnityEngine;

public class Sphere : MonoBehaviour
{
    private GameObject[] tornadoes;
    private Rigidbody rb;
    [SerializeField] float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tornadoes = GameObject.FindGameObjectsWithTag("Tornado");

        if (tornadoes.Length == 0)
        {
            return;
        }

        int index = Random.Range(0, tornadoes.Length);

        GameObject tornado = tornadoes[index];

        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (tornado.transform.position - transform.position).normalized;
        rb.AddForce(speed * Time.deltaTime * lookDirection, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tornado"))
        {
            Destroy(gameObject);
        }
    }
}