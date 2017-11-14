using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    SpriteRenderer sr;
    float startAlpha;
    public float alphaMax = 1f;         //Max alpha
    public float alphaMin = 0.85f;      //Min alpha
    public float increment = 0.001f;    //Set fade speed
    float alpha;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
        startAlpha = Random.Range(alphaMin, alphaMax);  //Random alpha of the first frame
        alpha = startAlpha;
	}
	
	void Update () {
        sr.color = new Color(1f, 1f, 1f, alpha);        //Set alpha

        alpha += increment;
        if (alpha > alphaMax || alpha < alphaMin) {     //Alpha will increase and decrease when reach Min and Max
            increment *= -1;
        }
	}
}
