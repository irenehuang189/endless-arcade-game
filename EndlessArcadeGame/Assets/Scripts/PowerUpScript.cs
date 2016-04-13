using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
    public float objectSpeed = -.2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            transform.Translate(0, 0, objectSpeed);
        }
	}
}
