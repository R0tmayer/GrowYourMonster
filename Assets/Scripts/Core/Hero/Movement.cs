using System;
using Core.Input;
using UnityEngine;

namespace Core.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        private CharacterController _characterController;
        private InputJoystickReceiver _input;
        
        public void Construct(InputJoystickReceiver input)
        {
            _input = input;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if(_input.DirectionIsZero)
                return;
            
            var direction = new Vector3(_input.Direction.x, 0, _input.Direction.y);
            LookAt(direction);
            _characterController.Move(direction * _speed * _input.DistanceRation * Time.deltaTime);
        }

        private void LookAt(Vector3 direction)
        {
            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            float step = _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(lookRotation, transform.rotation, step);
        }
    }
}