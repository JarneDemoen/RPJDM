using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAI : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    [SerializeField] public float rotationSpeed = 10.0f;
    [SerializeField] public float thrust = 20.0f;
    [SerializeField] public float lift = 5.0f;
    [SerializeField] public float drag = 0.1f;
    [SerializeField] public float minThrottle = 0.0f;
    [SerializeField] public float maxThrottle = 1000f;

    private float currentThrottle;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentThrottle = minThrottle;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentThrottle = Mathf.Clamp(currentThrottle + Time.deltaTime, minThrottle, maxThrottle);
        }
        else
        {
            currentThrottle = Mathf.Clamp(currentThrottle - Time.deltaTime, minThrottle, maxThrottle);
        }

        // Move the airplane forward
        rb.AddForce(transform.forward * currentThrottle * thrust);

    }


}
