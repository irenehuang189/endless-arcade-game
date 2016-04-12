using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {
    // Attribute
    float speed = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * speed;
        renderer.material.mainTextureOffset = new Vector2(0, -offset);
	}
}
