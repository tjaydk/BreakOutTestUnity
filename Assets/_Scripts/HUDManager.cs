using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

	//Variables
	public int lives;

	//Objects
	public Text livesCount;

	// Use this for initialization
	void Start () {
		lives = 3;
		livesCount.text = "Lives: " + lives;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setLivesText(string text) {
		livesCount.text = text;
	}

	public int getLives() {
		return lives;
	}
}
