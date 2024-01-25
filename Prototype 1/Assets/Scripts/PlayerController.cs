using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] const float turnSpeed = 45.0f;
    [SerializeField] float horsePower;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    private void Update()
    {
        if (!IsOnGround())
        {
            return;
        }

        UpdateSpeedometer();
        UpdateRPM();
    }

    void FixedUpdate()
    {
        if (!IsOnGround())
        {
            return;
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the vehicle forward

        //transform.Translate(forwardInput * Time.deltaTime * speed * Vector3.forward);
        rb.AddForce(Vector3.forward * verticalInput * horsePower);
        transform.Rotate(horizontalInput * Time.deltaTime * turnSpeed * Vector3.up);
    }

    private void UpdateSpeedometer()
    {
        speed = Mathf.Round(rb.velocity.magnitude * 2.236936f); // m/s to MPH
        speedometerText.SetText($"Speed: {speed}");
    }

    private void UpdateRPM()
    {
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText($"RPM: {rpm}");
    }

    private bool IsOnGround()
    {
        foreach (WheelCollider wheel in allWheels)
        {
            if (!wheel.isGrounded)
            {
                return false;
            }
        }

        return true;
    }
}
