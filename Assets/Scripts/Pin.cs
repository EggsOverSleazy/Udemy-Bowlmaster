using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;

    // Use this for initialization
    void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(rotationInEuler.x-270);
        float tiltInZ = Mathf.Abs(rotationInEuler.z-120);

        Debug.Log(name + " " + tiltInX + " " + tiltInZ);
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(rotationInEuler.x-270);
        float tiltInZ = Mathf.Abs(rotationInEuler.z-120);

        float bullshitOffset = 120f;

        if ((tiltInX < standingThreshold || tiltInX > 360f - standingThreshold) && (tiltInZ < standingThreshold + bullshitOffset || tiltInZ > 360f - standingThreshold + bullshitOffset))
            {
            return true;
        }
        else {
            return false;
        }
    }

}
