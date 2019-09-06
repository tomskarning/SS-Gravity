using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour {
    public Text manualHelmText;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            quitGame();
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            ManualHelm();
        }
    }

    void quitGame() {
        Application.LoadLevel("MainMenu");
    }

    void ManualHelm() {
        if (Engine.manualHelm) {
            Engine.manualHelm = false;
            manualHelmText.text = "[N] Computer Nav";
        } else {
            Engine.manualHelm = true;
            manualHelmText.text = "[N] Manual Helm Control";
        }
    }
}
