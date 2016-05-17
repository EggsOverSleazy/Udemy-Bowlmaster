using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity = new Vector3 (0,0,300f);
    public GameObject pins;
    public bool inPlay = false;


    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }
    // Update is called once per frame
    void Update ()
    {
        Reset();
        StopSoundOnStill();
    }

    private void StopSoundOnStill()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            gameObject.transform.position = new Vector3(1, 20, 30);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            //Destroy(GameObject.Find("Pins"));
        }

        
        //Instantiate(pins, new Vector3(0, 0, 1829), Quaternion.identity);
      
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
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
