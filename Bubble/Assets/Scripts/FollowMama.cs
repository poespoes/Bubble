using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMama : MonoBehaviour {
    public Transform mamaButterfly;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = mamaButterfly.position;        //follow mamaButterfly's position
        transform.eulerAngles = mamaButterfly.eulerAngles;  //follow mamaButterfly's angle


    }
}
