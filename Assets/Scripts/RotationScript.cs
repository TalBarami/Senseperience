using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {
    public Vector3 rotation;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Random.Range(0f, 1f);
        transform.Rotate(rotation * speed);
    }
    
}
