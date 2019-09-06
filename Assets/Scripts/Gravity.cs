using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject go;
    public Rigidbody rb;
    public static float G = 1f /*50000*/ /*6.67408f * Mathf.Pow(10, -11)*/;
    public static float overloadG = 5000f;
    float forceMagnitude;
    Gravity[] planets;

    void Attract(Gravity objToAttract) {

        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        // Newtons Equation
        // F = ((m1*m2)/d2)*G
        if (objToAttract.name == "Spaceship" && go.name != "Sol") {
            forceMagnitude = ((rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2)) * overloadG;
        } else {
            forceMagnitude = ((rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2)) * G;
        }

        
        Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }

    // Update is called once per frame
    void FixedUpdate() {
        foreach (Gravity planet in planets) {
            if (planet != this) {
                Attract(planet);
            }
        }
    }

    void Start()
    {
        planets = FindObjectsOfType<Gravity>();
        //Time.timeScale = 100;
        //Debug.Log(G);
    }
}
