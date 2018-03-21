using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Assets.Util;
using JetBrains.Annotations;
using UnityEngine;

public class CollisionSoundController : MonoBehaviour
{
    private AudioSource _collisionAudio;
    private AudioSource _frictionAudio;

    public AudioSource GetCollisionAudioSource()
    {
        return _collisionAudio;
    }

    public AudioSource GetFrictionAudioSource()
    {
        return _frictionAudio;
    }

    public CollisionState CollisionState
    {
        get { return CollisionState; }
        set
        {
            if (!Enum.IsDefined(typeof(CollisionState), value))
                throw new InvalidEnumArgumentException("value", (int) value, typeof(CollisionState));
            CollisionState = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        var audios = GetComponents<AudioSource>();
        _collisionAudio = audios[0];
        _frictionAudio = audios[1];
        CollisionState = CollisionState.None;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");
        CollisionState = CollisionState.Enter;
        _collisionAudio.Play();
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay");
        CollisionState = CollisionState.Stay;
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit");
        CollisionState = CollisionState.Exit;
    }
}
