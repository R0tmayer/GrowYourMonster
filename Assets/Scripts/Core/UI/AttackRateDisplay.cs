using System;
using Core.Hero;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class AttackRateDisplay : MonoBehaviour
    {
        [SerializeField] [Required] private TMP_Text _text;

        public void UpdateValue(int value)
        {
            _text.SetText("{0:0}", value);
        }
    }
}