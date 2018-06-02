using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    private bool clicking;
    private string penName;
    private float clickInterval;
    private float lastClicked;

    // Use this for initialization
    void Start()
    {
        penName = "GeomagicPen";
        clickInterval = lastClicked = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lastClicked += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if(lastClicked < clickInterval)
        {
            return;
        }
        lastClicked = 0;
        OnButtonClick();
    }

    void OnCollisionExit(Collision other)
    {
        //Debug.Log("Button exit: " + other.gameObject.name);
        //clicking = false;
    }

    void OnButtonClick()
    {
        //Debug.Log("OnButtonClick");
        GetComponent<ButtonClickScript>().Execute();
    }
}
