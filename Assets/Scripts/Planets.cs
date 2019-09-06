using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    public float rotationSpeed;
    public Rigidbody rb;
    private Transform tr;
    private GameObject sol;
    private float solMass;
    private float planetMass;
    private Vector3 direction;
    private float distance;
    private float neededVelocity;
    private float neededForce;
    private Vector3 currentVelocity;
    private float currentMagnitude;
    // Earth mass = 5.972e+24

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        // Sol Initiation.
        sol = GameObject.Find("Sol");
        solMass = sol.GetComponent<Rigidbody>().mass;


        // Planet Initiation.
        planetMass = rb.mass;

        direction = rb.position - sol.transform.position;
        distance = direction.magnitude;

        neededVelocity = Mathf.Sqrt(solMass / distance);
        neededForce = (planetMass * (neededVelocity / Time.fixedDeltaTime)) * 1;

        rb.AddForce(neededForce, 0, 0); /*750000000000*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        currentVelocity = rb.velocity;
        currentMagnitude = currentVelocity.magnitude;
    }
}