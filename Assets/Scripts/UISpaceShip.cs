using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpaceShip : MonoBehaviour {
    public AudioSource engine;
    private bool engineOn = false;

    // Use this for initialization
    void Start () {
        engine.Play(0);

    }

   

        // Update is called once per frame
    void Update () {
        if (engineOn && Engine.manualHelm) {
            engine.volume += 1f * Time.deltaTime;
        } else {
            engine.volume -= 2f * Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            if (!engineOn)
            {
                engineOn = true;
            }
        } else {
            engineOn = false;
        }
    }
}
