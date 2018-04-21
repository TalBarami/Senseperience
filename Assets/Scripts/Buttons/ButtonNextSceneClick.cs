using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextSceneClick : ButtonClickScript
{
    private static int TOTAL_SCENES = 3;

    public override void Execute()
    {
        Debug.Log("Starting Game Scene");
        Destroy(GameObject.Find("Geomagic"));
        Destroy(GameObject.Find("GeomagicPen"));
        SceneManager.LoadScene(1 + ((SceneManager.GetActiveScene().buildIndex) % TOTAL_SCENES));
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }
}
