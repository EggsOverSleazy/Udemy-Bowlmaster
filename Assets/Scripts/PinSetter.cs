using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;  // means nothing has fallen over yet
    public Text standingDisplay;

    
    private Ball ball;

    private float lastChangeTime;   // when did the count number last update
    private bool ballEnteredBox = false;


    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();

	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballEnteredBox == true)
        {
            CheckStanding();
        }
    }

    void CheckStanding()
    {
        int currentStanding = CountStanding();
        if (lastStandingCount != currentStanding)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;

        if (Time.time - lastChangeTime > settleTime)
        {
            Debug.Log("Pins have settled");
            PinsHaveSettled();
        }
        // update the last standing count
        // call pins have settled when they have
    }

    void PinsHaveSettled()
    {
        //aball
        lastStandingCount = -1; //indicates pins have settled and ball not back in box.  new bowling frame
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
        ball.Reset();
    }


    int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        // Ball enters play box
        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }

    }

     void  OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }

    public void RaisePins()
    {
        Debug.Log("Raise Pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            //pin.GetComponent<Rigidbody>().useGravity = false;
            pin.Raise(pin);
        }
    }

    public void Lowerpins()
    {
        Debug.Log("Lowering pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower(pin);
        }
    }

    public void RenewPins()
    {
        Debug.Log("Make New Pins");
    }

}
