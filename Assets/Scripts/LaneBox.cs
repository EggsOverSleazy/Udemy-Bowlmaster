using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour {

    private PinSetter pinSetter;

	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
	
	}
	

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Ball")  // if the object that hit this is the ball
        {
            pinSetter.SetBallOutOfPlay();
        }
    }
}
