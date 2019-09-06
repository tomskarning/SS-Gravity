using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moons : MonoBehaviour
{
    public float rotationSpeed;
    public Rigidbody rb;
    private Transform tr;
    public GameObject planet;
    private float planetMass;
    private float moonMass;
    private Vector3 direction;
    private float distance;
    private float neededVelocity;
    private float neededForce;
    private Vector3 currentVelocity;
    private float currentMagnitude;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        // planet Initiation.
        planetMass = planet.GetComponent<Rigidbody>().mass;


        // moon Initiation.
        moonMass = rb.mass;

        direction = rb.position - planet.transform.position;
        distance = direction.magnitude;

        neededVelocity = Mathf.Sqrt(planetMass / distance);
        neededForce = (moonMass * (neededVelocity / Time.fixedDeltaTime));

        rb.AddForce(neededForce, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        currentVelocity = rb.velocity;
        currentMagnitude = currentVelocity.magnitude;
    }
}