using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Should come after Vehicle update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
