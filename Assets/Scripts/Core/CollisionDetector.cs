using Core.Hero;
using UnityEngine;

namespace Core
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private TransformShaker _shaker;
        private void OnCollisionEnter(Collision collision)
        {
            _shaker.StartShaking(collision);
        }

        private void OnCollisionExit(Collision other)
        {
            _shaker.StopShaking(other);
        }
    }
}