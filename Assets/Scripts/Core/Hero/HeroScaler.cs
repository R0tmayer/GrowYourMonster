using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Hero
{
    public class HeroScaler : MonoBehaviour
    {
        [SerializeField] [Required] private Transform _model;
        private Vector3 _maxScale;

        private GameParameters _gameParameters;

        public void Construct(GameParameters gameParameters)
        {
            _gameParameters = gameParameters;
        }

        public void IncreaseScale(int value)
        {
            var additiveValue = value * _gameParameters.HeroScaleRate;
            
            if (additiveValue > _gameParameters.MaxSingleScale)
            {
                additiveValue = _gameParameters.MaxSingleScale;
            }

            _model.localScale += _model.localScale * additiveValue;
        }
    }
}