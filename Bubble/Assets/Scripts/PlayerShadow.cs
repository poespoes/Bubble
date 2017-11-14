using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour {
    Transform playerTransform;
    SpriteRenderer shadowSprite;
    public Player playerScript;

    // Use this for initialization
    void Start() {
        //sr = GetComponent<SpriteRenderer>();
        shadowSprite = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        //follow player
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);

        if (playerScript.Grounded == 0) {
            playerScript.showShadow --;
      //      if (playerScript.showShadow < 0) playerScript.showShadow = 0;
        }
        if (playerScript.showShadow ==5) {
       //     shadowSprite.enabled = true;
        } else {
      //      shadowSprite.enabled = false;
        }

        //shadow only when grounded
        if (playerScript.Grounded == 5) {
          //  this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //Debug.Log("shadow ON");
        } else {
         //   this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    //turn off shadow when player collides with tag "GroundFake"
    /*private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "GroundFake") {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }*/
}
    /*private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "GroundFake") {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }*/

