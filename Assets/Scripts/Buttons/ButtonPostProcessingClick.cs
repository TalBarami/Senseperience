using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ButtonPostProcessingClick : ButtonClickScript
{
    public Camera camera;

    public override void Execute()
    {
        var postProcessScript = camera.GetComponent<PostProcessingBehaviour>();
        postProcessScript.enabled = !postProcessScript.enabled;
        
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

