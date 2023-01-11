using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    float minSpeed = 0.0f;
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float brakeSensitivity = 3f;
    [SerializeField] float gravityStrength = 9.81f;
    [SerializeField] float pitchSensitivity = 1f;
    [SerializeField] float rollSensitivity = 1f;
    [SerializeField] float yawSensitivity = 1f;
    float pitch = 0;
    float roll = 0;
    float yaw = 0;
    private Plane plane;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0;
        plane = GetComponent<Plane>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            if (!plane.engenOn)
            {
                plane.engenOn = true;
            }
        }
        
        if (Input.GetKey(KeyCode.B))
        {
            speed -= brakeSensitivity * Time.deltaTime;
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            if (plane.engenOn)
            {
                plane.engenOn = false;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pitch += pitchSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pitch -= pitchSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            roll += rollSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            roll -= rollSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            yaw -= yawSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            yaw += yawSensitivity * Time.deltaTime;
        }
    }

    private void FixedUpdate() 
    {
        rb.velocity = transform.forward * speed;
        GetComponent<ConstantForce>().force = new Vector3(0,gravityStrength,0);
        transform.Rotate(pitch, yaw, roll);
    }
}
