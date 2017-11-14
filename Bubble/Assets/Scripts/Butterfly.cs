using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour {
    public Animator butterflyAnimator;
    private SpriteRenderer sr;
    private AudioSource wink;

    private int destroyTimer = 0;
    public bool bodyShadow = false;
    private bool isFlying = false;

    // Use this for initialization
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
	
	// Update is called once per frame
	void Update () {

        if (butterflyAnimator.GetBool("Flapping") == true) {
            destroyTimer++;
        }
        if(destroyTimer == 1) {
            wink.Play();
        }
        if(destroyTimer >= 315) {
            Destroy(this.gameObject);
        }
    }

private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            isFlying = true;
            this.transform.parent = null;
            //Debug.Log("Butterfly fly fly");
            butterflyAnimator.SetBool("butterfly_idle", false);
            butterflyAnimator.SetBool("butterfly_idle2", false);
            butterflyAnimator.SetBool("Flapping", true);
            
        }
    }
}
