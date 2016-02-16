using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {

    //VARIABLES
    public float ballSpeed = 6250;
	public int lives;

    //OBJECTS
	public ParticleSystem explosion;
	public ParticleSystem tilesExplosion;
    public GameObject ball;
    public GameObject block;
	public Transform powerUpPrefab;
    
    

	// Use this for initialization
	void Start () {
		lives = 3;

    }
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y < -100)
        {
            //LIVES -1
            Vector3 resetPosition = new Vector3(GameObject.FindGameObjectWithTag("Paddle").transform.position.x, GameObject.FindGameObjectWithTag("Paddle").transform.position.y + 5.5f, 0);

            transform.position = resetPosition;
            GetComponent<Rigidbody>().Sleep();
            GameControls.attachedBall = this.gameObject;
			PlayerScript.dead();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
		int spawnPowerUp = Random.Range(1, 6);

        //HERE YOU CAN PLAY A SOUNDCLIP

        //REMOVE BLOCK
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag.Equals("Block"))
            {
                Destroy(collision.gameObject);
                GameControls.gameControls.changeBallSpeed(1.5f);

				ScoreScript.increasePoints();

				Instantiate(explosion, transform.position, transform.rotation);
				Instantiate(tilesExplosion, transform.position, transform.rotation);

				explosion.startSize = 50f;
				explosion.Play();
				tilesExplosion.Play();


				//POWERUPS DROP RANDOMLY
				if (spawnPowerUp == 1) {
					Transform powerUp = Instantiate(powerUpPrefab, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity) as Transform;
					Physics.IgnoreCollision(powerUp.GetComponent<Collider>(), GetComponent<Collider>(), true);
				}
            }
        }

    }
}
