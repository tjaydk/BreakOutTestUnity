using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	//Variables
	public int score;

	//Objects
	public Text scoreCount;
	public static ScoreScript sScript;

	// Use this for initialization
	void Start () {
		sScript = this;
		score = 0;
		scoreCount.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void increasePoints()
	{
		sScript.score += 10;
		sScript.scoreCount.text = "Score: " + sScript.score.ToString();
	}
}
