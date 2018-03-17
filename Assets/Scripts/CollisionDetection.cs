using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetection : MonoBehaviour
    {
        public bool IsOnCollision { get; set; }
        public Collider Other;

        public void OnCollisionEnter(Collision col)
        {
            IsOnCollision = true;
            Other = col.collider;
        }

        /*public void OnCollisionExit(Collision col)
        {
            IsOnCollision = false;
            Other = null;
        }*/

        public Collider GetOther()
        {
            return Other;
        }
    }
}
