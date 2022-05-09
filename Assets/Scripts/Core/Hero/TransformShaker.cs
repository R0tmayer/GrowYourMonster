using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Core.Hero
{
    public class TransformShaker : MonoBehaviour
    {
        [SerializeField] [Range(0,2)] private float _duration;
        [SerializeField] [Range(0,2)] private float _shakeStrength;

        private bool _collided;

        public void StartShaking(Collision collision)
        {
            if(_collided)
                return;
            
            if (collision.gameObject.TryGetComponent(out Movement _))
            {
                _collided = true;

                transform.DOShakePosition(_duration, _shakeStrength)
                    .SetEase(Ease.Linear)
                    .SetLoops(int.MaxValue)
                    .SetId(this);
            }
        }

        public void StopShaking(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Movement _))
            {
                _collided = false;

                DOTween.Kill(this);
            }
        }
    }
}