using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour {
    public Animator butterflyAnimator;
    private SpriteRenderer sr;
    private AudioSource wink;

    private int destroyTimer = 0;   //Butterfly disappear
    public bool bodyShadow = false;
    private bool isFlying = false;

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        wink = GetComponent<AudioSource>();

        if (!isFlying && !bodyShadow) {
            butterflyAnimator.Play("butterfly_idle");
        }
        if (!isFlying && bodyShadow) {
            butterflyAnimator.Play("butterfly_idle2");
        }
    }
	
	void Update () {

        if (butterflyAnimator.GetBool("Flapping") == true) {
            destroyTimer++;
        }
        if(destroyTimer == 1) {
            wink.Play();
        }
        if(destroyTimer >= 315) {   //Destroy butterfly in 315 frames
            Destroy(this.gameObject);
        }
    }

    public void destroybutterfly() {
        Destroy(this.gameObject);   //For animation add event
    }

private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {     //If player touches butterfly
            isFlying = true;
            this.transform.parent = null;
            //Debug.Log("Butterfly fly fly");
            butterflyAnimator.SetBool("Flapping", true);
            
        }
    }
}
