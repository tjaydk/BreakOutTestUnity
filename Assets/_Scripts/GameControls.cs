using UnityEngine;
using System.Collections;

public class GameControls : MonoBehaviour {

    //VARIABLES
    public float xPos = 0;
    public float yPos = 0;
    public float zPos = 0;
    public float xBound = 0;
    public float paddleSpeed = 115;
    public float ballSpeed;
    public float maxBounds = 20;

    //OBJECTS
    public GameObject ball;
    public Rigidbody ballRigidBody;
    public static GameObject attachedBall = null;
    public static GameControls gameControls;

    //SOUNDS
    private AudioClip paddleSound;

	// Use this for initialization
	void Start () {
        gameControls = this; // INSTANTIATE THE GAMECONTROLS TO BE ABLE TO CHANGE VARIABLES FROM OUTSIDE THE SCRIPT
        spawnBall();
	}
	
	// Update is called once per frame
	void Update () {
	    //Paddel movement
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime, yPos, zPos);

            if(transform.position.x < -xBound + maxBounds)
            {
                transform.position = new Vector3(-xBound + maxBounds, yPos, zPos);
            } else if (transform.position.x > xBound - maxBounds)
            {
                transform.position = new Vector3(xBound - maxBounds, yPos, zPos);
            }
        }

        if(attachedBall)
        {
            ballRigidBody = attachedBall.GetComponent<Rigidbody>();
            ballRigidBody.position = transform.position + new Vector3(0,5.5f,0);

            if(Input.GetButtonDown("Jump"))
            {
                ballRigidBody.isKinematic = false;
                ballRigidBody.AddForce(0,ballSpeed,0);
                attachedBall = null;
            }
        }
	}

    //Spawning ball on startup and death
    void spawnBall()
    {
        attachedBall = Instantiate(ball, transform.position + new Vector3(0,5.5f,0), Quaternion.identity) as GameObject;

    }

    void OnCollisionEnter(Collision collision)
    {
        //HERE YOU CAN PLAY A SOUNDCLIP

        //CHANGE BALLMOVEMENT WHEN PADDLE
        foreach (ContactPoint contact in collision.contacts)
        {
            if(contact.thisCollider == GetComponent<Collider>())
            {
                float ballAngle = contact.point.x - transform.position.x;

                Rigidbody otherRigidBody = contact.otherCollider.GetComponent<Rigidbody>();

                otherRigidBody.AddForce(100 * ballAngle, 0, 0);
            }
        }

    }

    public void changeBallSpeed(float amount)
    {
        float newSpeed = ballSpeed += amount;
        ballRigidBody.isKinematic = false;
        ballRigidBody.velocity = ballRigidBody.velocity + ballRigidBody.velocity.normalized * amount;
    }

}
