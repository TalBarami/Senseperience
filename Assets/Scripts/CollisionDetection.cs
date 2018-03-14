using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetection : MonoBehaviour
    {
        public bool IsOnCollision;
        Collider other;

        void OnCollisionEnter(Collision col)
        {
            IsOnCollision = true;
            other = col.collider;
        }

        void OnCollisionExit(Collision col)
        {
            IsOnCollision = false;
            other = null;
        }

        public Collider GetOther()
        {
            return other;
        }
    }
}
