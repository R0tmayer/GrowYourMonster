using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Hero
{
    public class BlendShape : MonoBehaviour
    {
        [SerializeField] [Required] private SkinnedMeshRenderer _skinnedMeshRenderer;
        private float _value = 100f;

        private GameParameters _gameParameters;

        public void Construct(GameParameters gameParameters)
        {
            _gameParameters = gameParameters;
        }

        private void LateUpdate()
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, _value);
        }

        public void Decrease(int value)
        {
            _value -= value * _gameParameters.BlendShapeRate;
            
            if (_value < 0)
            {
                _value = 0;
            }
        }
    } 
}