using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    private bool clicking;
    private string penName = "GeomagicPen";

    // Use this for initialization
    void Start()
    {
        //clicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("Clicking = " + clicking + " , transform z is: " + this.transform.localPosition.z);
        if (clicking)
        {
            if(this.transform.localPosition.z > -0.15)
            {
                OnButtonClick();
            }
            else
            {
                this.transform.Translate((Vector3.forward * Time.deltaTime) / 5);
            }
        }
        else if(this.transform.localPosition.z > -0.4)
        {
                this.transform.Translate((Vector3.back * Time.deltaTime) / 5);
        }*/
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Button collided: " + other.gameObject.name);
        //clicking = other.gameObject.name == penName;
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
