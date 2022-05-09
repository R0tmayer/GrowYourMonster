using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Hero
{
    public class BlendShape : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] [Range(0, 100)] private float _value;

        private void LateUpdate()
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, _value);
        }
    }
}