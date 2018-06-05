using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Manager : MonoBehaviour {
    public ButtonController button1;
    public ButtonController button2;


	// Use this for initialization
	void Start () {
		button2.GetComponent<FlashingObjectScript>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (button1.clicked)
        {
            button1.GetComponent<FlashingObjectScript>().enabled = false;
            button2.GetComponent<FlashingObjectScript>().enabled = true;
        }
	}
}
