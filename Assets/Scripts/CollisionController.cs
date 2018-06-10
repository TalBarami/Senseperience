using System.Collections;
using System.Collections.Generic;
using Assets.Util;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int playingDelay;
    public bool touched = false;

    private AudioSource collisionAudio;
    private CollisionState collisionState;
    private double lastPlayed;

    const float timeBetweenPlays = 0.7f;

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
        lastPlayed = Time.realtimeSinceStartup - (timeBetweenPlays + playingDelay);
        collisionState = CollisionState.None;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name + " touched = " + touched);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("GeomagicPen")){
            touched = true;
        }
        
        collisionState = CollisionState.Enter;
        var currentTime = Time.realtimeSinceStartup;
        if(!collisionAudio.isPlaying && currentTime - lastPlayed > (timeBetweenPlays + playingDelay))
        {
            collisionAudio.Play();
            lastPlayed = currentTime;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        collisionState = CollisionState.Stay;
    }

    void OnCollisionExit(Collision collision)
    {
        collisionState = CollisionState.Exit;
    }
}

