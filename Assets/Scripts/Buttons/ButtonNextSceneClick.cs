using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextSceneClick : ButtonClickScript
{
    public override void Execute()
    {
        Debug.Log("Starting Game Scene");
        Destroy(GameObject.Find("Geomagic"));
        Destroy(GameObject.Find("GeomagicPen"));
        SceneManager.LoadScene(((SceneManager.GetActiveScene().buildIndex+1) % 3));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
