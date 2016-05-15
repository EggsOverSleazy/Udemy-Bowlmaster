using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity = new Vector3 (0,0,300f);

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position= new Vector3(1, 20, 30);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (gameObject.GetComponent<Rigidbody>().velocity == new  Vector3(0, 0, 0))
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
	
	}

    private void OnMouseDown()
    {
        Launch();
    }

    private void Launch()
    {
        gameObject.GetComponent<Rigidbody>().velocity = launchVelocity;
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
