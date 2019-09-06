using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
    public float rotationSpeed;
    public Rigidbody rb;
    //public float mass; // 1.989 × 10^30 kg

    // Use this for initialization
    void Start()
    {
        /*rb = GetComponent<Rigidbody>();
        rb.mass = mass;*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
