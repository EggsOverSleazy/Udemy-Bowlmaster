using UnityEngine;
using System.Collections;

public class pindebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 rotationInEuler = transform.rotation.eulerAngles;


        float tiltInX = (rotationInEuler.x);
        float tiltInY = (rotationInEuler.y);
        float tiltInZ = (rotationInEuler.z);

        print(name + " ||| " + tiltInX + " , " + tiltInY + " , " + tiltInZ);
    }
}
