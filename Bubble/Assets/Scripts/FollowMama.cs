using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMama : MonoBehaviour {
    public Transform mamaButterfly;

	void Start () {
		
	}
	
	void Update () {
        transform.position = mamaButterfly.position;        //Follow mamaButterfly's position
        transform.eulerAngles = mamaButterfly.eulerAngles;  //Follow mamaButterfly's angle
    }
}
