using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingObjectScript : MonoBehaviour {
    private float flashingInterval = 5;
    private bool isFlashing = false;
    private bool isActive = false;
    private float time = 0;
    private float flashSpeed = 5f;

    private new Renderer renderer;
    private Color originalColor;
    private Color flashingColor;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        flashingColor = Color.gray;//originalColor.Equals(Color.white) ? Color.gray : Color.white;
    }
    
	// Update is called once per frame
	void Update () {
        if (!isActive)
        {
            return;
        }
        time += Time.deltaTime;
        if (isFlashing)
        {
            renderer.material.color = Color.Lerp(originalColor, flashingColor, Mathf.PingPong(Time.time, 1));
        }
        else
        {
            renderer.material.color = originalColor;
        }

        if (time >= flashingInterval)
        {
            isFlashing = !isFlashing;
            time = 0;
        }
    }

    public void SetActivation(bool isActive)
    {
        this.isActive = isActive;
        if (renderer != null)
        {
            renderer.material.color = originalColor;
        }
    }
}
