using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {
    public Light flashlight;
    public float capacity;
    private float battery;

    private bool previousButtonState;

    // Use this for initialization
    void Start () {
        battery = capacity;
        previousButtonState = false;
	}

	// Update is called once per frame
	void Update () {

        if (PluginImport.GetButton2State() && battery > 0)
        {
            battery -= Time.deltaTime;
            if (!previousButtonState)
            {
                flashlight.enabled = true;
                previousButtonState = true;
            }
        }
        else
        {
            if (!PluginImport.GetButton2State())
            {
                flashlight.enabled = false;
                previousButtonState = false;
            }

            if (battery < capacity)
            {
                battery += Time.deltaTime / 10;
            }
        }
	}
}
