using UnityEngine;
using System.Collections;

public class PowerUpControl : MonoBehaviour {

    public GameObject ball;
    GameObject paddle;
    public Rigidbody ballRigidbody;

    // Use this for initialization
    void Start() {
        paddle = GameObject.Find("Paddle");
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider col)
    {
        //REMOVE PowerUp
        if (col.gameObject.tag.Equals("Paddle"))
        {
            Destroy(this.gameObject);
            paddle.gameObject.transform.localScale += new Vector3(5, 0, 0);
            //Instantiate(ball, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 5.5f), Quaternion.identity);
            //ballRigidbody.isKinematic = false;
           // ballRigidbody.AddForce(500, 4250, 0);
        }
    }
}
