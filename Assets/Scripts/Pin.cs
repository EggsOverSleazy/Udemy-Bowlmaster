using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
    public float distToRaise = 40f;

    private Rigidbody rigidBody;
    // Use this for initialization
    void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        //float tiltInX = Mathf.Abs(rotationInEuler.x-270);
        //float tiltInZ = Mathf.Abs(rotationInEuler.z-120);

        //Debug.Log(name + " " + tiltInX + " " + tiltInZ);
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

    public void Raise(Pin pin)
    {
        if (pin.IsStanding())
        {
            Debug.Log("Identified pin to raise");
            pin.transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            pin.GetComponent<Rigidbody>().useGravity = false;
            pin.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            pin.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        }
    }

    public void Lower(Pin pin)
    {
        Debug.Log("Identified pin to lower");
        pin.GetComponent<Rigidbody>().useGravity = true;
        pin.transform.Translate(new Vector3(0, distToRaise * -1, 0), Space.World);
    }
}
