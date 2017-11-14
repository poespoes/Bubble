using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour {
    public Rigidbody2D springBody;
    private Rigidbody2D myBody;

	void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        
        //DELAY ON RELATIVE JOINT
        Vector2 distanceToSpring = 1.0f*(myBody.position - springBody.position);
        transform.localScale = new Vector3(1.0f+Mathf.Abs(distanceToSpring.x), 1.0f+Mathf.Abs(distanceToSpring.y), 1f);
	}
}
