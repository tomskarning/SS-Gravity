using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {
    private float maxAcceleration = 0.0010f;
    public float currentAcceleration;

    public GameObject cameraObject;
    public Camera camera;
    public Rigidbody spaceshipRB;

    private float SSxRotation;
    private float SSyRotation;
    private float SSxRotationV;
    private float SSyRotationV;
    private float SScurrentXRotation;
    private float SScurrentYRotation;
    private float SScurrentZRotation;
    public float lookSensitivity = 5;
    public float lookSmoothDamp = 0.1f;

    private string CyRotationV;
    private float CyRotation;
    private float CcurrentYRotation;
    private float CcurrentXRotation;

    private bool brakePressed = false;
    /*private bool rotatePressed = false;
    private string rotateDir = "";*/

    public float SSrotateSpeed;
    public float CrotateSpeed;
    public static bool manualHelm = true;


    // Use this for initialization
    void Start() {
        #if !UNITY_EDIT
            Cursor.visible = false; // Remove cursor.
        #endif
    }

    // Update is called once per frame
    void Update() {
        /*SScurrentXRotation = spaceshipRB.transform.rotation.x;
        SScurrentYRotation = spaceshipRB.transform.rotation.y;
        SScurrentZRotation = spaceshipRB.transform.rotation.z;*/

        CcurrentXRotation = camera.transform.rotation.x;
        CcurrentYRotation = camera.transform.rotation.y;

        if (manualHelm) {

            // Accelerate
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E)) {
                accelerate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }

            // Rotate
            /*if (Input.GetKey(KeyCode.A)) {
                spaceshipRB.transform.Rotate(0, -SSrotateSpeed * Time.deltaTime, 0);
            } if (Input.GetKey(KeyCode.D)) {
                spaceshipRB.transform.Rotate(0, SSrotateSpeed * Time.deltaTime, 0);
            }*/

            // Brake
            if (Input.GetKey(KeyCode.Space)) {
                spaceshipRB.velocity = Vector3.zero;
            }

            // Steering
            //if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
            SSxRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
	        SSyRotation += Input.GetAxis("Mouse X") * lookSensitivity;
	
	        //SSxRotation = Mathf.Clamp(xRotation, -44, 90);
	
	        SScurrentXRotation = Mathf.SmoothDamp(SScurrentXRotation, SSxRotation, ref SSxRotationV, lookSmoothDamp);
	        SScurrentYRotation = Mathf.SmoothDamp(SScurrentYRotation, SSyRotation, ref SSyRotationV, lookSmoothDamp);
            transform.rotation = Quaternion.Euler(SScurrentXRotation, SScurrentYRotation, 0);

            //}
            /*if (Input.GetAxis("Mouse X") != 0) {
                spaceshipRB.transform.Rotate(((SScurrentXRotation + -Input.GetAxis("Mouse Y")) * SSrotateSpeed) * Time.deltaTime, 0, 0);
            } if (Input.GetAxis("Mouse Y") != 0) {
                spaceshipRB.transform.Rotate(0, ((SScurrentYRotation + Input.GetAxis("Mouse X")) * SSrotateSpeed) * Time.deltaTime, 0);
            }*/
            //}


        } else { // Computer Guided
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse X") != 0) {
                camera.transform.Rotate(((CcurrentXRotation + -Input.GetAxis("Mouse Y")) * CrotateSpeed) * Time.deltaTime, ((CcurrentYRotation + Input.GetAxis("Mouse X")) * CrotateSpeed) * Time.deltaTime, SScurrentZRotation);
            }
        }
    }

    void accelerate(float x, float y, float z) {
        spaceshipRB.AddRelativeForce(x * currentAcceleration, 0, z * currentAcceleration);

        if (currentAcceleration < maxAcceleration) {
            currentAcceleration = currentAcceleration + 0.00001f;
        }
    }

}