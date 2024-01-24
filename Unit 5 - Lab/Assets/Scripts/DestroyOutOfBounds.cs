using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float lowerBound = -10.0f;

    private void Update()
    {
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
