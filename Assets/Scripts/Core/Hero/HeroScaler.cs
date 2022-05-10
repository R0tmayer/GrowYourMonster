using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Hero
{
    public class HeroScaler : MonoBehaviour
    {
        private Vector3 _startScale;
        private Vector3 _maxScale;

        private GameParameters _gameParameters;

        public void Construct(GameParameters gameParameters)
        {
            _gameParameters = gameParameters;
        }

        private void Awake()
        {
            _startScale = transform.localScale;
            _maxScale = Vector3.one * _gameParameters.MaxSingleScale;
        }

        public void IncreaseScale(int value)
        {

            var additiveScale = Vector3.one * value * _gameParameters.HeroScaleRate;
            
            if (additiveScale.magnitude > _maxScale.magnitude)
            {
                additiveScale = _maxScale;
            }
            
            transform.localScale += additiveScale;
        }
    }
}