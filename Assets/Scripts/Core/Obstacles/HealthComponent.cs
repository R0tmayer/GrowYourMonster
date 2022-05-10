using System;
using System.Collections;
using Core.Hero;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Obstacles
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] [Required] private SwitcherToDividedPieces _switcherToDivided;
        [SerializeField] [Required] private CollisionDetector _detector;

        private GameParameters _gameParameters;
        private IEnumerator _healthCoroutine;

        public int StartValue { get; private set; }

        private void Start()
        {
            StartValue = (int)_health;
        }

        public void Construct(GameParameters gameParameters)
        {
            _gameParameters = gameParameters;
        }

        public void StartDecreaseHealth()
        {
            if (_healthCoroutine == null)
            {
                _healthCoroutine = HealthCoroutine();
                StartCoroutine(_healthCoroutine);
            }
        }

        public void StopDecreaseHealth()
        {
            if (_healthCoroutine != null)
            {
                StopCoroutine(_healthCoroutine);
                _healthCoroutine = null;
            }
            
        }

        private IEnumerator HealthCoroutine()
        {
            while (_health > 0)
            {
                _health -= _detector.CurrentAttacker.Rate * Time.deltaTime;

                if (_health <= 0)
                {
                    _detector.CurrentAttacker.IncreaseRate(StartValue * _gameParameters.HeroAttackModificator);
                    _detector.HeroScaler.IncreaseScale(StartValue);
                    _switcherToDivided.Switch();
                    yield break;
                }
                
                yield return null;
            }
        }
    }
}