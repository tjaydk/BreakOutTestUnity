using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    //Variables
    public int lives;

    //Objects
	public Text livesCount;
	public static PlayerScript pScript;


	// Use this for initialization
	void Start () {
		pScript = this;
        lives = 3;
		livesCount.text = "Count: " + lives.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void dead()
    {
        pScript.lives -= 1;
		pScript.livesCount.text = "Count: "+ pScript.lives.ToString();
    }
}
