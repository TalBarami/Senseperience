using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {
    public float rotationInterval;
    public float speed;

    private float lastRotated;
    private bool rotating;
    private bool upsideDown;

    // Use this for initialization
    void Start () {
        lastRotated = 0;
        upsideDown = true;
        rotating = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotating)
        {
            float angle = upsideDown ? 180 : 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * speed);

            float diff = transform.rotation.eulerAngles.z - angle;
            float dergee = 1;
            if (Mathf.Abs(diff) <= dergee)
            {
                rotating = false;
            }
            return;

        }
        lastRotated += Time.deltaTime;
        if (lastRotated >= rotationInterval)
        {
            lastRotated = 0;
            rotating = true;
            upsideDown = !upsideDown;
        }
    }
}
