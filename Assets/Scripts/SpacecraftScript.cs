using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftScript : MonoBehaviour {
    public float initialX;
    public float initialY;
    public float initialZ;
    public float speed = 100;

    private float veryFarX = 120;
    private Vector3 initial;

	// Use this for initialization
	void Start () {
        initial = new Vector3(-veryFarX + initialX, initialY, initialZ);
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x >= veryFarX)
        {
            Reset();
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void Reset()
    {
        transform.position = initial;
    }
}
