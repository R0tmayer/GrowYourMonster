using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Obstacles
{
    public class SwitcherToDividedPieces : MonoBehaviour
    {
        [SerializeField] [Required] private CollisionDetector _detector;
        [SerializeField] [Required] private HealthComponent _health;
        [SerializeField] [Required] private ObstacleShaker _shaker;
        [SerializeField] [Required] private ObstacleScaler _scaler;
        [SerializeField] [Required] private Collider _collider;
        [SerializeField] [Required] private GameObject _dividedParent;

        public void Switch()
        {
            _shaker.StopShaking();
            _shaker.gameObject.SetActive(false);
            _collider.enabled = false;
            _dividedParent.SetActive(true);
            _scaler.ScaleToZeroAfterDelay();
            _detector.CurrentBlendShape.Decrease(_health.StartValue);
        }
    }
}