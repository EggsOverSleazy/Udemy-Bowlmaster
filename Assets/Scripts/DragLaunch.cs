using UnityEngine;
using System.Collections;

//add Ball script if it wasn't already on this component.  
[RequireComponent (typeof(Ball))] 

public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStartPosition, dragEndPosition;
    private float dragStartTime, dragEndTime;

    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        // capture time and position of drag start (mouse click)
        dragStartPosition = Input.mousePosition;
        dragStartTime = Time.time;
    }

    public void DragEnd()
    {
        // launch the ball based on the drag 
        dragEndPosition = Input.mousePosition;
        dragEndTime = Time.time;

        float dragDuration = dragEndTime - dragStartTime;
        // Physics Formula.  Velocity = Displacement / Time Taken 
	float launchSpeedX = (dragEndPosition.x - dragStartPosition.x) / dragDuration;
        float launchSpeedZ = (dragEndPosition.y - dragStartPosition.y) / dragDuration;
        //Y on the touch interface = Z in the world

        // launch
        //Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(new Vector3(launchSpeedX, 0, launchSpeedZ));


    }


}
