using UnityEngine;

namespace Core.Hero
{
    public class Attack : MonoBehaviour
    {
        public int Rate { get; private set; } = 2;

        public void IncreaseRate(float value) => Rate += (int)value;
    }
}