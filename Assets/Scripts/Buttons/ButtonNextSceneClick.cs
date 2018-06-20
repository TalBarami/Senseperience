using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextSceneClick : ButtonClickScript
{
    private bool ready;

    public override void Execute()
    {
        if (ready)
        {
            HotkeyManager.NextScene();
        }
        
    }

    // Use this for initialization
    void Start () {
        //ready = false;
        ready = true; // TODO: Decide if we keep this one.
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SetReady()
    {
        ready = true;
    }
}
