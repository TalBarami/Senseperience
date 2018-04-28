using System.Collections;
using System.Collections.Generic;
using Assets.Util;
using UnityEngine;

public class CollisionSoundController : MonoBehaviour
{
    AudioSource collisionAudio;
    private CollisionState collisionState;
    double lastPlayed;

    public CollisionState GetCollisionState()
    {
        return collisionState;
    }

    public AudioSource GetCollisionAudioSource()
    {
        return collisionAudio;
    }
    
    // Use this for initialization
    void Start()
    {
        var audios = GetComponents<AudioSource>();
        collisionAudio = audios[0];
        lastPlayed = Time.time;
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
        var currentTime = Time.time;
        if(currentTime - lastPlayed > 0.3)
        {
            collisionAudio.Play();
            lastPlayed = currentTime;
        }
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

