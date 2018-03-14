﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    public ButtonClickScript onButtonClick;

    private bool clicking;
    private string penName = "GeomagicPen";

    // Use this for initialization
    void Start()
    {
        clicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicking)
        {
            if(this.transform.position.z > -0.15)
            {
                OnButtonClick();
            }
            else
            {
                this.transform.Translate((Vector3.forward * Time.deltaTime) / 5);
            }
        }
        else if(this.transform.position.z > -0.4)
        {
                this.transform.Translate((Vector3.back * Time.deltaTime) / 5);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Button collided: " + other.gameObject.name);
        clicking = other.gameObject.name == penName;
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Button exit: " + other.gameObject.name);
        clicking = false;
    }

    void OnButtonClick()
    {
        Debug.Log("OnButtonClick");
        onButtonClick.Execute();
    }
}
