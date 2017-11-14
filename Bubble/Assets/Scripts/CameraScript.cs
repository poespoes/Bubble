using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    float zPosition;
    float xPosition;
    float cameraOffset = 2f;

	void Start () {
        zPosition = transform.position.z;
        xPosition = transform.position.x;
	}
	
	void Update () {
        //LOCK CAMERA TO PLAYER (plus offset)
        float playerY = player.transform.position.y;
        playerY = Mathf.Clamp(playerY+cameraOffset, 0f, 70.5f);
        transform.position = new Vector3(xPosition, playerY, zPosition);
	}
}
