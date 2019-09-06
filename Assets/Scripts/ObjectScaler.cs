using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour {
    public Transform        spaceshipT;
    public static string    closestObject;

    /*public GameObject       sol;
    public GameObject       tellus;
        public GameObject       luna;
    public GameObject       mars;*/

    public GameObject[] gObjectsGO;
    public int numberOfObjects;
    public List<Transform> gObjectsT = new List<Transform>();
    public List<Vector3> gOriginalObjectsV3 = new List<Vector3>();

	// Use this for initialization
	void Start () {
        gObjectsGO = GameObject.FindGameObjectsWithTag("gObject");
        numberOfObjects = gObjectsGO.Length;
        foreach (GameObject gObject in gObjectsGO) {
            gObjectsT.Add(gObject.transform);
            gOriginalObjectsV3.Add(gObject.transform.localScale);
        }
	}
	
	// Update is called once per frame
	void Update () {

        Transform gObjectMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (Transform gObject in gObjectsT) {
            float dist = Vector3.Distance(gObject.position, currentPos);

            if (dist < minDist) {
                gObjectMin = gObject;
                minDist = dist;
            }
        }

        closestObject = gObjectMin.name;

        scaleObjects();
	}

    void scaleObjects() {
        int i = 0;
        foreach (Transform gObject in gObjectsT) {
            float threshold = 5000;
            float newScale;
            float originalScale = gOriginalObjectsV3[i].x;
            Vector3 currentPos = transform.position;
            float dist = Vector3.Distance(gObject.position, currentPos);

            //newScale = Mathf.Log(100, originalScale + (threshold / dist));
            newScale = (threshold / (dist * 2)) * originalScale;
            
            gObject.transform.localScale = new Vector3 (newScale, newScale, newScale);

            if (i >= (numberOfObjects - 1)) {
                i = 0;
            } else {
                i++;
            }
        }
    }
}
