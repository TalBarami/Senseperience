using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetection : MonoBehaviour
    {
        public bool IsOnCollision;

        void OnCollisionEnter(Collision col)
        {
            IsOnCollision = true;
        }

        void OnCollisionExit(Collision col)
        {
            IsOnCollision = false;
        }
    }
}
