using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;

    float zPosition;
    float xPosition;

    float cameraOffset = 2f;

	// Use this for initialization
	void Start () {
        zPosition = transform.position.z;
        xPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        float playerY = player.transform.position.y;
        playerY = Mathf.Clamp(playerY+cameraOffset, 0f, 70.5f);
        transform.position = new Vector3(xPosition, playerY, zPosition);
	}
}
