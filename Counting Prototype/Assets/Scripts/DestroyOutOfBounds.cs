using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float boundX = 50f;
    float boundZ = 50f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.z > boundZ || transform.position.z < -boundZ)
        {
            Destroy(gameObject);
            return;
        }

        if (transform.position.x > boundX || transform.position.x < -boundX)
        {
            Destroy(gameObject);
        }
    }
}
