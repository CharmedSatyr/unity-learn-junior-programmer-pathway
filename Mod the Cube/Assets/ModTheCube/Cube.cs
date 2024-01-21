using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Vector3 rotationSpeed;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        InvokeRepeating(nameof(ChangeColor), 1, 1);
        InvokeRepeating(nameof(ChangeSpeed), 0, 1);

    }

    void Update()
    {
        transform.Rotate(rotationSpeed);
    }

    void ChangeSpeed()
    {
        rotationSpeed = new(
            Random.Range(0, 100) * Time.deltaTime,
            Random.Range(0, 100) * Time.deltaTime,
            Random.Range(0, 100) * Time.deltaTime
        );
    }

    void ChangeColor()
    {
        Material material = Renderer.material;

        material.color = GetNewColor();
    }

    Color GetNewColor()
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);
        float a = Random.Range(0, 1f);

        return new Color(r, g, b, a);
    }
}
