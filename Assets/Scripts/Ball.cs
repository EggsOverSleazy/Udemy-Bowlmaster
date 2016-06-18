using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity = new Vector3 (0,0,300f);
    public GameObject pins;
    public bool inPlay = false;

    private Vector3 ballStartPosition;
    private Vector3 stillVelocity = new Vector3(0, 0, 0);

    void Start()
    {
        ballStartPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        StopSoundOnStill();
        if (Input.GetKeyDown(KeyCode.Backspace)) { Reset(); }
    }

    private void StopSoundOnStill()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    public void Reset()
    {
        inPlay = false;
        gameObject.GetComponent<Rigidbody>().velocity = stillVelocity;
        gameObject.GetComponent<Rigidbody>().angularVelocity = stillVelocity;
        GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.position = ballStartPosition;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    public void Launch(Vector3 velocity)
    {
        GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
		if (velocity.x > 100f) {
			throw new UnityException ("Expected velocity exceeded by object" + name);
		}
    }

    private void OnCollisionEnter()
    {
        PlaySoundOnCollision();
    }

    private void PlaySoundOnCollision()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

}
