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
	

	void Update () {
        // Keep camera behind the ball.  
        if(ball.transform.position.z <= 1829f-200f)
        {
            SetCamera();
        }
	}

    public void SetCamera()
    {
        gameObject.transform.position = ball.transform.position + offset;
    }
}
