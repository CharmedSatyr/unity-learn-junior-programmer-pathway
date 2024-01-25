using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject tornadoPrefab;
    [SerializeField] float speed;
    [SerializeField] float xRange;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.left);

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Instantiate(tornadoPrefab, transform.position, tornadoPrefab.transform.rotation);
            canShoot = false;
            StartCoroutine(WaitBetweenShots());
        }
    }

    IEnumerator WaitBetweenShots()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
