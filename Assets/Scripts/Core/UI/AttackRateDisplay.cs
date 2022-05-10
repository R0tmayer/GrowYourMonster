using System;
using Core.Hero;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class AttackRateDisplay : MonoBehaviour
    {
        [SerializeField] [Required] private Attack _attacker;
        [SerializeField] [Required] private TMP_Text _text;

        private void Update()
        {
            _text.SetText("{0:0}", _attacker.Rate);
        }
    }
}