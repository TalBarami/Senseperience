using System;
using System.ComponentModel;
using Assets.Util;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetection : MonoBehaviour
    {
        public CollisionState CollisionState;

        public CollisionState GetCollisionState()
        {
            return CollisionState;
        }

        public bool IsOnCollision { get; set; }
        private Collider _other;

        public void OnCollisionEnter(Collision col)
        {
            CollisionState = CollisionState.Enter;
            IsOnCollision = true;
            _other = col.collider;
        }

        public void OnCollisionExit(Collision col)
        {
            CollisionState = CollisionState.Exit;
        }

        public Collider GetOther()
        {
            return _other;
        }
    }
}
