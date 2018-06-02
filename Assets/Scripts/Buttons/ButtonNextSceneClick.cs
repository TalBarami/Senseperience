using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextSceneClick : ButtonClickScript
{
    const int scenesCount = 5;
    public override void Execute()
    {
        Debug.Log("Starting Game Scene");
        Destroy(GameObject.Find("Geomagic"));
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % scenesCount);
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }
}
