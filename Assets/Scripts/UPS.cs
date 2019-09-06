using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NameAndMag {
    public string name;
    public float magnitude;

    public NameAndMag(string nameC, float magnitudeC) {
        name = nameC;
        magnitude = magnitudeC;
    }
}

public class UPS : MonoBehaviour {
    public Transform spaceShipT;
    public Rigidbody spaceShipR;
    public Rigidbody earthR;
    public GameObject spaceShipG;

    public Text textSpeed;
    public Text textSpeedRel;
    public Text textAcceleration;
    Gravity[] planets;
    public Text hGPull;
    private string hGPObject;
    public float currentHGP;
    public List<NameAndMag> nameandmag = new List<NameAndMag>();
    private Engine accScript;
    public Text textLocation;
    private string defaultLocation = "Solar System";

    public Text solDistance;
    public Transform solT;
    public Text earthDistance;
    public Transform earthT;
    public Text marsDistance;
    public Transform marsT;
    public Text jupiterDistance;
    public Transform jupiterT;

    public string closestObject;
    private GameObject closestObjectGO;
    public AudioSource computerVoice;
    public AudioSource alarm;
    public AudioClip currentPosition;
    public AudioClip solarSystemHome;
    public AudioClip entering;
    public AudioClip leaving;
    public AudioClip enteringAtmossphere;
    public AudioClip proximityAlert;
    public AudioClip temperatureAlert;

    private int universalScale = 10;
    private bool enteredOrbit = false;
    private bool pAlarmSet = false;
    private bool tAlarmSet = false;

    private float cOS;

    // Use this for initialization
    void Start () {
        planets = FindObjectsOfType<Gravity>();
        StartCoroutine(SoundSystem());
        alarm.volume = 0;
        alarm.Play(0);
    }

    IEnumerator SoundSystem()
    {
        computerVoice.clip = currentPosition;
        computerVoice.Play(0);
        yield return new WaitForSeconds(2);
        computerVoice.clip = solarSystemHome;
        computerVoice.Play(0);
    }

    // Update is called once per frame
    void Update () {
        closestObject = ObjectScaler.closestObject;
        LocationUpdate();
        RelativeSpeed();
        ProximitySensor();
        hGP();
        var vel = spaceShipR.velocity;
        textSpeed.text = "Absolute Speed: " + Mathf.Round(vel.magnitude * universalScale) + " km/h";
        //var velRel = spaceShipR.velocity;

        accScript = spaceShipG.GetComponent<Engine>();
        textAcceleration.text = "Thrust: " + accScript.currentAcceleration + " N";
    }

    void LocationUpdate() {
        float distanceSol = Mathf.Round(Vector3.Distance(spaceShipT.position, solT.position)) * universalScale;
        solDistance.text = "Sol: " + distanceSol + " km";
        float distanceEarth = Mathf.Round(Vector3.Distance(spaceShipT.position, earthT.position)) * universalScale;
        earthDistance.text = "Earth: " + distanceEarth + " km";
        float distanceMars = Mathf.Round(Vector3.Distance(spaceShipT.position, marsT.position)) * universalScale;
        marsDistance.text = "Mars: " + distanceMars + " km";
        float distanceJupiter = Mathf.Round(Vector3.Distance(spaceShipT.position, jupiterT.position)) * universalScale;
        jupiterDistance.text = "Jupiter: " + distanceJupiter + " km";
    }

    void hGP() {
        nameandmag.Clear();
        foreach (Gravity planet in planets) {
            
            if (planet.name != "Spaceship" ) {

                Vector3 direction = spaceShipT.position - planet.transform.position;
                float distance = direction.magnitude;
                float forceMagnitude;

                if (planet.name != "Sol") {
                    forceMagnitude = ((spaceShipR.mass * planet.rb.mass) / Mathf.Pow(distance, 2)) * Gravity.overloadG;
                } else {
                    forceMagnitude = ((spaceShipR.mass * planet.rb.mass) / Mathf.Pow(distance, 2)) * Gravity.G;
                }

                Vector3 force = direction.normalized * forceMagnitude;

                nameandmag.Add(new NameAndMag(planet.name, forceMagnitude));
                
                //Debug.Log(nameandmag);
            }

            nameandmag = nameandmag.OrderBy(w => w.magnitude).ToList();

            /*foreach(NameAndMag entry in nameandmag) {
                Debug.Log(entry.name + " - " + entry.magnitude);
            }*/
            //Debug.Log(nameandmag[0].name);
            currentHGP = nameandmag[nameandmag.Count-1].magnitude;
            hGPObject = nameandmag[nameandmag.Count-1].name;
        }

        hGPull.text = "HGP: " + hGPObject + "\n [" + currentHGP + "]";
    }

    void RelativeSpeed() {
        var SSvel = spaceShipR.velocity.magnitude;
        var Evel = earthR.velocity.magnitude;
        var rVel = SSvel - Evel;
        textSpeedRel.text = "Relative Speed: " + Mathf.Round(rVel * universalScale) + " km/h";
    }

    void ProximitySensor() {
        closestObjectGO = GameObject.Find(closestObject);
        
        cOS = closestObjectGO.transform.localScale.x * 20;
        float distance = Vector3.Distance(spaceShipT.position, closestObjectGO.transform.position);

        if (distance <= cOS + 500 && !enteredOrbit) {
            enteredOrbit = true;
            textLocation.text = closestObject;
            computerVoice.clip = entering;
            computerVoice.Play(0);
        } if (distance > cOS + 500 && enteredOrbit) {
            enteredOrbit = false;
            textLocation.text = defaultLocation;
            computerVoice.clip = leaving;
            computerVoice.Play(0);
        }

        // Proximity Alert
        if (distance <= cOS + 250 && !pAlarmSet) {
            pAlarmSet = true;
            computerVoice.clip = proximityAlert;
            computerVoice.loop = true;
            computerVoice.Play(0);
            alarm.volume = 0.25f;
        } if (distance >= cOS + 250 && pAlarmSet) {
            pAlarmSet = false;
            computerVoice.loop = false;
            alarm.volume = 0;
        }

        // Temperature Alert
        if (distance <= cOS + 5000 && closestObject == "Sol" && !tAlarmSet) {
            tAlarmSet = true;
            computerVoice.clip = temperatureAlert;
            computerVoice.loop = true;
            computerVoice.Play(0);
            alarm.volume = 0.25f;
        } if (distance >= cOS + 5000 && closestObject == "Sol" && tAlarmSet) {
            tAlarmSet = false;
            computerVoice.loop = false;
            alarm.volume = 0;
        }
    }

}
