using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public AudioSource soundtrack;
    public AudioSource cockpit;
    // Use this for initialization
    void Start () {
        soundtrack.Play(0);
        cockpit.Play(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
