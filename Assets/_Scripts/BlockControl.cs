using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {

	public GameObject block;


	// Use this for initialization
	void Start () {
		createBlocks();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Block") == null) {
            // HERE THE GAME ENDS
        }

	}

    void createBlocks() {
        for (int i = -5; i < 6; i++)
        {
			Instantiate(block, new Vector3(i*21,10,0), Quaternion.identity);
            Instantiate(block, new Vector3(i * 21, 20, 0), Quaternion.identity);
            Instantiate(block, new Vector3(i * 21, 30, 0), Quaternion.identity);
        }
	}
}
