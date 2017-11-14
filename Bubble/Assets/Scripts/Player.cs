using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator playerAnimator;
    public float moveSpeed = 2;     //Player's move speed
    public float jumpSpeed = 5;     //Player's jump speed
    public float jumpDownSpeed = 3; //Player's fall speed
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    public int Grounded = 0;        //Player collision contact timer
    public int TouchingRoof = 0;    //Player collision contact timer
    private int jumpCheck;          //Player's jump animation check
    public int showShadow;          //Shadow counter
    SpriteRenderer Shadow;
    SpriteRenderer Branch;
    SpriteRenderer Branch2;

    bool atStart;
    bool followButterfly;
    bool groundTouch = false;
    bool musicCheckFall = false;
    bool musicCheckClimb = false;

    GameObject giantButterfly;
    public SpriteRenderer branch;
    public SpriteRenderer branch2;

    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;

    void Start() {
        showShadow = 5;
        Shadow = GameObject.Find("PlayerShadow").GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        //SPRITE CHECK
        if (playerAnimator == null) {
            Debug.LogError("There is no Player Animator reference!");
        }

        atStart = true;
        playerAnimator.Play("AtStart");

        followButterfly = false;
    }

    void Update() {
        //BGM FADE
        if(!musicCheckFall) {
            float minHeight = 31.0f;
            float maxHeight = 46.0f;
            float musicHeight = (transform.position.y - minHeight) / (maxHeight - minHeight);
            musicHeight = Mathf.Clamp01(musicHeight);
            music1.volume = musicHeight;
            music2.volume = 1.0f - musicHeight;
                
        }

        if (musicCheckClimb) {
            if (transform.position.y >= 25.5f) {
                music2.volume -= 0.005f;
                if (!music3.isPlaying) music3.Play();
                if (!followButterfly && transform.position.y <= 40.0f) music3.volume += 0.005f;
            }
        }

        //PLAYER STARTING POSITION
        if (atStart) {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;    //Lock axis
            transform.position = new Vector3(0, 69.95f, 0);             //Set player at starting point
            rb.velocity = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.DownArrow)) {      //Release player from lock
                atStart = false;
                rb.constraints = RigidbodyConstraints2D.None;
                this.gameObject.layer = 9;  //0 for ground, 9 for fall through
            }
        } else if (followButterfly) {               //If player is on mama butterfly
            if (!music1.isPlaying) music1.Play();   //Play once
            music1.volume += 0.006f;
            music3.volume -= 0.005f;
            transform.position = giantButterfly.transform.position;
            rb.velocity = Vector3.zero;
            branch.sortingOrder = -10;              //Fade in-out of starting branch
            branch2.sortingOrder = 9;
            playerAnimator.SetBool("Jumping", false);   //so the bubble open his eyes while on the mama butterfly
            playerAnimator.SetBool("FreeFall", false);  //so the bubble open his eyes while on the mama butterfly

            if (transform.position.y >= 69.95f) {
                followButterfly = false;
                transform.position = new Vector3(0, 69.95f, 0);
                atStart = true;
            }
        } else {
            //FREE FALL FACE

            if (Grounded == 0 && TouchingRoof == 0) {
                playerAnimator.SetBool("FreeFall", true);
            } else {
                playerAnimator.SetBool("FreeFall", false);
            }

            //JUMP CHARGE & JUMP RELEASE
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                //Debug.Log("Pressed up arrow. Grounded: " + Grounded);
                if (Grounded > 0) {
                    playerAnimator.SetBool("PreJumping", true);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                playerAnimator.SetBool("Moving", true);

                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                    playerAnimator.SetBool("Jumping", true);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                playerAnimator.SetBool("Moving", true);

                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                    playerAnimator.SetBool("Jumping", true);
                }
            }
            playerAnimator.SetBool("Moving", false);

            //JUMP FACE
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                if (Grounded > 0) {
                    rb.velocity = new Vector2(0f, jumpSpeed);
                    Grounded = 0;
                    playerAnimator.SetBool("PreJumping", false);
                    jumpCheck = 60;
                }
            }

            //JUMP CHECK
            jumpCheck -= 1;
            if (jumpCheck > 0) {
                playerAnimator.SetBool("Jumping", true);
            } else {
                playerAnimator.SetBool("Jumping", false);
            }

            //DOWN ARROW
            if (Input.GetKeyUp(KeyCode.DownArrow)) {
                rb.velocity = new Vector2(rb.velocity.x, -jumpDownSpeed);
            }
        }

        //GRAVITY when player is touching a leaf
        if (TouchingRoof > 0) {
            //stick to leaf
            rb.gravityScale = -1f;
        } else {
            rb.gravityScale = 1f;
        }
    }


    private void FixedUpdate() {
        TouchingRoof -= 1;
        if (TouchingRoof < 0) TouchingRoof = 0;
        Grounded -= 1;
        if (Grounded < 0) Grounded = 0;

        if (TouchingRoof > 0) {
            sr.flipY = true;
        } else {
            sr.flipY = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        LeafSFX leaf = collision.collider.gameObject.GetComponentInParent<LeafSFX>();
        musicCheckFall = true;
        musicCheckClimb = true;

        if (leaf != null && Grounded >= 1) {
            leaf.StartBounce();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "GroundFake") {
            if (collision.contacts.Length > 0) {//is there any contact point

                Vector2 collisionPoint = collision.contacts[0].point;
                if (transform.position.y > collisionPoint.y + 0.01f) {
                    Grounded = 5;
                } else if (transform.position.y < collisionPoint.y - 0.01f) {
                    TouchingRoof = 5;
                }
            }

        }
        if (collision.gameObject.tag == "GroundFake") {
            //Debug.Log("touching GroundFake");
            showShadow = 0;
        }
        if (collision.gameObject.tag == "Ground") {
            showShadow = 5;
            Debug.Log("showShadow:" + showShadow);
            if (showShadow > 5) showShadow = 5;
        }

        
        if (collision.gameObject.layer == 8 && this.gameObject.layer == 9 && groundTouch == false) {
            this.gameObject.layer = 0;
            rb.velocity = new Vector2(0.0f, jumpSpeed+0.2f);
            groundTouch = true;

            music1.Stop();  //Stop playing intro music
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "MamaButterfly" && !followButterfly) {
            //transform.position.Set
            giantButterfly = collision.gameObject;
            giantButterfly.GetComponent<Animator>().Play("flapping-mamaButterfly");
            giantButterfly.GetComponent<CapsuleCollider2D>().enabled = false;
            followButterfly = true;
        }
    }
}