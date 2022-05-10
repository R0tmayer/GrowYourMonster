using System;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Hero
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] [Required] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] [Required] private Transform _target;
        [SerializeField] private float _lerpRate;
        [SerializeField] private float A;
        [SerializeField] private float B;
        
        private CinemachineTransposer _transposer;
        private Vector3 _startOffset;

        private void Awake()
        {
            _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            _startOffset = _transposer.m_FollowOffset;
            
            var newOffset = _startOffset + Vector3.one * _target.localScale.x * A / 100f;
            newOffset.x = 0;
            newOffset.z = _startOffset.z - _target.localScale.x * B / 100f;

            _transposer.m_FollowOffset = newOffset;
        }

        private void Update()
        {
            var newOffset = _startOffset + Vector3.one * _target.localScale.x * A / 100f;
            newOffset.x = 0;
            newOffset.z = _startOffset.z - _target.localScale.x * B / 100f;
            
            _transposer.m_FollowOffset =
                Vector3.Lerp(_transposer.m_FollowOffset, newOffset,
                    Time.deltaTime * _lerpRate);
        }
    }
}