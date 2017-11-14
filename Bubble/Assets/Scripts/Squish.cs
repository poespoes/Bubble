using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour {
    public Rigidbody2D springBody;
    private Rigidbody2D myBody;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 distanceToSpring = 1.0f*(myBody.position - springBody.position);
        transform.localScale = new Vector3(1.0f+Mathf.Abs(distanceToSpring.x), 1.0f+Mathf.Abs(distanceToSpring.y), 1f);
	}
}
