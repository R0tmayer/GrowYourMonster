﻿using System;
using System.Collections;
using Core.Hero;
using Core.UI;
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
        [SerializeField] [Required] private FillBar _fillBar;

        private GameParameters _gameParameters;
        private IEnumerator _healthCoroutine;

        public int StartValue { get; private set; }

        private void Start()
        {
            StartValue = (int) _health;
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

                _fillBar.gameObject.SetActive(false);
            }
        }

        private IEnumerator HealthCoroutine()
        {
            if (StartValue == 1)
            {
                DestroyObstacle();
                _detector.CurrentAttacker.IncreaseRate(1);
                yield break;
            }

            while (_health > 0)
            {
                _health -= _detector.CurrentAttacker.Rate * Time.deltaTime;

                var lerpValue = Mathf.InverseLerp(StartValue, 0, _health);
                var fillBarValue = Mathf.Lerp(1, 0, lerpValue);
                _fillBar.UpdateValue(fillBarValue);

                if (_health <= 0)
                {
                    DestroyObstacle();
                    _detector.CurrentAttacker.IncreaseRate(StartValue * _gameParameters.HeroAttackModificator);
                    _fillBar.gameObject.SetActive(false);
                    yield break;
                }

                yield return null;
            }
        }

        private void DestroyObstacle()
        {
            _switcherToDivided.Switch();
            _detector.HeroScaler.IncreaseScale(StartValue);
            _detector.CurrentAnimator.ResetAttackState();
        }
    }
}