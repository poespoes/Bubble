using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUpright : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        transform.rotation = Quaternion.identity;   //Lock rotation of Bubble's body
	}
}
