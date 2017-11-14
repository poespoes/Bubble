using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailBox : MonoBehaviour {
    public Animator snailAnimator;
    private SpriteRenderer sr;
    private AudioSource pop;
    private int destroyTimer = 1;
    private bool trigger = false;

    void Start () {
        pop = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        snailAnimator.Play("snail_idle");
    }
	
	void Update () {
        if (trigger == true) {
            destroyTimer--;
        }

        if (destroyTimer < 0) {
            snailAnimator.SetBool("Pop", false);
            snailAnimator.Play("snail_idle");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            snailAnimator.SetBool("Pop", true);
            destroyTimer = 180;
            trigger = true;
            if (!pop.isPlaying) pop.Play();
        }
    }
}
