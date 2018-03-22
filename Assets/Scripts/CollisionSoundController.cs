using System.Collections;
using System.Collections.Generic;
using Assets.Util;
using UnityEngine;

public class CollisionSoundController : MonoBehaviour
{
    AudioSource collisionAudio;
    AudioSource frictionAudio;
    private CollisionState collisionState;

    public CollisionState GetCollisionState()
    {
        return collisionState;
    }

    public AudioSource GetCollisionAudioSource()
    {
        return collisionAudio;
    }

    public AudioSource GetFrictionAudioSource()
    {
        return frictionAudio;
    }

    // Use this for initialization
    void Start()
    {
        var audios = GetComponents<AudioSource>();
        collisionAudio = audios[0];
        frictionAudio = audios[1];
        collisionState = CollisionState.None;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionState = CollisionState.Enter;
        Debug.Log("Collision Enter");
        collisionAudio.Play();
    }

    void OnCollisionStay(Collision collision)
    {
        collisionState = CollisionState.Stay;
        Debug.Log("Collision Stay");
    }

    void OnCollisionExit(Collision collision)
    {
        collisionState = CollisionState.Exit;
        Debug.Log("Collision Exit");
    }
}

