using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundController : MonoBehaviour {
    AudioSource collisionAudio;
    AudioSource frictionAudio;

    // Use this for initialization
    void Start()
    {
        var audios = GetComponents<AudioSource>();
        collisionAudio = audios[0];
        frictionAudio = audios[1];
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");
        collisionAudio.Play();
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit");
    }
}
