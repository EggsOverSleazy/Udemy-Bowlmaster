using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public Text standingDisplay;
    public GameObject pinSet;

    private int lastStandingCount = -1;  // means nothing has fallen over yet
    private bool ballOutOfPlay = false;

    private float lastChangeTime;   // when did the count number last update
    private int lastSettleCount = 10;


    private Ball ball;
    private Animator animator;

    ActionMaster actionMaster = new ActionMaster();  // need it here because we only want to have one instance  

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballOutOfPlay == true)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    void UpdateStandingCountAndSettle()
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

    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }

    void PinsHaveSettled()
    {
          
        int standing = CountStanding();
        int pinFall = lastSettleCount - standing;
        lastSettleCount = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log(action);

        if (action == ActionMaster.Action.Tidy)     // if its time to tidy, make the tidy animation go 
        {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettleCount = 10;
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettleCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
        
        lastStandingCount = -1; //indicates pins have settled and ball not back in box.  new bowling frame
        ballOutOfPlay = false;
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
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position = new Vector3(0, 35, 1829);
    }
}
