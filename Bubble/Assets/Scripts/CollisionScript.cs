using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("touched leaf");

        //check to see if the player is above or below
        //or, change the gravity on the player
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("stopped touching leaf");
    }
}
