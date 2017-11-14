using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {
    public string movementAnimation;
    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        float randomStart = Random.Range(0f, anim.GetCurrentAnimatorStateInfo(0).length);   //Random bee animation sequence
        anim.Play(movementAnimation, 0, randomStart);
	}
	
	void Update () {
		
	}
}
