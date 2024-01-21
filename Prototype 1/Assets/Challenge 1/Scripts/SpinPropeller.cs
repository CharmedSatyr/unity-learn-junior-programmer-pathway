using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public Vector3 rotationRate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationRate);
    }
}
