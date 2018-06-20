using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGuide : MonoBehaviour {
    public List<GameObject> required;
    private GameObject nextSceneButton;


    // Use this for initialization
    void Start () {
        nextSceneButton = GameObject.FindGameObjectWithTag("NextSceneButton");

        required.ForEach(gameObject => gameObject.AddComponent<FlashingObjectScript>().SetActivation(true));
        nextSceneButton.AddComponent<FlashingObjectScript>().SetActivation(true); //TODO: Set to false.
    }

    // Update is called once per frame
    void Update() {
        required.FindAll(gameObject => gameObject.GetComponent<CollisionController>().touched)
            .ForEach(gameObject => gameObject.GetComponent<FlashingObjectScript>().SetActivation(false));
        required.RemoveAll(gameObject => gameObject.GetComponent<CollisionController>().touched);

        if(!required.Exists(gameObject => !gameObject.GetComponent<CollisionController>().touched))
        {
            nextSceneButton.GetComponent<FlashingObjectScript>().SetActivation(true);
            nextSceneButton.GetComponent<ButtonNextSceneClick>().SetReady();
        }
	}
}
