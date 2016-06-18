using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;
    private int lastStandingCount = -1;  // means nothing has fallen over yet
    private bool ballOutOfPlay = false;
    private GameManager gameManager;
    private float lastChangeTime;   // when did the count number last update
    private int lastSettleCount = 10;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
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
    public void Reset()
    {
        lastSettleCount = 10;
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
        lastStandingCount = -1; //indicates pins have settled and ball not back in box.  new bowling frame
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
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
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Ball")  // if the object that hit this is the ball
        {
            ballOutOfPlay = true;
        }
    }



}
