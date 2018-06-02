using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ButtonPostProcessingClick : ButtonClickScript
{
    private Camera mainCamera;

    public override void Execute()
    {
        var postProcessScript = mainCamera.GetComponent<PostProcessingBehaviour>();
        postProcessScript.enabled = !postProcessScript.enabled;
        
    }

    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

