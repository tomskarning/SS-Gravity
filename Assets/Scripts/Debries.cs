using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debries : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Random.Range(-100f, 100f),Random.Range(-100f, 100f),Random.Range(-100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
