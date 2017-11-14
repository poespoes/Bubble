using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSFX : MonoBehaviour {
    public AudioClip boing;
    private AudioSource source;
    public Transform leafHinge;

    public float zRotMin;
    public float zRotMax;


    // Use this for initialization
    void Start () {
        source = GetComponentInChildren<AudioSource>();
        source.volume = 1.0f;

    }
	
	// Update is called once per frame

	void Update () {
        float zRot = leafHinge.rotation.eulerAngles.z;
        //Debug.Log(zRot);
        if (zRot >= zRotMin) {
            float vol = (zRotMax - zRot) / (zRotMax - zRotMin);
            source.volume = vol;
            //Debug.Log("volume " + vol);
        }
    }

    public void StartBounce() {
        float zRot = leafHinge.rotation.eulerAngles.z;
        float vol = (zRotMax - zRot) / (zRotMax - zRotMin);
        if(!source.isPlaying) source.PlayOneShot(boing, vol);
        //Debug.Log("starting bounce at time " + Time.time);
    }

    public void StopBounce() {
        source.volume = 0;
    }
}
