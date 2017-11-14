using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyBackground : MonoBehaviour {

    public bool fireflyLeft = true;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        if (fireflyLeft) {
            anim.Play("firefly_background", 0, 0);
        } else {
            anim.Play("firefly_background2", 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
