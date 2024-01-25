using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
