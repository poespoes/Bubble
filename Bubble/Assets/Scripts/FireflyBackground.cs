using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyBackground : MonoBehaviour {

    public bool fireflyLeft = true;
    private Animator anim;

    void Start () {
        anim = GetComponent<Animator>();

        //FIREFLY ANIMATION (fly from left and right)
        if (fireflyLeft) {
            anim.Play("firefly_background", 0, 0);
        } else {
            anim.Play("firefly_background2", 0, 0);
        }
	}
	
	void Update () {
		
	}
}
