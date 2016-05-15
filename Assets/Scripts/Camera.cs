using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Ball ball;
    private Vector3 offset;
 
	// Use this for initialization
	void Start () {
        // Capture original offset
        offset = gameObject.transform.position - ball.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.z <= 1829f-200f)
        {
            gameObject.transform.position = ball.transform.position + offset;
        }
	}
}
