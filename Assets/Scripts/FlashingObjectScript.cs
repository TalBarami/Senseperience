using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingObjectScript : MonoBehaviour {
    public float flashingInterval;

    private bool isFlashing;
    private float time = 0;
    private float flashSpeed = 5f;

    private Renderer renderer;
    private Color originalColor;
    private Color normalColor;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    bool a = false;
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        Debug.Log("Time: " + time + "   isFlashing: " + isFlashing);
        if (isFlashing)
        {
            //renderer.material.color = Color.Lerp(originalColor, Color.white, flashSpeed);
            renderer.material.color = Color.Lerp(originalColor, Color.white, Mathf.PingPong(Time.time, 1)); 
            a = !a;
            if (time >= flashingInterval)
            {
                isFlashing = false;
                time = 0;
            }
        }
        else
        {
            renderer.material.color = originalColor;
           if(time >= flashingInterval)
            {
                isFlashing = true;
                time = 0;
            }
        }
	}
}
