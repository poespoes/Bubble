using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour {
    Transform playerTransform;
    SpriteRenderer shadowSprite;
    public Player playerScript;

    void Start() {
        shadowSprite = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update() {
        //SHADOW POSITION
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
    }
}