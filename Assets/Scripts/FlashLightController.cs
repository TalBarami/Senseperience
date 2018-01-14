using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {
    public Light light;

	// Use this for initialization
	void Start () {
	}

    bool previousButtonState = false;
	// Update is called once per frame
	void Update () {
        if (!previousButtonState && PluginImport.GetButton2State())
        {
            light.enabled = true;
            previousButtonState = true;
        } else if(previousButtonState && !PluginImport.GetButton2State())
        {
            light.enabled = false;
            previousButtonState = false;
        }
	}
}
