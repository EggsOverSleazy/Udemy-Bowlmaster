using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public GameObject pinSet;
    private Animator animator;
    private PinCounter pinCounter;

    ActionMaster actionMaster = new ActionMaster(); // need it here because we only want to have one instance  

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy) // if its time to tidy, make the tidy animation  
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }
}